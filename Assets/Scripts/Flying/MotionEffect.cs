using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class MotionEffect : MonoBehaviour {

	

	PostProcessingProfile post;
	Vector3 lastPosition;
	Kursor3D kursor;
	float intensity = 0;

	void Start () {
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
		lastPosition = this.transform.position;
		post = GetComponent<PostProcessingBehaviour>().profile;
	}
	
	
	void Update () {
		ChromaticAberrationModel.Settings s = post.chromaticAberration.settings;
		if(kursor.anglesDelta.y != 0){
			s.intensity += 0.05f;
			s.intensity = Mathf.Clamp(s.intensity,0.0f,1.0f);
			post.chromaticAberration.settings = s;
		} else {
			s.intensity -= 0.05f;
			s.intensity = Mathf.Clamp(s.intensity,0.0f,1.0f);
			post.chromaticAberration.settings = s;
		}
	}
}
