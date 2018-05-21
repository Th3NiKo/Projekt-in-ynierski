using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour {

	Kursor3D kursor;
	TrailRenderer trail;
	public GameObject line;
	bool toDraw = false;
	void Start(){
		kursor = transform.GetComponentInParent<Kursor3D>();
		trail = GetComponent<TrailRenderer>();
	}
	void Update () {
		if(kursor.IsPressed()){
			trail.time = Mathf.Infinity;
			toDraw = true;
		} else {
			if(toDraw){
				Vector3[] positions = new Vector3[10000];
				int numberOF = trail.GetPositions(positions);
				Debug.Log(numberOF);
				trail.time = 0.3f;
				GameObject tempLine = line;
				line.transform.position = this.transform.position;
				line.GetComponent<LineRenderer>().positionCount = numberOF;
				line.GetComponent<LineRenderer>().SetPositions(positions);
				GameObject temp = Instantiate(line, this.transform.position, Quaternion.identity);
				
				Destroy(temp.GetComponent<Drawing>());
				toDraw = false;
			}
		}

	}
}
