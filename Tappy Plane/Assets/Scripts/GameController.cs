using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public Text scoreText;
    public GameObject gameOverPanel;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;
   

	// Use this for initialization
	void Awake () {
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a imposter.
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlaneScored() {
        if(gameOver) {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void PlaneDied() {
        gameOverPanel.SetActive(true);
        gameOver = true;
    }
}
