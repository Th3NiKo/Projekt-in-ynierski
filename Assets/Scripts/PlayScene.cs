using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour {

	public int SceneNumber = 0;
	Kursor3D kursor;
	private Quaternion startRotation;
	void Start () {
		startRotation = transform.rotation;
		kursor = GameObject.Find("Kursor3D").GetComponent<Kursor3D>();
		
	}
	
	
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if(other.name == "Kursor3D"){
			//Play anim
			transform.Rotate(0.0f, 2.0f, 0.0f);
			if(kursor.IsPressed()){
				SceneManager.LoadScene(SceneNumber);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name == "Kursor3D"){
			//Go to starting rotation
			transform.rotation = startRotation;

		}
	}
}
