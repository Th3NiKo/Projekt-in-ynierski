using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneOffice : MonoBehaviour {

	MessageReceiver msg;
	void Start(){
		msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
        UnityEngine.XR.InputTracking.Recenter();
    }

	void Update(){
		if(Input.GetKeyDown(KeyCode.R)){
            msg.SendError();
            msg.ClosePort();
            StartCoroutine(LoadScene(1.00f));
		}
	}

    IEnumerator LoadScene(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
