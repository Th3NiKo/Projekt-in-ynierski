using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextVideo : MonoBehaviour {

	PlayVideoTest video;
	MessageReceiver msg;
	
	void Start () {
		video = transform.parent.GetComponent<PlayVideoTest>();
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.name == "Cursor"){
			if(Input.GetKeyDown(KeyCode.Space) || msg.ButtonPressedDown(0)){
				if(video.actualIndex + 1 >= video.allVideos.Count){
					video.MoviePlay(0);
				} else {
					video.MoviePlay(video.actualIndex+1);
				}
			}
		}
	}

	
}
