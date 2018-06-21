using System;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;


public class GetPositionsCOM : MonoBehaviour
{


    public enum Device { Ufo, Pen }
    SerialPort port;


    //String change
    string[] stringSeparators = new string[] { "\n" };
    public string[] result;
    Device actualDevice = Device.Ufo;
    int lastLength = 0;

    private Vector3 lastPosition;

    //For buttons only
    private bool[] LastButton;


    bool wiritngPen;

    string comName;
    void Start()
    {
        wiritngPen = false;
        //Two buttons set to 0 at start
        LastButton = new bool[2];
        LastButton[0] = false;
        LastButton[1] = false;
        result = new string[] { "0", "0", "0", "0", "0" };
        lastPosition = new Vector3(0, 0, 0);
        if (SerialPort.GetPortNames().Length > 0)
            comName = SerialPort.GetPortNames()[0];


        for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
        {
            port = new SerialPort(SerialPort.GetPortNames()[i], 9600, Parity.None, 8, StopBits.One);
            if (!port.IsOpen)
            {
                port.Open();
                if (port.BytesToRead != 0)
                {

                    byte[] data = new byte[1024];
                    int bytesRead = port.Read(data, 0, data.Length);
                    string message = Encoding.ASCII.GetString(data, 0, bytesRead);

                    result = message.Split(stringSeparators, StringSplitOptions.None);
                    if (result.Length > 5)
                    {
                        comName = SerialPort.GetPortNames()[i];
                        break;
                    }
                }


            }
        }


        lastLength = SerialPort.GetPortNames().Length;

        port.RtsEnable = true;

        if (!port.IsOpen)
        {
            port.Open();
        }

        port.ReadTimeout = 50;

    }
    }