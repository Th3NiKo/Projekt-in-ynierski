using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject[] meteors;
	private float timer;
	public float timeSpawn;

	public float speedUp = 0.0f;
	void Start () {
		timer = 0.0f;
	}
	
	
	void Update () {
		timer += Time.deltaTime;
		if(timer >= timeSpawn){
			int randomMeteor = Random.Range(0,meteors.Length - 1);
			Vector3 size = new Vector3(Random.Range(0.8f, 1.2f),Random.Range(0.8f, 1.2f),Random.Range(0.8f, 1.2f));
			Quaternion obrot = Quaternion.Euler(new Vector3(Random.Range(0.0f, 180.0f),Random.Range(0.0f, 180.0f),Random.Range(0.0f, 180.0f)));
			GameObject meter = Instantiate(meteors[randomMeteor],new Vector3(Random.Range(this.transform.position.x, 9.0f), Random.Range(-2.0f, 4.0f), this.transform.position.z), obrot);
			speedUp = Mathf.Clamp(speedUp, 2 * -40, -3);
			meter.GetComponent<Rigidbody>().velocity += new Vector3(0.0f, 0.0f, speedUp);
			meter.transform.localScale = size;
			timer = 0.0f;
			timeSpawn = ((speedUp + 99.25f) / 50.5f);
		}
	}

	public void SpeedChange(float change){
		speedUp += change;
	}
}
