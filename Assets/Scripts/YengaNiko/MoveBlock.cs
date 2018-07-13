using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

	GameObject actualBlock;
	float rot;
	void Start () {
		Physics.gravity = new Vector3(0,-2.5f,0);
	}

	void Update(){

		if(actualBlock != null){
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				actualBlock.AddComponent(typeof(FixedJoint));
				actualBlock.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
				actualBlock.GetComponent<FixedJoint>().massScale = 10f;
				actualBlock.GetComponent<FixedJoint>().connectedMassScale = 10f;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				Destroy(actualBlock.GetComponent<FixedJoint>());
			}
			//if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space)){
			//	actualBlock.transform.rotation = Quaternion.Euler(-90,this.transform.root.eulerAngles.y ,0);
		//	}
		}
	}

	private void OnTriggerStay(Collider other) {
		if(other.tag == "Block"){
			actualBlock = other.gameObject;
		}
	}
}
