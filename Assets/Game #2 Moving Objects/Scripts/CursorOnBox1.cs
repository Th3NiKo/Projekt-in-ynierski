using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorOnBox1 : MonoBehaviour {

	[SerializeField] Vector3 position;
	[SerializeField] Vector3 deltas;

	public float MaxRangeInput = 10000;
	public float MaxRangeOutput = 4;

	public bool OnDeltas = false;

	public float Divide = 400.0f;
	public MessageReceiver msg;
	public float box = 3;

	//Box
	public Vector2 minMaxX;
	public Vector2 minMaxY;
	public Vector2 minMaxZ;
	void Start () {
		if(!OnDeltas){
			Divide = MaxRangeInput / MaxRangeOutput;
		}
		if(PlayerPrefs.HasKey("MultimediaDivide")){
			Divide = PlayerPrefs.GetFloat("MultimediaDivide");
		}
		this.transform.position = new Vector3(0f,1.5f,0f);
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
        if(SceneManager.GetActiveScene().name == "VR") {
            this.transform.position = new Vector3(-15.5f, -4.8f, 10.69f);
            Divide = 6000;
        }
	}
	
	
	void Update () {
		//Sensitivity
		if(Input.GetKey(KeyCode.Alpha1)){
			Divide += 10;
			//Zapis do pliku
			PlayerPrefs.SetFloat("MultimediaDivide", Divide);
		
		} else if(Input.GetKey(KeyCode.Alpha2)){
			Divide -= 10;
			//Zapis do pliku
			PlayerPrefs.SetFloat("MultimediaDivide", Divide);
		}
		Divide = Mathf.Clamp(Divide,1, 12000);

		if(!OnDeltas){
			position = msg.LoadPositions ();
			Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -position.z / Divide);
			newPos = new Vector3(Mathf.Clamp(newPos.x, minMaxX.x, minMaxX.y),
								 Mathf.Clamp(newPos.y, minMaxY.x, minMaxX.y),
								 Mathf.Clamp(newPos.z, minMaxZ.x, minMaxX.y));
			//this.transform.position = newPos;
			this.GetComponent<Rigidbody>().position = newPos;
		} else {
			position = msg.LoadPositions();
			deltas = msg.LoadDeltas();
			Vector3 newPos = new Vector3(transform.position.x + (deltas.x / Divide), transform.position.y + (deltas.y / Divide), transform.position.z -(deltas.z / Divide));
			newPos = new Vector3(Mathf.Clamp(newPos.x, minMaxX.x, minMaxX.y),
								 Mathf.Clamp(newPos.y, minMaxY.x, minMaxY.y),
								 Mathf.Clamp(newPos.z, minMaxZ.x, minMaxZ.y));
			this.transform.position = newPos;
		}
		
	}

}
