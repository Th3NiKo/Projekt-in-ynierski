using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayImageTest : MonoBehaviour {

	public List<Texture> allImages;
	public int actualIndex;

	void Start () {
		StartCoroutine (LoadImages());
		actualIndex = 0;
	}


	IEnumerator LoadImages(){
		string[] pathsPng = Directory.GetFiles (Application.streamingAssetsPath, "*.png ");
		string[] pathsJpg = Directory.GetFiles (Application.streamingAssetsPath, "*.jpg ");
		
		//Combine arrays
		string[] paths = new string[pathsPng.Length + pathsJpg.Length];
		Array.Copy(pathsPng,paths, pathsPng.Length);
		Array.Copy(pathsJpg, 0, paths, pathsPng.Length, pathsJpg.Length);

		
		for (int i = 0; i < paths.Length; i++) {
			WWW diskDirectory = new WWW ("file://" + paths[i]);
			while(!diskDirectory.isDone){
				yield return null;
			}
			Texture temp = diskDirectory.texture;
			temp.name = Path.GetFileName(diskDirectory.url);
			allImages.Add (temp);
		}
		ImageSet (0);
	}

	public void ImageSet(int index){
		actualIndex = index;
		Renderer rend;
		rend = GetComponent<Renderer> ();
		rend.material.SetTexture ("_MainTex", allImages[index]);
	}


}