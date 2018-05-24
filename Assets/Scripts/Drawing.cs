using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour {

	Kursor3D kursor;
	//TrailRenderer trail;
	public GameObject line;
	bool toDraw = false;
	Vector3 size;
	Vector3 ballSize;
	public Material material;
	public float smooth = 0.03f;
	public float thickness = 0.15f;

	//Spline spline;
	Vector3 lastPosition;

	void Start(){
		kursor = transform.GetComponentInParent<Kursor3D>();
		//trail = GetComponent<TrailRenderer>();
	//	spline = GetComponent<Spline>();
		lastPosition = this.transform.position;
		size = new Vector3(thickness,smooth,thickness);
		ballSize = new Vector3(thickness,thickness,thickness);
	}
	void Update () {
		if(kursor.IsPressed()){
			
			//trail.time = Mathf.Infinity;
			if(Vector3.Distance(lastPosition, this.transform.position) >= (size.y*2)){
				
				//Draw
				GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				//Spheres on finish and start
				GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				sphere.transform.position = lastPosition;

	
				sphere.transform.localScale = ballSize;
				sphere.GetComponent<MeshRenderer>().material = material;


				//Cylinder position
				cylinder.transform.position = Vector3.Lerp(lastPosition, this.transform.position,0.5f);
				cylinder.transform.localScale = size;
				cylinder.GetComponent<MeshRenderer>().material = material;

				//Cylinder rotation
				Vector3 rotateBy = Vector3.RotateTowards(Vector3.up, lastPosition - this.transform.position,10.0f, 0.0f);
				cylinder.transform.rotation = Quaternion.LookRotation(rotateBy);
				cylinder.transform.Rotate(90,0,0);
				lastPosition = this.transform.position;
				
			}
		}  else {
			lastPosition = this.transform.position;
		}
		

	}



	public void changeThickness(float thick){
		thickness = thick;
		size = new Vector3(thickness,smooth,thickness);
		ballSize = new Vector3(thickness,thickness,thickness);
	}
}
