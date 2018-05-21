using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour {

	public int health = 3;
	public GameObject[] healthObjects;

	bool overSpawned = false;
	static int points = 0;
	void Start () {
		
	}
	
	
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) {
		if(other.transform.tag == "Meteor"){
			
			TakeDamage();
			Destroy(other.gameObject);
		}
	}

	void TakeDamage(){
		health--;
		if(health <= 0){
			//Finish game
			ShipMovement.canMove = false;
			Time.timeScale = 0.0f;
			if(!overSpawned){
				GameObject temp = (GameObject)Instantiate(Resources.Load("GameOver"));
				temp.transform.SetParent(GameObject.Find("Canvas").transform,false);
				overSpawned = true;
			}
		} else {
			healthObjects[health].SetActive(false);
		}
	}

	public static void AddPoints(int value){
		points += value;
	}

	public static int GetPoints(){
		return points;
	}
}
