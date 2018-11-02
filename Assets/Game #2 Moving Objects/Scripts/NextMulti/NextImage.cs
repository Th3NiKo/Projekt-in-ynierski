using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextImage : MonoBehaviour {

	// Use this for initialization
	PlayImageTest image;
	MessageReceiver msg;
	void Start () {
		image = transform.parent.GetComponent<PlayImageTest>();
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.name == "Cursor"){
			if(Input.GetKeyDown(KeyCode.Space) || msg.ButtonPressedDown(0)){
				if(image.actualIndex + 1 >= image.allImages.Count){
					image.ImageSet(0);
				} else {
					image.ImageSet(image.actualIndex+1);
				}
			}
		}
	}
}
