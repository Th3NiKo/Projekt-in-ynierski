using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTest : MonoBehaviour {

	public GameObject kursor;
	TubeRenderer tube;
	List <Vector3> points;
	Vector3 lastPosition;

	public Material [] allMats;
	int actualMaterial = 0;
	public Material mat;

	public float actualRadius = 0.1f;
	
	void Start () {
		tube = GetComponent<TubeRenderer>();
		points = new List<Vector3>();
		lastPosition = kursor.transform.position;
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			
		}

		if(Input.GetKey(KeyCode.LeftShift)){
			this.gameObject.GetComponent<Renderer>().enabled = true;
				if(Vector3.Distance(lastPosition, kursor.transform.position) >= (0.04f)){
					points.Add(kursor.transform.position);
					tube.SetPoints(points.ToArray(), actualRadius, Color.white);
					tube.material = allMats[actualMaterial];
					lastPosition = kursor.transform.position;
				}
			
		} else {
			tube.vertices = null;
		}

		if(Input.GetKeyUp(KeyCode.LeftShift)){
			GameObject line = new GameObject();
			line.AddComponent(typeof(MeshFilter));
			line.AddComponent(typeof(MeshRenderer));
			line.AddComponent(typeof(MeshCollider));
			
			line.gameObject.name = "Mesh";
			line.transform.position = this.transform.position;

			if(GetComponent<MeshFilter>().sharedMesh != null)
			line.GetComponent<MeshFilter>().sharedMesh = (Mesh) Instantiate(GetComponent<MeshFilter>().sharedMesh);
			line.GetComponent<MeshCollider>().sharedMesh = line.GetComponent<MeshFilter>().sharedMesh;
			line.GetComponent<MeshRenderer>().material = (Material)Instantiate(GetComponent<MeshRenderer>().material);
			actualMaterial++;
			if(actualMaterial >= allMats.Length){
				actualMaterial = 0;
			}
			points.Clear();
			
		}
		
	}


	public void changeThickness(float thick){
		actualRadius = thick;
	}


}
