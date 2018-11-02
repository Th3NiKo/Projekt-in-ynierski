using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DrawVR : MonoBehaviour {

    public GameObject kursor;
    COM msg;
    TubeRenderer tube;
    List<Vector3> points;
    Vector3 lastPosition;
    Vector3 delta;

    public Material[] allMats;
    int actualMaterial = 0;
    public Material mat;

    public float actualRadius = 0.1f;

    public bool Keyboard = false;

    public GameObject cameraUp;
    void Start() {
        tube = GetComponent<TubeRenderer>();
        points = new List<Vector3>();
        lastPosition = kursor.transform.position;
        msg = Camera.main.GetComponent<COM>();
        cameraUp.SetActive(false);
    }

    void Update() {

        //Delta for rotating
        delta = msg.LoadDeltas();

     

        if (Keyboard) {
            //*************************************************************************
            //                               KEYBOARD
            //************************************************************************ */
            //Destroying
            if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.Z)) {
                DestroyAll();
            }

            //Rotating
            if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z)) {
                RotateAll();
            }

            //Drawing
            if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X)) {
                Draw();
            }
            else {
                ClearMesh();
            }

            //Drawing creation
            if (Input.GetKeyUp(KeyCode.Z)) {
                CreateMesh();
            }
        }
        else {

            //************************************************************************
            //                               PEN
            //************************************************************************
            if (msg.IsWritingPen()) {

                //************************************************************************
                //                               WRITING PEN
                //************************************************************************
                //Destroying
                if (Input.GetKey(KeyCode.X) && (msg.ButtonPressed(0) || Input.GetKey(KeyCode.Z))) {
                    DestroyAll();
                }

                //Rotating
                if (Input.GetKey(KeyCode.X) && (!msg.ButtonPressed(0) || !Input.GetKey(KeyCode.Z))) {
                    RotateAll();
                }

                //Drawing
                if ((msg.ButtonPressed(0) || Input.GetKey(KeyCode.Z)) && !Input.GetKey(KeyCode.X)) {
                    Draw();
                }
                else {
                    ClearMesh();
                }

                //Drawing creation
                if (msg.ButtonPressedUp(0) || Input.GetKeyUp(KeyCode.Z)) {
                    CreateMesh();
                }
            }
            else {
                //Drawing for working 
                
                if ((msg.ButtonPressed(0) || Input.GetKey(KeyCode.Z)) && (!msg.ButtonPressed(1) && !Input.GetKey(KeyCode.X))) {
                    Draw();
                }
                else {
                    ClearMesh();
                } 
                

                //Drawing for not working
                /*
                if(msg.ButtonPressed(0) || msg.ButtonPressed(1) || Input.GetKey(KeyCode.Z)) {
                    Draw();
                } else {
                    ClearMesh();
                }
                */

                
                //************************************************************************
                //                               2-Buttons PEN
                //************************************************************************
                //Destroying
                if ((msg.ButtonPressed(1) || Input.GetKey(KeyCode.X)) && (msg.ButtonPressed(0) || Input.GetKey(KeyCode.Z))) {
                   DestroyAll();
                 
                }

                //Destroy broken
                /*
                if ((Input.GetKey(KeyCode.X)) && (Input.GetKey(KeyCode.Z))) {
                     DestroyAll();
                    // Draw();
                }*/

                //Rotate broken
                /*
                if ((Input.GetKey(KeyCode.X)) && (!Input.GetKey(KeyCode.Z))) {
                    RotateAll();
                    // Draw();
                }*/

                //Rotating
                if ((msg.ButtonPressed(1) || Input.GetKey(KeyCode.X)) && (!msg.ButtonPressed(0) || !Input.GetKey(KeyCode.Z))) {
                     RotateAll();
                   // Draw();
                }



                //Drawing creation normla buttons
                
                if (msg.ButtonPressedUp(0) || Input.GetKeyUp(KeyCode.Z)) {
                    CreateMesh();
                }


                //Drawing broken
                /*
                if(msg.ButtonPressedUp(0) && (!msg.ButtonPressed(0) && !msg.ButtonPressed(1) && !Input.GetKey(KeyCode.Z))) {
                    CreateMesh();
                }

                if (msg.ButtonPressedUp(1) && (!msg.ButtonPressed(0) && !msg.ButtonPressed(1) && !Input.GetKey(KeyCode.Z))) {
                    CreateMesh();
                }

                if (Input.GetKeyUp(KeyCode.Z) && (!msg.ButtonPressed(0) && !msg.ButtonPressed(1) && !Input.GetKey(KeyCode.Z))) {
                    CreateMesh();
                }*/
            }

        }

    }

    void DestroyAll() {
        GameObject[] allItems = GameObject.FindGameObjectsWithTag("Mesh");
        for (int i = 0; i < allItems.Length; i++) {
            Destroy(allItems[i]);
        }
        GetComponent<MeshFilter>().mesh.Clear();
        GetComponent<MeshFilter>().sharedMesh.Clear();
    }

    void RotateAll() {
        GameObject[] allMeshes = GameObject.FindGameObjectsWithTag("Mesh");
        for (int i = 0; i < allMeshes.Length; i++) {
            allMeshes[i].transform.RotateAround(new Vector3(0, 0, -2.5f), new Vector3(0, 3, 0), delta.x / 5);
        }
    }

    void Draw() {
        this.gameObject.GetComponent<Renderer>().enabled = true;
        if (Vector3.Distance(lastPosition, kursor.transform.position) >= (0.01f)) {
            points.Add(kursor.transform.position);
            tube.SetPoints(points.ToArray(), actualRadius, Color.white);
            tube.material = allMats[actualMaterial];
            this.GetComponent<MeshRenderer>().material = allMats[actualMaterial];
            lastPosition = kursor.transform.position;
        }
    }

    void ClearMesh() {
        tube.vertices = null;
    }

    void CreateMesh() {
        GameObject line = new GameObject();
        line.AddComponent(typeof(MeshFilter));
        line.AddComponent(typeof(MeshRenderer));
        line.AddComponent(typeof(MeshCollider));

        line.gameObject.name = "Mesh";
        line.gameObject.tag = "Mesh";
        line.transform.position = this.transform.position;

        if (GetComponent<MeshFilter>().sharedMesh != null)
            line.GetComponent<MeshFilter>().sharedMesh = (Mesh)Instantiate(GetComponent<MeshFilter>().sharedMesh);
        line.GetComponent<MeshCollider>().sharedMesh = line.GetComponent<MeshFilter>().sharedMesh;
        line.GetComponent<MeshRenderer>().material = (Material)Instantiate(GetComponent<MeshRenderer>().material);

        actualMaterial++;
        if (actualMaterial >= allMats.Length) {
            actualMaterial = 0;
        }
        points.Clear();
    }

    public void changeThickness(float thick) {
        actualRadius = thick;
    }


}
