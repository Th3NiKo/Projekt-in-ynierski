using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secondcamera : MonoBehaviour {

    public GameObject cam1;
	void Start () {
		
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.V)) {
            if (cam1.gameObject.activeSelf) {
                cam1.gameObject.SetActive(false);
            }
            else {
                cam1.gameObject.SetActive(true);
            }
        }
    }
}
