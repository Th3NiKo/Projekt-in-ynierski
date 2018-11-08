using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;

public class PointerPen : MonoBehaviour
{

    public int sceneToLoad = 1;
    TMP_Dropdown dropdown;
    public Button button;
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        List<string> allComs = new List<string>();
        for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
        {
            allComs.Add(SerialPort.GetPortNames()[i]);
        }
        dropdown.AddOptions(allComs);
        button.onClick.AddListener(LoadSceneOnClick);
    }

    void LoadSceneOnClick()
    {
        PlayerPrefs.SetString("COM", dropdown.options[dropdown.value].text);
        SceneManager.LoadScene(sceneToLoad);
    }

}
