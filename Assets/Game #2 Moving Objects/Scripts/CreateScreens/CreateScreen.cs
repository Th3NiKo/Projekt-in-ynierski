using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateScreen : MonoBehaviour {

    MessageReceiver msg;
    public GameObject photoPrefab;

    void Start() {
        msg = GameObject.Find("Controler").GetComponent<MessageReceiver>();
    }
    void OnTriggerStay(Collider col) {
        if (col.name == "Cursor") {
            if (Input.GetKeyDown(KeyCode.Space) || msg.ButtonPressedDown(0)) {
                Quaternion rotationTemp = photoPrefab.transform.rotation;
                Vector3 pos = new Vector3(0, 3, 3);
                if (SceneManager.GetActiveScene().name == "VR") {
                    pos = new Vector3(-15.5f, -4.6f, 10.8f);

                }
                GameObject x = Instantiate(photoPrefab, pos, rotationTemp);
                if (SceneManager.GetActiveScene().name == "VR") {
                    if (photoPrefab.name == "Speaker") {
                        x.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    }
                    else {
                        x.transform.localScale = new Vector3(0.04f, 0.025f, 0.04f);
                    }
                }
            }
        }
    }
}
