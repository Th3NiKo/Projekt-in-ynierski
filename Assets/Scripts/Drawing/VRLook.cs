using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLook : MonoBehaviour {

    public Camera cam1;
    private bool follow = true;
    private bool temporary = false;
    public Transform target;
    public Vector3 offset;

    private Vector3 startingPosition;


    COM com;
    DrawVR draw;

    void Start() {
        startingPosition = this.transform.parent.position;
        
        com = Camera.main.GetComponent<COM>();
        draw = GameObject.Find("Tube").GetComponent<DrawVR>();
        if (target == null) {
            target = GameObject.Find("Kursor").transform;
        }
    }


    void Update() {
        
        if (Input.GetKeyDown(KeyCode.C)) {
            follow = !follow;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            //  Vector3 newPos = startingPosition - Camera.main.transform.position;
            //  this.transform.parent.position = newPos;
            UnityEngine.XR.InputTracking.Recenter();
        }

        if (Input.GetKeyDown(KeyCode.V)) {
            if (cam1.gameObject.activeSelf) {
                //Camera.main.GetComponent<Camera>().enabled = true;
                cam1.gameObject.SetActive(false);
            }
            else {
               // Camera.main.GetComponent<Camera>().enabled = false;
                cam1.gameObject.SetActive(true);
            }
        }

        //2 button
        if (!draw.Keyboard && !com.IsWritingPen()) {
            if ((com.ButtonPressed(1) || Input.GetKey(KeyCode.X)) && !com.ButtonPressed(0)) {
                temporary = true;
            }
            if (com.ButtonPressedUp(1) || Input.GetKeyUp(KeyCode.X)) {
                temporary = false;
            }
        }

        //Writing pen
        if (!draw.Keyboard && com.IsWritingPen()) {
            if (Input.GetKey(KeyCode.X) && (!com.ButtonPressed(0))) {
                temporary = true;
            }
            if (Input.GetKeyUp(KeyCode.X)) {
                temporary = false;
            }
        }

        //Keyboard
        if (draw.Keyboard) {
            if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z)) {
                temporary = true;
            }
            if (Input.GetKeyUp(KeyCode.X)) {
                temporary = false;
            }
        }
    }
    void LateUpdate() {
        if (follow && !temporary) {
            if (target != null)
                this.transform.position = target.position + offset;
            //this.transform.parent.rotation = this.transform.rotation;
        }
    }

}
