using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	Material mat;
	public float speed = 1.0f;
	void Start () {
		mat = GetComponent<Renderer>().material;
	}
	
	
	void FixedUpdate () {
		Vector2 offset = mat.mainTextureOffset;
		mat.mainTextureOffset = new Vector2(offset.x + Time.deltaTime * speed, offset.y + Time.deltaTime * speed);
		Vector2 tiling = mat.mainTextureScale;
		mat.mainTextureScale = new Vector2(Mathf.Cos(Time.timeSinceLevelLoad / 2) + 2, tiling.y);
	}
}
