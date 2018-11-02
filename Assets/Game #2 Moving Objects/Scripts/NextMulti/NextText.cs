using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextText : MonoBehaviour {

	PlayText text;
	MessageReceiver msg;
	void Start () {
		text = transform.parent.GetChild(0).GetComponent<PlayText>();
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.name == "Cursor"){
			if(Input.GetKeyDown(KeyCode.Space) || msg.ButtonPressedDown(0)){
				if(text.actualIndex + 1 >= text.allBooks.Count){
					text.TextSet(0);
				} else {
					text.TextSet(text.actualIndex+1);
				}
			}
		}
	}
}
