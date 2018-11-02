using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartFill : MonoBehaviour {

	public TextMesh text;
	float actualAngle = 0;
	void Start () {
		string [] allNumbers = {"20", "1", "18", "4", "13", "6", "10", "15", "2", "17"
								, "3", "19", "7", "16", "8", "11", "14", "9", "12", "15", "5"};
		for(int i = 0; i < allNumbers.Length; i++){
			TextMesh temp = Instantiate(text);
			temp.transform.RotateAround(this.transform.localPosition, new Vector3(0,0,1), actualAngle);
			actualAngle += (360/20);
			temp.text = allNumbers[i];

		}
		
	}
	
}
