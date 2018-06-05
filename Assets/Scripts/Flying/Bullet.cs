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

	void OnCollisionEnter(Collision other) {
		Target tar = other.collider.GetComponent<Target>();
		if(tar != null){
			tar.TakeDamage(5f);
			if(tar.tag == "Meteor"){
				//Shrink it out
				other.transform.localScale = new Vector3(other.transform.localScale.x-0.2f ,other.transform.localScale.y-0.2f ,other.transform.localScale.z-0.2f );
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
