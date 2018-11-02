using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMusic : MonoBehaviour {

	// Use this for initialization
	PlayMusicTest music;
	MessageReceiver msg;
	void Start () {
		music = transform.parent.GetComponent<PlayMusicTest>();
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.name == "Cursor"){
			if(Input.GetKeyDown(KeyCode.Space) || msg.ButtonPressedDown(0)){
				if(music.actualIndex + 1 >= music.allMusic.Count){
					music.MusicPlay(0);
				} else {
					music.MusicPlay(music.actualIndex+1);
				}
			}
		}
	}
}
