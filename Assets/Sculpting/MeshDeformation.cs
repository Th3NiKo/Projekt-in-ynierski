using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformation : MonoBehaviour {

	Mesh deformingMesh;
	Vector3[] originalVertices, displacedVertices;
	Vector3[] vertexVelocities;

	
	void Start () {
		deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
		for (int i = 0; i < originalVertices.Length; i++) {
			displacedVertices[i] = originalVertices[i];
		}
		vertexVelocities = new Vector3[originalVertices.Length];
	}
	
	
	void Update () {
		deformingMesh.vertices = displacedVertices;
		deformingMesh.RecalculateNormals();
		deformingMesh.RecalculateBounds();
		Destroy(this.GetComponent<SphereCollider>());
		this.gameObject.AddComponent(typeof(SphereCollider));
	}

	public void AddDeformingForce (Vector3 point, float force) {
		Debug.DrawLine(Camera.main.transform.position, point);
		for (int i = 0; i < displacedVertices.Length; i++) {
			AddForceToVertex(i, point, force);
		}
	}

	
	void AddForceToVertex (int i, Vector3 point, float force) {
		
		if(Vector3.Distance(point, displacedVertices[i]) < 0.90f){
			Vector3 pointToVertex =  point.normalized - displacedVertices[i].normalized;
			float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
			displacedVertices[i] = point * force;
		}
	}
}
