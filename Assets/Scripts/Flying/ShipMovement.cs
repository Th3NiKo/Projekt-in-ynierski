using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipMovement : MonoBehaviour {

	public float smoothRotation = 1.0f;


	public static bool canMove = true;
	[SerializeField] Vector2 position;
	[SerializeField] Vector3 angles;
	[Range(0,50000)] public float sensitivity = 10000;
	COM msg;
	Rigidbody rgb;


	void Start(){
		position = new Vector2 (0, 0);
		angles = new Vector3 (0,0,0);
		msg = Camera.main.GetComponent<COM>();
		rgb = GetComponent<Rigidbody> ();
		Time.timeScale = 1.0f;
		canMove = true;
	}
	

	void Update () {
		
		if(canMove){
			position = msg.LoadPositions ();
			angles = msg.LoadAngles ();
			rgb.velocity = new Vector3 (position.x / sensitivity, position.y / sensitivity, -angles.z / sensitivity);
			float _x = rgb.velocity.x;
			//float _y = rgb.velocity.y;
			float _z = rgb.velocity.z;
			//Check how to rotate ship.
			float z = 0.0f;
			float x = 0.0f;

			if(_x > 0){	
				z += 15;
			} else if (_x < 0){
				z -= 15;
			} else {
				z = 0;
			}	
			
			if(_z > 0){
				x = 190;
			} else if (_z < 0){
				x = 170;
			} else {
				x = 180;
			}
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(x,0,z), smoothRotation *Time.deltaTime);

			} else{
				if(Input.GetKey(KeyCode.LeftShift)){
					ShipStats.ResetPoints();
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
			}

	}
}
