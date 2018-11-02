using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public GameObject cameraBoard;
	public GameObject cameraDart;

	public Vector3 offset = new Vector3(9.25f,0.5f,-4.5f);
	void Start () {
		cameraBoard.SetActive(false);
		cameraDart.SetActive(false);
	}
	
	
	void Update () {
		if(cameraDart.activeSelf){
             cameraDart.transform.rotation = Quaternion.Euler(0,24,0);
		}
		
	}



	public IEnumerator cameraFollow(GameObject dart, float duration){
		//Turn on camera
		cameraDart.SetActive(true);
		cameraDart.transform.parent = dart.transform;
		cameraDart.transform.localPosition = new Vector3(0,0,0) + offset;

		yield return new WaitForSeconds(duration);
		cameraDart.transform.parent= null;
		cameraDart.SetActive(false);


	}
}
