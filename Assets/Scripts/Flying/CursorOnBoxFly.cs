using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnBoxFly : MonoBehaviour {

	[SerializeField] Vector3 position;
	[SerializeField] Vector3 angles;

	public float MaxRangeInput = 10000;
	public float MaxRangeOutput = 4;

	private float Divide;
	public
	COM msg;
	void Start () {
		Divide = MaxRangeInput / MaxRangeOutput;
		msg = Camera.main.GetComponent<COM>();
	}
	
	
	void Update () {
		position = msg.LoadPositions ();
		angles = msg.LoadAngles();

		Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -angles.z / Divide);
		this.transform.position = newPos;

		transform.rotation = Quaternion.Euler(184,
											 Mathf.Clamp(angles.x / 266, -45, 45),
											 Mathf.Clamp(angles.y / 266, -45, 45));
											
		
	}
}
