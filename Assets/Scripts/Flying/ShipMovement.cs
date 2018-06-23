using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipMovement : MonoBehaviour {

	Kursor3D kursor;

	public float CursorErrorFix = 0.0f;
	public float smoothRotation = 1.0f;
	public float maxSpeed = 2000f;

	public static bool canMove = true;
	void Start () {
		Time.timeScale = 1.0f;
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
		canMove = true;
	}
	

	void Update () {
		if(canMove){
			//Fixing too much noise
			float _x = kursor.delta.x;
			float _y = kursor.delta.y;
			float _z = kursor.anglesDelta.y;
			if((_x < CursorErrorFix && _x > 0) || (_x < 0 && _x > -CursorErrorFix)){
				_x = 0;
			}  else if(_x > maxSpeed){
				_x = maxSpeed;
			} else if(_x < -maxSpeed){
				_x = -maxSpeed;
			}
			if((_y < CursorErrorFix && _y > 0) || (_y < 0 && _y > -CursorErrorFix)){
				_y = 0;
			} else if(_y > maxSpeed){
				_y = maxSpeed;
			} else if(_y < -maxSpeed){
				_y = -maxSpeed;
			}
			if((_z < CursorErrorFix && _z > 0) || (_z < 0 && _z > -CursorErrorFix)){
				_z = 0;
			} else if(_z > maxSpeed){
				_z = maxSpeed;
			} else if(_z < -maxSpeed){
				_z = -maxSpeed;
			}
			//Transforming position of plane acording to Controler
			transform.position += new Vector3(_x / 10000, _y / 10000, _z / 10000 ) *  -18.0f;
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -8.0f, 6.0f), transform.position.z);
		
			//Check how to rotate ship.
			float z = 0.0f;
			float y = 0.0f;
			float x = 0.0f;

			if(_x > 0){
				z -= 15;
			} else if (_x < 0){
				z += 15;
			} else {
				z = 0;
			}	
			
			if(_y > 0){
				x = 190;
			} else if (_y < 0){
				x = 170;
			} else {
				x = 180;
			}
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(x,0,z), smoothRotation *Time.deltaTime);

			if(_z > 0){
				y += 0.4f;
			} else if (_z < 0){
				y -= 0.4f;
			} 

			} else{
				if(kursor.IsPressed()){
					ShipStats.ResetPoints();
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
			}

	}
}
