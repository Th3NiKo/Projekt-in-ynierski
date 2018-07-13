using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {


	bool lost = false;
	public GameObject gameOver;
	public Light point;

	void Start(){
		Time.timeScale = 1.0f;
	}
	void Update(){
		if(lost){
			//Light
			point.intensity = Mathf.PingPong(Time.realtimeSinceStartup, 1) + 1;


			if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Block"){
			Finish();
		}
	}
	void Finish(){
		Time.timeScale = 0.0f;
		gameOver.SetActive(true);
		lost = true;
	}
}
