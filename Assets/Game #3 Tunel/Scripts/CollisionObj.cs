using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour {

    private bool gameOver = false;
    public GameObject gameOverImage;

    void Awake()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            GameOver();
        }
    }


    void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0.0f;
        gameOverImage.SetActive(true);

    }
}
