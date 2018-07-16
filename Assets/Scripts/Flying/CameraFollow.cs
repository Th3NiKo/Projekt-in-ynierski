
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public bool Follow = true;


	void LateUpdate(){
		if(Follow){
			 transform.position = target.position + offset;
		} else {
			transform.position = offset;
			transform.position = new Vector3(this.transform.position.x,
											 this.transform.position.y,
											 this.transform.position.z - 7);
		}
	}
}
