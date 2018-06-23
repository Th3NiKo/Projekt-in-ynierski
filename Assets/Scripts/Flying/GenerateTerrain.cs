﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {

	public int heightScale = 5;
	public float detailScale = 5.0f;

	void Start () {
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		for(int v = 0; v < vertices.Length; v++){
			vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale, 
												(vertices[v].z + this.transform.position.z) / detailScale) * heightScale;
			if(vertices[v].y <= heightScale / 2){
				vertices[v].y  = 7.5f;
			}
 		}
		 mesh.vertices = vertices;
		 mesh.RecalculateBounds();
		 mesh.RecalculateNormals();
		 this.gameObject.AddComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
