using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour {

	// Use this for initialization

	new public Camera camera;
	public bool zooming = true;
    public float zoomSpeed;
 private bool _inputLocked;
 public float inputlockingTime = 1f;
 void UnlockInput(){
     _inputLocked = false;
 }
 void LockInput(){
     _inputLocked = true;
     Invoke("UnlockInput",inputlockingTime);
 }
 public bool isInputLocked(){
     return _inputLocked;
 }
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Input.GetMouseButton(0) && !isInputLocked()){
		RaycastHit hit;
		Ray ray  = camera.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray,out hit)){
			
			camera.transform.position =new Vector3(camera.transform.position.x,hit.transform.position.y,camera.transform.position.z);
			camera.transform.LookAt(hit.transform);
			Transform obk=hit.transform;
			var t=obk.GetComponent<MeshRenderer>();
			t.material.color=Color.green;
			//camera.transform.position=hit.transform.position;
		


		    if (zooming) {
            
            float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            camera.transform.Translate(ray.direction * zoomDistance, Space.World);
        }
		}
		LockInput();
		}
	}
}
