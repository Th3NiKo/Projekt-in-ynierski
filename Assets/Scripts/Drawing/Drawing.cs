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
	GameObject kursorHelper;
	bool pressed;

	//Spline spline;
	Vector3 lastPosition;

	void Start(){
		kursor = transform.GetComponentInParent<Kursor3D>();
		pressed = false;
		//trail = GetComponent<TrailRenderer>();
	//	spline = GetComponent<Spline>();
		lastPosition = this.transform.position;
		size = new Vector3(thickness,smooth,thickness);
		ballSize = new Vector3(thickness,thickness,thickness);
		kursorHelper = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		kursorHelper.name = "Helper";
	}
	void Update () {
		if(kursor.IsPressed()){
			if(pressed == false){
				pressed = true;
			}
			
			//trail.time = Mathf.Infinity;
			if(Vector3.Distance(lastPosition, this.transform.position) >= (size.y*1.7f)){
				
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
				
				Vector3 rotateBy = lastPosition - this.transform.position;
				cylinder.transform.rotation = Quaternion.LookRotation(rotateBy);
				cylinder.transform.Rotate(90,0,0);
				lastPosition = this.transform.position;
				
				
			}
		}  else {
			if(pressed){
				GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				sphere.transform.position = lastPosition;
				sphere.transform.localScale = ballSize;
				sphere.GetComponent<MeshRenderer>().material = material;
			}
		
			kursorHelper.GetComponent<MeshRenderer>().material = material;
			
			Vector3 rotateBy = lastPosition - this.transform.position;
			kursorHelper.transform.rotation = Quaternion.LookRotation(rotateBy);
			
			kursorHelper.transform.Rotate(90,0,0);
			kursorHelper.transform.position = this.transform.position;
			kursorHelper.transform.localScale = size;
			lastPosition = this.transform.position;
			pressed = false;
		}
		

	}



	public void changeThickness(float thick){
		thickness = thick;
		size = new Vector3(thickness,smooth,thickness);
		ballSize = new Vector3(thickness,thickness,thickness);
	}
}
