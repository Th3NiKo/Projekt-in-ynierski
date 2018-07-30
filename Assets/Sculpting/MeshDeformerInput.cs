﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerInput : MonoBehaviour {

	public float forceOffset = 0.1f;
	public float force = 10f;

	void Update () {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}

	void HandleInput(){
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(inputRay, out hit)) {
			MeshDeformation deformer = hit.collider.GetComponent<MeshDeformation>();
			if (deformer) {
				Vector3 point = hit.point;
				//point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
		}
	}
}
