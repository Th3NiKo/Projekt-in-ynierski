using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class PercUI : MonoBehaviour {

    TextMeshProUGUI sensitivityText;
    TextMeshProUGUI deviceText;
    COM com;
    PercussionOnBox kursor;
    private Color actualColor;

    //Check for change
    float lastSensitivity;

    bool lastDevice;
    void Start() {
        com = Camera.main.GetComponent<COM>();
        lastDevice = false;
        actualColor = new Vector4(1, 1, 1, 0);
        sensitivityText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        kursor = GameObject.Find("Kursor").GetComponent<PercussionOnBox>();
        lastSensitivity = kursor.Divide;
    }

    void Update() {
        if (lastSensitivity != kursor.Divide) {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(DOTween.ToAlpha(() => actualColor, x => actualColor = x, 1, 1));
            sequence.Append(DOTween.ToAlpha(() => actualColor, x => actualColor = x, 0, 1));

        }
        lastSensitivity = kursor.Divide;

    }
    void OnGUI() {
        sensitivityText.color = actualColor;
        if (kursor.OnDeltas) {
            sensitivityText.text = "Sensitivity: " + (1010 - kursor.Divide).ToString();
        }
        else {
            sensitivityText.text = "Sensitivity: " + (20000 - kursor.Divide).ToString();
        }

    }
}
