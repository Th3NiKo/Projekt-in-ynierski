using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameOnTrigger : MonoBehaviour {

	PlayImageTest img;
	PlayVideoTest video;
	PlayMusicTest music;

	public TextMesh text;
	
	void Start () {
		if(GetComponent<PlayImageTest>() != null){
			img = GetComponent<PlayImageTest>();
		} else if(GetComponent<PlayVideoTest>() != null){
			video = GetComponent<PlayVideoTest>();
		} else if(GetComponent<PlayMusicTest>() != null){
			music = GetComponent<PlayMusicTest>();
		}
	}
	
	void OnTriggerStay(Collider col){
		if (col.name == "Cursor") {
			text.gameObject.SetActive(true);
			if(img != null){
				text.text = img.allImages[img.actualIndex].name;
			} else if(video != null){
				text.text = video.allVideos[video.actualIndex].name;
			} else if(music != null){
				text.text = music.allMusic[music.actualIndex].name;
			}
			
		} 
	}

	void OnTriggerExit(Collider col){
		if (col.name == "Cursor") {
			text.gameObject.SetActive(false);
		}
	}
}
