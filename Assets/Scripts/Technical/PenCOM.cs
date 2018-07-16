using System;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Globalization;

public class PenCOM: MonoBehaviour {
  

  
    SerialPort port;

    //String change
    string[] stringSeparators = new string[] {"\n"};
    static string[] result;

    int lastLength = 0;

    void Start(){
      port = new SerialPort( "\\\\.\\COM5", 9600, Parity.None, 8, StopBits.One);
      lastLength = SerialPort.GetPortNames().Length;
     
      port.RtsEnable = true;

      if(!port.IsOpen){
        port.Open();
      }
     
     port.ReadTimeout = 50;
     result = new string[] {"0","0","0","0","0","0"};
    }
    

	  void FixedUpdate(){
        if(SerialPort.GetPortNames().Length != lastLength){
          port = new SerialPort( "\\\\.\\COM5", 9600, Parity.None, 8, StopBits.One);
           if(!port.IsOpen){
            port.Open();
           }
        }

        if(port.IsOpen){
          try{
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
      lastLength = SerialPort.GetPortNames().Length;
	  }

    

    public Vector3 LoadDeltas(){
        float x = float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat);
        float y = float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat);
        float z = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat);

      return new Vector3(x, y, z);
    }


	
    public Vector3 LoadPositions(){
      float a1 = float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat);
      float a2 = float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat);
      float a3 = float.Parse(result[5], CultureInfo.InvariantCulture.NumberFormat);
      return new Vector3(a1, a2, a3);
    }
   
  }
