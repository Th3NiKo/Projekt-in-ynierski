using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 40.0f;
	public ParticleSystem ps;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void TakeDamage(float value){
		health -= value;
		
		if(health <= 0f){
			Die();
		}
	}

	void Die(){
		ParticleSystem temp = Instantiate(ps, this.transform.position,Quaternion.identity);
		Destroy(transform.parent.gameObject);
	}
}
