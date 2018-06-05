using System.IO.Ports;
using UnityEngine;
using System.Threading;

public class COM : MonoBehaviour {
  

  
    SerialPort port;
    SerialPort port2;
    int counter = 0;

    void Start(){
      port = new SerialPort( "\\\\.\\COM1", 9600, Parity.None, 8, StopBits.One);
      port2 = new SerialPort( "\\\\.\\COM2", 9600, Parity.None, 8, StopBits.One);
      if(!port.IsOpen){
        port.Open();
        port2.Open();
      }
     
     port.ReadTimeout = 500;
     port2.ReadTimeout = 500;


    }
    

	  void Update(){
        port2.WriteLine(counter.ToString());
        counter++;
        if(port.IsOpen){  
          try{

            string message = port.ReadLine();
            if(message != null){
               Debug.Log(message);
            }

          } catch{
            throw;
          }
        }
	  }


   
  }
