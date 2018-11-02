using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Percusion : MonoBehaviour {


    //Control variables
    public float minLength = 1.0f;
    public float maxLength = 8.0f;
    public int numberOfPerc = 6;
    public int numberOfWaves = 10;

    //Private variables
    float diffrence = 0.0f;
    int actualPerc = 0;
    AudioSource source;
    Vector3 lastPosition;
    private int lastPerc;


    //Main vars
    List<Vector3> deltas;
    float waveLength;
    COM com;

    //Audio sources
    public AudioClip[] perc1;
    public AudioClip[] perc2;
    public AudioClip[] perc3;
    public AudioClip[] perc4;
    public AudioClip[] perc5;
    public AudioClip[] perc6;
    public AudioClip test;

    List<AudioClip[]> percs;

    //Effects
    public ParticleSystem effect1;

	void Start () {
        lastPerc = 0;
        //Setup songs to play
        percs = new List<AudioClip[]>();
        percs.Add(perc1); percs.Add(perc2); percs.Add(perc3); percs.Add(perc4); percs.Add(perc5); percs.Add(perc6);
        source = GetComponent<AudioSource>();

        diffrence = maxLength - minLength;
        lastPosition = transform.position;
  
        waveLength = 0.0f;
        deltas = new List<Vector3>();
        com = Camera.main.GetComponent<COM>();
        
    }
	
	
	void Update () {
        //Vector3 deltaNow = com.LoadDeltas();
        //Without device
        Vector3 deltaNow = this.transform.position - lastPosition;
        if (Input.GetKeyDown(KeyCode.X)) {
            source.clip = test;
            source.Play();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            source.clip = percs[1][6];
            source.Play();
        }


        RaycastHit hit;

        Vector3 rayPosition = this.transform.position;
        rayPosition.y -= 0.1f;
        if (Physics.Raycast(rayPosition, new Vector3(0, -1, 0), out hit, 100)) {
            bool good = Int32.TryParse(hit.collider.name, out actualPerc);
            if (!good) {
                actualPerc = lastPerc;
            }

           // hit.transform.GetChild(0).gameObject.SetActive();
        }
        MarkActive();
        
        //Slope is here
      
            if (deltas.Count > 1 && this.transform.position.y > deltas[deltas.Count - 1].y) {

                //Get wave length
                if (deltas.Count > numberOfWaves) {
                    waveLength = Mathf.Abs(deltas[deltas.Count-1].y - deltas[(deltas.Count - 1) -numberOfWaves].y); //thats dependent on hight without speed
                    //waveLength = Mathf.Abs(deltas[deltas.Count - numberOfWaves].y - deltas[deltas.Count - 1].y);
                }

                //We have to play a sound if we reached minLength
                if (waveLength > minLength) {
                    if (waveLength > maxLength) { //if reached max
                        waveLength = maxLength;
                    }
                    //Which sound to play?
                    int whichSong = Mathf.RoundToInt((waveLength - minLength) / (diffrence / (float)percs[actualPerc].Length));
                    if (whichSong > percs[actualPerc].Length - 1) {
                        whichSong = percs[actualPerc].Length - 1;
                    }

                    //Find which clip to play and do it
                    source.clip = percs[actualPerc][whichSong];
                    source.PlayOneShot(source.clip);

                    //Create particle effect
                    GameObject actualPercObject = GameObject.Find(actualPerc.ToString());
                    Vector3 effectPosition = actualPercObject.transform.position;
                   // effectPosition.y += actualPercObject.transform.lossyScale.y;
                    CreateEffect(effectPosition, actualPercObject.GetComponent<Renderer>().material.color, waveLength);

                    //Tweeen transform position and rotation
                    Sequence cursorS = DOTween.Sequence();
                    Sequence sequence = DOTween.Sequence();
                    Sequence rotationS = DOTween.Sequence();
                   
                    //Cursor animation
                    
                    //cursorS.Append(this.transform.DOLocalRotate(new Vector3(Remap(waveLength, minLength, maxLength, 15, 40),270,0),0.15f));
                    //cursorS.Append(this.transform.DOLocalRotate(new Vector3(10, 270, 0), 0.10f));

                    //Rotation of perc
                    //Vector3 rotationValue = this.transform.position - actualPercObject.transform.position;
                    //rotationValue.y = 0.0f;
                    //rotationS.Append(actualPercObject.transform.DOLocalRotate(-rotationValue * 15, 0.3f));
                    //rotationS.Append(actualPercObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f));

                    //Movement of perc
                    sequence.Append(actualPercObject.transform.DOLocalMoveY(3.6f - (waveLength / 2.0f), 0.15f));
                    sequence.Append(actualPercObject.transform.GetChild(0).DOLocalMoveY(-0.2f, 0.15f));
                    sequence.Append(actualPercObject.transform.GetChild(0).DOLocalMoveY(0.15f, 0.10f));
                    sequence.Append(actualPercObject.transform.DOLocalMoveY(3.6f, 0.15f));
                    sequence.Append(actualPercObject.transform.GetChild(0).DOLocalMoveY(0.0f, 0.15f));



                }
                deltas.Clear();
                waveLength = 0.0f;
                
            } else {
                deltas.Add(this.transform.position);
            }
      
        lastPosition = this.transform.position;
        lastPerc = actualPerc;
	}


    void CreateEffect(Vector3 pos, Color color, float wave) {
        ParticleSystem temp = effect1;
        ParticleSystem.MainModule settings = temp.main;
        temp.transform.position = pos;
        settings.startColor = color;
        settings.startSpeed = Remap(wave, minLength, maxLength, 1.0f,5.0f);
        Instantiate(temp);
    }

    void MarkActive() {
        GameObject pads = GameObject.Find("Pads");
        
        for(int i = 0; i < pads.transform.childCount; i++) {
                   
                pads.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        if (!pads.transform.GetChild(actualPerc).GetChild(0).gameObject.activeSelf) {
            //Animate pad and make it active
            pads.transform.GetChild(actualPerc).GetChild(0).gameObject.transform.localScale = new Vector3(0.3f, 1.0f, 0.3f);
             pads.transform.GetChild(actualPerc).GetChild(0).gameObject.transform.DOScale(1.0f, 0.3f);
            pads.transform.GetChild(actualPerc).GetChild(0).gameObject.SetActive(true);
        }
    }


    float Remap(float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
