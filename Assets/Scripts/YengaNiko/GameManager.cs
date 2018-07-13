using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject Block;
    public Material nonClicked;
    public Material pointer;

    GameObject Tower;
    
    public List <GameObject> blocks;
    void Start(){
        Tower = new GameObject();
        Tower.name = "Tower";
        CreateYenga(9);
        blocks = new List <GameObject>();
    }


    void CreateYenga(int howManyFloors){
        float thicknes = Block.gameObject.transform.localScale.y;
        for(int i = 0; i < howManyFloors; i++){
            if(i % 2 == 0){ //even Floors so we dont need to rotate
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)));
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)));
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.64f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)));
            } else {
                blocks.Add(Instantiate(Block, new Vector3(-0.34f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(-90.0f, 90f, 0.0f)));
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(-90.0f, 90f, 0.0f)));
                blocks.Add(Instantiate(Block, new Vector3(0.34f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(-90.0f, 90f, 0.0f)));
            }
        }

        //Make to one parent so we cant rotate whole tower
        for(int i = 0; i < blocks.Count; i++){
            Tower.transform.parent = GameObject.Find("Column").transform;
            blocks[i].transform.parent = Tower.transform;
        }
    }





}