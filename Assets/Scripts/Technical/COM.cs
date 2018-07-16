using System;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Globalization;

public class COM : MonoBehaviour {
  

    public enum Device {Ufo, Pen}
    SerialPort port;
    public float divide = 1 ;


    //String change
    string[] stringSeparators = new string[] {"\n"};
    static string[] result;
    Device actualDevice = Device.Ufo;
    int lastLength = 0;


    void Start(){
      port = new SerialPort( "\\\\.\\COM5", 9600, Parity.None, 8, StopBits.One);
      lastLength = SerialPort.GetPortNames().Length;
      for(int i = 0; i < SerialPort.GetPortNames().Length; i++){
        
      }
     
      port.RtsEnable = true;

      if(!port.IsOpen){
        port.Open();
      }
     
     port.ReadTimeout = 50;
     result = new string[] {"0","0","0","0","0"};
    
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
 
            //string message = port.ReadLine();
            if(port.BytesToRead != 0){
              byte[] data = new byte[1024];
              int bytesRead = port.Read(data, 0, data.Length);
              string message = Encoding.ASCII.GetString(data, 0, bytesRead);
              if(message.Length > 0){
                result = message.Split(stringSeparators,StringSplitOptions.None);
                if(result[5] != null && result[5] != ""){
                  actualDevice = Device.Pen;
                } else {
                  actualDevice = Device.Ufo;
                }
              }
            }

          } catch{
            throw;
          }
        }
           lastLength = SerialPort.GetPortNames().Length;
	  }

    public Device GetActualDevice(){
      return actualDevice;
    }


    public Vector3 LoadPositions(){
      float x,y,z;
      try{
       
        if(actualDevice == Device.Pen){
           x = Mathf.Round(float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat) / divide);
           y = Mathf.Round(float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat) / divide);
           z = float.Parse(result[5], CultureInfo.InvariantCulture.NumberFormat);
        } else {
           x = Mathf.Round(float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat) / divide);
           y = Mathf.Round(float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat) / divide);
          z = 0.0f;
      }
      } catch {
        x = 0;
        y = 0;
        z = 0;
      }
      return new Vector3(x, y, z);
    }

    public Vector3 LoadAngles(){
      float a1,a2,a3;
      try{
        a1 = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat) / divide;
        a2 = float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat) / divide;
        a3 = float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat) / divide;
      } catch {
        a1 = 0;
        a2 = 0;
        a3 = 0;
      }
      return new Vector3(a1, a2, a3);
    }


      public Vector3 LoadDeltas(){
        float x,y,z;
        try{
           x = float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat);
          y = float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat);
          z = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat);
        } catch{
          x = 0;
          y = 0;
          z = 0;
        }

      return new Vector3(x, y, z);
    }
   
  }
