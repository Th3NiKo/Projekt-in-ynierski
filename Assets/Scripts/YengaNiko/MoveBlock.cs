using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

	GameObject actualBlock;
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update(){

		if(actualBlock != null){
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				actualBlock.AddComponent(typeof(FixedJoint));
				actualBlock.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
				actualBlock.GetComponent<FixedJoint>().massScale = 1f;
				actualBlock.GetComponent<FixedJoint>().connectedMassScale = 1f;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				Destroy(actualBlock.GetComponent<FixedJoint>());
				//actualBlock.GetComponent<FixedJoint>().connectedBody = null;
			}
		}
	}

	private void OnTriggerStay(Collider other) {
		if(other.tag == "Block"){
			actualBlock = other.gameObject;
		}
	}
}
