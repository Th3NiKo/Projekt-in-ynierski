using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour {

	public GameObject [] obstacles;
	public float cooldown = 2f;

	public float speed = 2f;
	private float timer;

	private int lastChoosenIndex;
	void Start () {
		timer = 0.0f;
		lastChoosenIndex = 0;
	}
	
	
	void Update () {
		if(timer > cooldown){
			//Random choose obstacle from list
			int spawnIndex = Random.Range(0,obstacles.Length);
			if(spawnIndex == lastChoosenIndex){
				spawnIndex = spawnIndex - 1;
				if(spawnIndex <= 0){
					spawnIndex = obstacles.Length - 1;
				}
			}
			lastChoosenIndex = spawnIndex;
			
			int spawnRotation = Random.Range(0,360);
            //Give it random rotation 
            Quaternion rotation = Quaternion.Euler(spawnRotation,obstacles[spawnIndex].transform.rotation.eulerAngles.y,obstacles[spawnIndex].transform.rotation.eulerAngles.z);
			GameObject spawnedObstacle = Instantiate(obstacles[spawnIndex], this.transform.position, rotation);

			//Give it velocity
			spawnedObstacle.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);

			
			timer = 0.0f;
		}



		timer += Time.deltaTime;
	}
}
