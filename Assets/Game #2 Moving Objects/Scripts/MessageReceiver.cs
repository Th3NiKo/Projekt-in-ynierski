using System;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;


public class MessageReceiver : MonoBehaviour {
  

    public enum Device {Ufo, Pen}
    SerialPort port;


    //String change
    string[] stringSeparators = new string[] {"\n"};
    public string[] result;
    Device actualDevice = Device.Ufo;
    int lastLength = 0;

    private Vector3 lastPosition;

    //For buttons only
    private bool[] LastButton;


    bool wiritngPen;
  
    string comName;
    void Start(){
      wiritngPen = false;
      //Two buttons set to 0 at start
      LastButton = new bool [2];
      LastButton[0] = false;
      LastButton[1] = false;
      result = new string[] {"0","0","0","0","0"};
      lastPosition = new Vector3(0,0,0);
      if(SerialPort.GetPortNames().Length > 0)  
        comName = SerialPort.GetPortNames()[0];

      
      for(int i = 0; i < SerialPort.GetPortNames().Length; i++){
        port = new SerialPort(SerialPort.GetPortNames()[i], 9600, Parity.None, 8, StopBits.One);
        if(!port.IsOpen){
          port.Open();
          if(port.BytesToRead != 0){
              byte[] data = new byte[1024];
              int bytesRead = port.Read(data, 0, data.Length);
              string message = Encoding.ASCII.GetString(data, 0, bytesRead);
              result = message.Split(stringSeparators,StringSplitOptions.None);
              if(result.Length > 5){
                comName = SerialPort.GetPortNames()[i];
                break;
              }
          }
          

        }
      }
      
      
      lastLength = SerialPort.GetPortNames().Length;

      port.RtsEnable = true;

      if(!port.IsOpen){
        port.Open();
      }
     
     port.ReadTimeout = 50;
     
    
    }
    

	  void FixedUpdate(){
		  
		 if(Input.GetKeyDown(KeyCode.Escape)){
       if(port.IsOpen)
          port.Close();
          Application.Quit();
      }

      //if(Input.GetKeyDown(KeyCode.Return)){
       // wiritngPen = !wiritngPen;
     // }
      
        if(!port.IsOpen){
          port = new SerialPort( comName, 9600, Parity.None, 8, StopBits.One);
          port.Open(); 
        }

        if(port.IsOpen){

          try{
 
            //string message = port.ReadLine();
            if(port.BytesToRead != 0){
              byte[] data = new byte[1024];
              int bytesRead = port.Read(data, 0, data.Length);
              string message = Encoding.ASCII.GetString(data, 0, bytesRead);
              //Debug.Log(message);
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


    void LateUpdate()
    {
      if(port.IsOpen){
        int temp = 0;
        if(result.Length > 6 && Int32.TryParse(result[6], out temp)){
          if(temp == 1){
            LastButton[0] = true;
          } else{
            LastButton[0] = false;
          }
        }
        temp = 0;
         if(result.Length > 7 && Int32.TryParse(result[7], out temp)){
          if(temp == 1){
            LastButton[1] = true;
          } else{
            LastButton[1] = false; 
          }
        }
      }

    }

    public Device GetActualDevice(){
      return actualDevice;
    }

    public bool IsWritingPen(){
      return wiritngPen;
    }


    public Vector3 LoadPositions(){
      if(!port.IsOpen){
        return new Vector3(0,0,0);
      }
      float x,y,z;
      try{
       
        if(actualDevice == Device.Pen){
           x = Mathf.Round(float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat));
           y = Mathf.Round(float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat));
           z = float.Parse(result[5], CultureInfo.InvariantCulture.NumberFormat);
        } else {
           x = Mathf.Round(float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat));
           y = Mathf.Round(float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat));
          z = 0.0f;
      }
      } catch {
        x = 0;
        y = 0;
        z = 0;
      }
      if(!port.IsOpen){
        return new Vector3(0,0,0);
      }
      return new Vector3(x, y, z);
    }

    public Vector3 LoadAngles(){
      if(!port.IsOpen){
        return new Vector3(0,0,0);
      }
      float a1,a2,a3;
      try{
        a1 = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat);
        a2 = float.Parse(result[3], CultureInfo.InvariantCulture.NumberFormat);
        a3 = float.Parse(result[4], CultureInfo.InvariantCulture.NumberFormat);
      } catch {
        a1 = 0;
        a2 = 0;
        a3 = 0;
      }
 
      return new Vector3(a1, a2, a3);
    }


    public Vector3 LoadDeltas(){
        if(!port.IsOpen){
          return new Vector3(0,0,0);
       }
       float x,y,z;
       x = y = z = 0;
       if(actualDevice == Device.Pen){
        try{
          x = float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat);
          y = float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat);
          z = float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat);
        } catch{
          x = 0;
          y = 0;
          z = 0;
        }
       } else {
        
         Vector3 posNow = new Vector3(float.Parse(result[0], CultureInfo.InvariantCulture.NumberFormat), 
                                      float.Parse(result[1], CultureInfo.InvariantCulture.NumberFormat),
                                      float.Parse(result[2], CultureInfo.InvariantCulture.NumberFormat));
         x = lastPosition.x - posNow.x;
         y = lastPosition.y - posNow.y; 
         z = lastPosition.z - posNow.z; 
         lastPosition = posNow;
       }
      

      return new Vector3(x, y, z);
    }


    public bool ButtonPressed(int index){
      int temp = 0;
      if(result.Length > 6 + index  && (Int32.TryParse(result[6 + index], out temp))){
        if(temp == 1){
          return true;
        } else {
          return false;
        }
      } else {
        return false;
      }
    }

    public int IsCalibrated() {
        int temp = 0;
        if (result.Length > 8 && Int32.TryParse(result[8], out temp)) {
            return temp;
        }
        return 0;
    }

    public bool ButtonPressedDown(int index){
      int temp = 0;
      if((result.Length > 6 + index) && (Int32.TryParse(result[6 + index], out temp))){
        if(temp == 1 && !LastButton[index]){
          return true;
        } else {
          return false;
        }
      } else {
        return false;
      }
    }

    public bool ButtonPressedUp(int index){
      int temp = 0;
      if((result.Length > 6 + index) && (Int32.TryParse(result[6 + index], out temp))){
        if(temp == 0 && LastButton[index]){
          return true;
        } else {
          return false;
        }
      } else {
        return false;
      }
    }
   
    void OnApplicationQuit()
    {
      if(port.IsOpen){
        port.Close();
      }
    }

    public void ClosePort() {
        if (port.IsOpen) {
            port.Close();
        }
    }

    public void SendError() {
        if (port.IsOpen) {
            port.Write("1");
        }
    }



}
