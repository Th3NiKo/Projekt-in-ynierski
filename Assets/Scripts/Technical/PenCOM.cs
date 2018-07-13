using System;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Globalization;

public class PenCOM: MonoBehaviour {
  

  
    SerialPort port;
    public float divide = 8000.0f;


    //String change
    string[] stringSeparators = new string[] {"\n"};
    static string[] result;



    void Start(){
      port = new SerialPort( "\\\\.\\COM5", 9600, Parity.None, 8, StopBits.One);
     
      port.RtsEnable = true;

      if(!port.IsOpen){
        port.Open();
      }
     
     port.ReadTimeout = 50;
     result = new string[] {"0","0","0","0","0"};
    
    }
    

	  void FixedUpdate(){
        if(port.IsOpen){
          
          try{
 
            //string message = port.ReadLine();
            if(port.BytesToRead != 0){
              byte[] data = new byte[1024];
              int bytesRead = port.Read(data, 0, data.Length);
              string message = Encoding.ASCII.GetString(data, 0, bytesRead);
              if(message.Length > 0){
                result = message.Split(stringSeparators,StringSplitOptions.None);
              }
            }

          } catch{
            throw;
          }
        }
	  }

    

    public Vector3 LoadDeltas(){
      float x = Mathf.Round(float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat) / divide);
      float y = Mathf.Round(float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat) / divide);
      float z = Mathf.Round(float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat) / divide);

      return new Vector3(x, y, z);
    }


	//
    public Vector3 LoadPositions(){
      float a1 = float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat) / divide;
      float a2 = float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat) / divide;
      float a3 = float.Parse(result[5], CultureInfo.InvariantCulture.NumberFormat) / divide;
      return new Vector3(a1, a2, a3);
    }
   
  }
