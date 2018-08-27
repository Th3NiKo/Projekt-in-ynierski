using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDraw : MonoBehaviour {
    [Range(5, 50)]
    public int BlackbarPercentage = 20;
    public bool ControllerOffset;
    public bool InvertOffset = true;

    [Range(0, 100)]
    public int Sensitivity = 50;
    public float XClampMax = 50;
    public float YClampMax = 50;
    public float angularSpeed = 100.0f;
    public void FixedUpdate()
    {
        RefreshUI();

    }

    public void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        int screenW = Screen.width;
        int screenH = Screen.height;
        double blackbarHeight = (double)BlackbarPercentage / 100 * screenH;
        int blackbarWidth = Mathf.RoundToInt(GetComponent<RectTransform>().sizeDelta.x) + Sensitivity * 2;
        GetComponent<RectTransform>().sizeDelta = new Vector2(screenW, screenH);

      
        RectTransform topPanelRectTransform = transform.GetChild(0).GetComponent<RectTransform>();

     
        RectTransform bottomPanelRectTransform = transform.GetChild(1).GetComponent<RectTransform>();

        topPanelRectTransform.sizeDelta = new Vector2(blackbarWidth, (int)blackbarHeight);
        topPanelRectTransform.anchoredPosition = new Vector3(0, (int)-(blackbarHeight / 2), 0);

        bottomPanelRectTransform.sizeDelta = new Vector2(blackbarWidth, (int)blackbarHeight);
        bottomPanelRectTransform.anchoredPosition = new Vector3(0, (int)(blackbarHeight / 2), 0);
    }

}
