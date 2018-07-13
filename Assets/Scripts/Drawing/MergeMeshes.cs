using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MergeMeshes : MonoBehaviour {

	MeshFilter meshFilter;
	void Start () {
		meshFilter = GetComponent<MeshFilter>();
	}
	
	
	void Update () {
		GameObject [] allMeshes = GameObject.FindGameObjectsWithTag("Mesh");
	
		if(allMeshes.Length > 1){
			CombineInstance[] meshes = new CombineInstance[allMeshes.Length];
			Mesh finalMesh = new Mesh();
			for(int i = 0; i < allMeshes.Length; i++){

				meshes[i].mesh = allMeshes[i].GetComponent<MeshFilter>().sharedMesh;
				meshes[i].transform = allMeshes[i].GetComponent<MeshFilter>().transform.localToWorldMatrix;
				//allMeshes[i].SetActive(false);
			}
			finalMesh = new Mesh();
			finalMesh.CombineMeshes(meshes, true);
			meshFilter.sharedMesh = finalMesh;
			
		}
	}
}
