using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercCursorMarker : MonoBehaviour {

    public Transform followObject;

	void Update () {
        this.transform.position = new Vector3(followObject.position.x,this.transform.position.y,followObject.position.z);
	}
}
