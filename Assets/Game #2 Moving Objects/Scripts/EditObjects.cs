using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditObjects : MonoBehaviour {


	/*	Scaling things on shift pressed
	 * 
	 * 
	 * 
	 * */

	MessageReceiver msg;
	bool pressed;
	Rigidbody rgb;
	Vector3 startPosition;
	GameObject coliding;
	Vector3 colidingScale;

	float sensitivity = 0.8f;

	public bool Keyboard = true;

	void Start(){
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
	}

	void Update () {
	
		if (pressed) {
			if (coliding != null) {
				Vector3 scale =this.transform.position - startPosition;
				scale = new Vector3 (Mathf.Abs(scale.x* sensitivity + colidingScale.x),
															 Mathf.Abs(scale.y* sensitivity + colidingScale.y),
															 Mathf.Abs(scale.z* sensitivity + colidingScale.z));
			
				//coliding.transform.localScale = new Vector3 (Mathf.Abs(scale.x* sensitivity + colidingScale.x),
					//										 Mathf.Abs(scale.z* sensitivity + colidingScale.z),
						//									 Mathf.Abs(scale.y* sensitivity + colidingScale.y));

				float scaleX = coliding.transform.position.x-(coliding.transform.lossyScale.x / 2);
				float scaleY = coliding.transform.position.y-(coliding.transform.lossyScale.y / 2);
				float scaleZ = coliding.transform.position.z-(coliding.transform.lossyScale.z / 2);
				ScaleAround(coliding, new Vector3(scaleX,scaleY,scaleZ), scale);
			}
		} 
		if(Keyboard){
			if (!Input.GetKey (KeyCode.LeftShift)) {
				coliding = null;
				pressed = false;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				this.transform.position = startPosition;
			}
		} else {
			if (!msg.ButtonPressed(1)) {
				coliding = null;
				pressed = false;
			}
			if(msg.ButtonPressedUp(1)){
				this.transform.position = startPosition;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.tag == "Dragable" || col.tag == "Dragable - No Gravity"){
			if(Input.GetKey(KeyCode.Delete)){
				Destroy(col.gameObject);
			}

			if(Keyboard){
				if (Input.GetKeyDown (KeyCode.LeftShift)) {
					pressed = true;
					startPosition = this.transform.position;
					colidingScale = col.transform.localScale;
					coliding = col.gameObject;
				} 
				if (Input.GetKeyUp (KeyCode.LeftShift)) {
					pressed = false;
					coliding = null;
				}
			} else {
				if (msg.ButtonPressedDown(1)) {
					pressed = true;
					startPosition = this.transform.position;
					colidingScale = col.transform.localScale;
					coliding = col.gameObject;
				} 
				if (msg.ButtonPressedUp(1)) {
					pressed = false;
					coliding = null;
				}
			}
		}
	}


public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
{
    Vector3 A = target.transform.localPosition;
    Vector3 B = pivot;
 
    Vector3 C = A - B; // diff from object pivot to desired pivot/origin
 
    float RS = newScale.x / target.transform.localScale.x; // relative scale factor
 
    // calc final position post-scale
    Vector3 FP = B + C * RS;
 
    // finally, actually perform the scale/translation
    target.transform.localScale = newScale;
    target.transform.localPosition = FP;
}


}
