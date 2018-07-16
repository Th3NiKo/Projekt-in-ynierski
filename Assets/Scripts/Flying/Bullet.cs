using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 15.0f;
	public GameObject imapact;
	bool shootForward;
	Vector3 shootingDirection;
	void Start () {
		//shootForward = true;
	}
	
	
	void Update () {
		if(shootForward){
			transform.Translate(0.0f, 0.0f, speed);
		} else {
			transform.position = Vector3.MoveTowards(this.transform.position, shootingDirection, 4.0f);
		}
	}

	public void SetDirection(Vector3 _dir){
		shootingDirection = _dir;
	}

	public void ShootForward(bool value){
		shootForward = value;
	}

	void OnTriggerEnter(Collider other) {
		Target tar = other.GetComponent<Target>();
		if(tar != null){
			tar.TakeDamage(40f);
			if(tar.tag == "Meteor"){
				//Shrink it out
				//other.transform.localScale = new Vector3(other.transform.localScale.x-0.05f ,other.transform.localScale.y-0.05f ,other.transform.localScale.z-0.05f );
				if(tar.health <= 0){
					ShipStats.AddPoints(10);
				}
				GameObject temp = Instantiate(imapact, this.transform.position, Quaternion.identity);
				Destroy(temp, 2f);
			}
		}
		Destroy(this.gameObject);
	}


}
