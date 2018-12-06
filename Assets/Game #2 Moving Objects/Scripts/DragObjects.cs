using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragObjects : MonoBehaviour {

	public GameObject coliding;
	public Animator handAnimator;
	Transform colidingParent = null;

	//Throwing objects
	MessageReceiver msg;
	CursorOnBox1 box;
	Vector3[] lastDelta;

	bool spacePressed;

	public bool Keyboard = true;
	void Start(){
		box = GameObject.Find("Cursor").GetComponent<CursorOnBox1>();
		spacePressed = false;
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
		lastDelta = new Vector3 [5];
		for(int i = 0;i < 5; i++){
			lastDelta[i] = Vector3.zero;
		}
	}

	// Update is called once per frame
	void Update () {
		
		
		for(int i = 0;i < 3; i++){
			lastDelta[i] = lastDelta[i+1];
		}
		if(coliding != null){
			handAnimator.SetBool("isGrabbing", true);
		} else {
			handAnimator.SetBool("isGrabbing", false);
		}
		if(Keyboard){
			if (Input.GetKey (KeyCode.Space)) {
				Grab();
			} if(Input.GetKeyUp(KeyCode.Space)){
				Drop();
			}
		} else {
			if (msg.ButtonPressed(0) || Input.GetKey(KeyCode.Space)) {
				Grab();
			} if(msg.ButtonPressedUp(0) || Input.GetKey(KeyCode.Space)){
				Drop();
			}
		}
		lastDelta[4] = msg.LoadDeltas();
	}


	void Grab(){
		if (coliding != null) {
			Quaternion tempRotation = coliding.transform.rotation;
			Vector3 tempScale = coliding.transform.lossyScale;
			colidingParent = coliding.transform.parent;
			coliding.GetComponent<Rigidbody> ().isKinematic = true;
			coliding.transform.SetParent (this.transform,true);
			SetGlobalScale (coliding.transform, tempScale);
			coliding.transform.rotation = tempRotation;
		} 
		spacePressed = true;
	}

	void Drop(){
		if (coliding != null) {
			if (coliding.gameObject.tag == "Dragable") {
				coliding.GetComponent<Rigidbody> ().useGravity = true;
				coliding.GetComponent<Rigidbody> ().isKinematic = false;
				Vector3 forcePower = new Vector3(0,0,0);
				for(int i = 0; i < 5; i++){
					forcePower += lastDelta[i];
				}
				forcePower/= 5;
                if (SceneManager.GetActiveScene().name == "VR") {
                    forcePower *= (1000.0f / box.Divide);

                }
                else {
                     forcePower *= (350.0f / box.Divide);
                }
				coliding.GetComponent<Rigidbody> ().velocity = new Vector3(forcePower.x, forcePower.y, -forcePower.z);
				if(coliding.GetComponent<Dart>() != null){
					//StartCoroutine(Camera.main.GetComponent<CameraManager>().cameraFollow(coliding, 3));
				}
               
			}
			coliding.transform.SetParent (null);
			coliding = null;
		}
	}


	void LateUpdate() {
		SecureOneObject();
	}

	void OnTriggerStay(Collider col){
		if (coliding == null) {
			if (col.gameObject.tag == "Dragable" || col.gameObject.tag == "Dragable - No Gravity") {
				coliding = col.gameObject;
			} else {
				coliding = null;
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Dragable" || other.gameObject.tag == "Dragable - No Gravity"){
			other.transform.parent = null;
			coliding = null;
		}
	}

	void SecureOneObject(){
		//Check if same object is holding by hand
		if(transform.childCount > 1 && (transform.GetChild(1).name != coliding.name)){
			//Repair its kinematic
			transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
			transform.GetChild(1).parent = null;
			coliding.transform.parent = this.transform;
		}

		//Unplug all other objects
		while(transform.childCount > 2){
			transform.GetChild(transform.childCount - 1).transform.parent = null;
		}
	}


	private void SetGlobalScale(Transform transform, Vector3 globalScale){
		transform.localScale = Vector3.one;
		transform.localScale = new Vector3 (globalScale.x/transform.lossyScale.x, globalScale.y/ transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
	}
	
}

