using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationReset : MonoBehaviour {

    public bool DoResetPos = false;
    COM com;
    public Vector3 startingPosition;
    void Start () {
        com = Camera.main.GetComponent<COM>();
    }
	
	
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            com.SendError();
            if(DoResetPos) this.transform.position = startingPosition;
        }
    }
}
