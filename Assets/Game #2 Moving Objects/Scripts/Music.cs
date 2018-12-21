using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayMusicTest : MonoBehaviour {

	/* Playing music from Music folder when player is coliding and pressed space. Space is for switch
	 * Could be speaker with anim when plaing. 
	 * 
	 * */

	public List<AudioClip> allMusic;
	public GameObject soundEffect; //Particles as effect of playing music
	AudioSource player;
	public int actualIndex;
	void Start () {
		actualIndex = 0;
		player = GetComponent<AudioSource> ();
		StartCoroutine (LoadMusic());
	}


	IEnumerator LoadMusic(){
		string[] paths = Directory.GetFiles (Application.streamingAssetsPath, "*.wav");
		for (int i = 0; i < paths.Length; i++) {
			WWW diskDirectory = new WWW ("file://" + paths[i]);
			while(!diskDirectory.isDone){
				yield return null;
			}
			AudioClip temp = diskDirectory.GetAudioClip();
			temp.name = Path.GetFileName(diskDirectory.url);
			allMusic.Add (temp);
		}
		MusicPlay (0);
	}

	public void MusicPlay(int index){
		actualIndex = index;
		if(player.isPlaying){
			player.clip = allMusic[index];
			player.Play();
		} else {
			player.clip = allMusic[index];
		}
		
		
		player.loop = true;
	}

	public void MusicStop(){
		player.Stop ();
		soundEffect.SetActive(false);
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.name == "Cursor") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (player.isPlaying) {
					player.Stop ();
					soundEffect.SetActive(false);
				} else {
					player.Play ();
					soundEffect.SetActive(true);
				}
			}
		}
	}

}
