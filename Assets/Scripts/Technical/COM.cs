﻿using System;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Globalization;

public class COM : MonoBehaviour {
  

  
    SerialPort port;
    public float divide = 8000.0f;

    SerialPort port2;
    int counter = 0;


    //String change
    string[] stringSeparators = new string[] {"\n"};
    static string[] result;



    void Start(){
      port = new SerialPort( "\\\\.\\COM5", 9600, Parity.None, 8, StopBits.One);
      //port2 = new SerialPort( "\\\\.\\COM2", 9600, Parity.None, 8, StopBits.One);
     
      port.RtsEnable = true;

      if(!port.IsOpen){
        port.Open();
        //port2.Open();
      }
     
     port.ReadTimeout = 25;
     //port2.ReadTimeout = 25;

    
    }
    

	  void FixedUpdate(){
        if(counter % 2 == 0)
        //port2.WriteLine(counter.ToString());
        counter++;
        if(port.IsOpen){  
          try{
            
            //string message = port.ReadLine();
            if(port.BytesToRead != 0){
              byte[] data = new byte[1024];
              int bytesRead = port.Read(data, 0, data.Length);
              string message = Encoding.ASCII.GetString(data, 0, bytesRead);
              if(message.Length > 0){
                Debug.Log(message);
                result = message.Split(stringSeparators,StringSplitOptions.None);
              }
            }

          } catch{
            throw;
          }
        }
	  }

    

    public Vector3 LoadPositions(){
      float x = Mathf.Round(float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat) / divide);
      float y = Mathf.Round(float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat) / divide);
      //float z = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat);
      float z = 0.0f;

      return new Vector3(x, y, z);
    }

    public Vector3 LoadAngles(){
      float a1 = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat) / divide;
      float a2 = float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat) / divide;
      float a3 = float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat) / divide;
      return new Vector3(a1, a2, a3);
    }
   
  }
