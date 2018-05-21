using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour {

	public GameObject[] tower;
	public GameObject layer;
	public int layerCount = 50;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnLoop());
		tower=new GameObject[layerCount];
	}
	

private GameObject SpawnElement(Vector3 pos,bool root){
	if(root){
	GameObject _layer = Instantiate(layer,pos,transform.rotation) as GameObject;
	_layer.transform.Rotate(0,90,0);
	return _layer;
	}
	else{
	GameObject _layer = Instantiate(layer,pos,transform.rotation) as GameObject;
	return _layer;
	}

}
private IEnumerator SpawnLoop(){
	

	for (int i = 0; i < layerCount-1; i++)
	{	yield return new WaitForSeconds(0.3f);
		if(i%2==0)tower[i]=SpawnElement(new Vector3(0f,i*15f,0f),false);
		else 
		{
			tower[i]=SpawnElement(new Vector3(25f,i*15f,25f),true);
		} 
	}

}

}

