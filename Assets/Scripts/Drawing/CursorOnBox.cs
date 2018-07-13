using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnBox : MonoBehaviour {

	[SerializeField] Vector3 position;
	[SerializeField] Vector3 deltas;

	public float MaxRangeInput = 10000;
	public float MaxRangeOutput = 4;

	private float Divide;
	public
	PenCOM msg;
	void Start () {
		Divide = MaxRangeInput / MaxRangeOutput;
		msg = Camera.main.GetComponent<PenCOM>();
	}
	
	
	void Update () {
		position = msg.LoadPositions ();
		deltas = msg.LoadDeltas ();

		Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -position.z / Divide);
		this.transform.position = newPos;
		
	}
}
