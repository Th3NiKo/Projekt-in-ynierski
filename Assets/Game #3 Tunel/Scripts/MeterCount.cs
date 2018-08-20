using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterCount : MonoBehaviour {

    public GUIText scoreText;
    private float score;
	Text meters;
	void Start () {
		meterCount = 0.0f;
		meters = GetComponent<Text>();
	}
	
	void Update () {
		meterCount += Time.deltaTime * 15;
		
		meters.text = Mathf.CeilToInt(meterCount).ToString() + "m";
	}
	public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }
}
}
