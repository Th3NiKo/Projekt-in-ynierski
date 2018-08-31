using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParkinsonUI : MonoBehaviour {

    //Control
    public float scale = 0.01f;
    private float minScale = -1.0f;
    private float maxScale = 1.0f;

    COM com;

    //Axes
    Image xImage;
    Image yImage;
    Image zImage;

    //Stats
    TextMeshProUGUI timerText;
    TextMeshProUGUI freqText;
    private float timer = 0.0f;
    private int counter = 0;
    public float minChange = 0.2f;

    public GameObject cameraBack;
    public GameObject rotateObj;
    Vector3 rotateStartPos;

    //Hand stop movement
    private GameObject handObj;

    bool parkinson = false;


	void Start () {
        
        //References
        com = GameObject.Find("Controler").GetComponent<COM>();

        //Geting images
        xImage = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
        yImage = transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>();
        zImage = transform.GetChild(0).GetChild(2).gameObject.GetComponent<Image>();

        //Stats
        timerText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        freqText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();


        handObj = GameObject.Find("Hand");
        rotateStartPos = rotateObj.transform.position;
    }
	
	void Update () {
        SetImages();
        ClampScale(xImage, minScale, maxScale);
        ClampScale(yImage, minScale, maxScale);
        ClampScale(zImage, minScale, maxScale);

        DetectAnomaly();
        ResetBoard();
        ShowAnomaly();

        timerText.text = timer.ToString("0.00");
        timer += Time.deltaTime;



    }

    void SetImages() {
        xImage.transform.localScale = new Vector3(xImage.transform.localScale.x + com.LoadDeltas().x * scale, 1, 1);
        yImage.transform.localScale = new Vector3(yImage.transform.localScale.x + com.LoadDeltas().y * scale, 1, 1);
        zImage.transform.localScale = new Vector3(zImage.transform.localScale.x + com.LoadDeltas().z * scale, 1, 1);
    }


    void ClampScale(Image img, float min, float max) {
        img.transform.localScale = new Vector3(Mathf.Clamp(img.transform.localScale.x,min,max),1,1);
    }

    void DetectAnomaly() {
        Vector3 actualDelta = com.LoadDeltas();
        actualDelta = new Vector3(actualDelta.x * scale, actualDelta.y * scale, actualDelta.z * scale);
        if ((actualDelta.x > minChange) || (actualDelta.y > minChange) || (actualDelta.z > minChange)) {
            counter++;
        }
        freqText.text = Mathf.CeilToInt(counter / timer).ToString();
    }

    void ResetBoard() {
        if (Input.GetKeyDown(KeyCode.R)) {
            timer = 0.0f;
            counter = 0;
            xImage.transform.localScale = new Vector3(0, 1, 1);
            yImage.transform.localScale = new Vector3(0, 1, 1);
            zImage.transform.localScale = new Vector3(0, 1, 1);
            rotateObj.GetComponent<TrailRenderer>().Clear();
        }
    }
    
    void ShowAnomaly() {

        if (Input.GetKey(KeyCode.Space)) {

            cameraBack.transform.RotateAround(rotateObj.transform.position,Vector3.up,0.25f);
            handObj.GetComponent<ParkinsonOnBox>().CanMove = false;
            this.GetComponent<Canvas>().enabled = false;
            cameraBack.SetActive(true);

        } else {
            handObj.GetComponent<ParkinsonOnBox>().CanMove = true;
            cameraBack.SetActive(false);
            this.GetComponent<Canvas>().enabled = true;

        }
    }
}
