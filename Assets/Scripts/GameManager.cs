using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    Myszka input;
    public GameObject Block;
    public Material nonClicked;
    public Material pointer;
    
    public List <GameObject> blocks;
    GameObject selected;
    void Start(){
        CreateYenga(8);
        blocks = new List <GameObject>();
        input = GetComponent<Myszka>();
        selected = null;
    }

    void Update() {
        
        
        
    }

    void CreateYenga(int howManyFloors){
        float thicknes = Block.gameObject.transform.localScale.y;
        for(int i = 0; i < howManyFloors; i++){
            if(i % 2 == 0){ //even Floors so we dont need to rotate
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.0f), Quaternion.identity));
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.identity));
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.64f), Quaternion.identity));
            } else {
                blocks.Add(Instantiate(Block, new Vector3(-0.34f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(0.0f, 90f, 0.0f)));
                blocks.Add(Instantiate(Block, new Vector3(0.0f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(0.0f, 90f, 0.0f)));
                blocks.Add(Instantiate(Block, new Vector3(0.34f, 0.0f + thicknes * (i + 1), 0.34f), Quaternion.Euler(0.0f, 90f, 0.0f)));
            }
        }
    }





}