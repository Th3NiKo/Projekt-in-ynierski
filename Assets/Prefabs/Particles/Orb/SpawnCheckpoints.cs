using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckpoints : MonoBehaviour {

	float timer = 0.0f;
	public float cooldown = 5.0f;
	public GameObject checkPoint;
	Vector3 lastPlayerPosition;
	GameObject player;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () {
		if(timer > cooldown){
			if(lastPlayerPosition.z + 15 < player.transform.position.z){
				float x = Random.Range(player.transform.position.x - 4, player.transform.position.x + 4);
				float y = Random.Range(-6.0f, 2.0f);
				float z = Random.Range(player.transform.position.z + 25, player.transform.position.z + 35);
				Instantiate(checkPoint, new Vector3(x,y,z), Quaternion.identity);

				
				timer = 0.0f;
				cooldown = Random.Range(3.0f, 6.0f);
				lastPlayerPosition = player.transform.position;
			}
		}



		timer += Time.deltaTime;
	}
}
