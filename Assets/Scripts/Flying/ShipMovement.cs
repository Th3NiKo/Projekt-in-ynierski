using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipMovement : MonoBehaviour {

	Kursor3D kursor;

	public float smooth = 1.0f;
	public GameObject meteor;
	MeteorFly meteorFly;
	MeteorSpawner meteorSpawner;
	public static bool canMove = true;
	void Start () {
		Time.timeScale = 1.0f;
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
		meteorFly = meteor.GetComponent<MeteorFly>();
		meteorSpawner = GameObject.Find("MeteorSpawner").GetComponent<MeteorSpawner>();
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove){
			transform.position += new Vector3(kursor.delta.x, kursor.delta.y, kursor.delta.z) *  -18.0f;
			transform.position = new Vector3(Mathf.Clamp(transform.position.x,0.0f, 12.0f), Mathf.Clamp(transform.position.y, 0.0f, 10.0f), transform.position.z);
		
		float z = 0.0f;
		float y = 0.0f;
		float x = 0.0f;
		if(kursor.delta.x > 0){
			z -= 15;
		} else if (kursor.delta.x < 0){
			z += 15;
		} else {
			z = 0;
		}	
		

		if(kursor.delta.y > 0){
			x = 190;
		} else if (kursor.delta.y < 0){
			x = 170;
		} else {
			x = 180;
		}
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(x,0,z),smooth *Time.deltaTime);

		if(kursor.delta.z > 0){
			y += 0.4f;
		} else if (kursor.delta.z < 0){
			y -= 0.4f;
		} 
		/* 
		foreach(GameObject meteor in GameObject.FindGameObjectsWithTag("Meteor")){
			if(meteor.GetComponent<MeteorFly>() != null)
				meteor.GetComponent<MeteorFly>().speed -= y;
		}
		meteorSpawner.SpeedChange(y); */
		} else{
			if(kursor.IsPressed()){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

	}
}
