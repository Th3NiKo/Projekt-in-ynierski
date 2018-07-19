using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawner : MonoBehaviour {

	[SerializeField] Vector2 minMaxX;
	[SerializeField] Vector2 minMaxY;
	[SerializeField] float Z;
	public GameObject obstacle;
	public float maxAngle = 45;

	public float cooldown = 5;
	public float speed = 15;
	private float timer;
	void Start () {
		timer = 0.0f;
		minMaxX = new Vector2(-10.6f, 10.6f);
		minMaxY = new Vector2(-3.2f, 4.8f);
		Z = 42.0f;
	}
	
	
	void Update () {
		if(timer > cooldown){
			Vector3 spawnPosition = new Vector3(Random.Range(minMaxX.x, minMaxX.y),Random.Range(minMaxY.x, minMaxY.y), Z);
			Quaternion spawnRotation = Quaternion.Euler(Random.Range(90 - maxAngle, 90 + maxAngle), 90, 0);
			GameObject spawnedObject = Instantiate(obstacle, spawnPosition, spawnRotation);
			spawnedObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
			timer = 0.0f;
		}
		timer += Time.deltaTime;
	}
}
