using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	[SerializeField] Vector2 position;
	[SerializeField] Vector3 angles;
	[Range(0,50000)] public float sensitivity = 10000;
	Rigidbody rgb;
	MessageReceiver msg;
	void Start () {
		rgb = GetComponent<Rigidbody> ();
		msg = GameObject.Find ("Controler").GetComponent<MessageReceiver>();
	}
	
	// Update is called once per frame
	void Update () {
		position = msg.LoadPositions ();
		angles = msg.LoadAngles ();
		rgb.velocity = new Vector3 (position.x / sensitivity, position.y / sensitivity, 0);
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,-0.33f, 0.33f), Mathf.Clamp(this.transform.position.y, -0.33f, 0.33f),0);
	}
}
