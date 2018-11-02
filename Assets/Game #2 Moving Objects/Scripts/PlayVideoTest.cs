using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayVideoTest : MonoBehaviour {
	

	public List<MovieTexture> allVideos;
	public int actualIndex;
	void Start () {
		StartCoroutine (LoadVideos());
		actualIndex = 0;
	}
	
	IEnumerator LoadVideos(){
		string[] paths = Directory.GetFiles (Application.streamingAssetsPath, "*.ogv");
		for (int i = 0; i < paths.Length; i++) {
			WWW diskDirectory = new WWW ("file://" + paths[i]);
			while(!diskDirectory.isDone){
				yield return null;
			}
			MovieTexture temp = diskDirectory.GetMovieTexture();
			temp.name = Path.GetFileName(diskDirectory.url);
			allVideos.Add (temp);
			diskDirectory.Dispose();
		}
		MoviePlay (0);

	}

	public void MoviePlay(int index){
		actualIndex = index;
		Renderer rend;
		rend = GetComponent<Renderer> ();
		rend.material.SetTexture ("_MainTex", allVideos[index]);
		allVideos [index].Play ();
		allVideos [index].loop = true;
	}

}
