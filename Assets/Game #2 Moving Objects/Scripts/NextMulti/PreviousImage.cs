using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousImage : MonoBehaviour {

	
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
				if(image.actualIndex - 1 < 0){
					image.ImageSet(image.allImages.Count - 1);
				} else {
					image.ImageSet(image.actualIndex-1);
				}
			}
		}
	}
}
