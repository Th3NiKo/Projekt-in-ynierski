using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationReset2 : MonoBehaviour
{

    MessageReceiver msg;
    void Start()
    {
        msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            msg.SendError();
        }
    }
}
