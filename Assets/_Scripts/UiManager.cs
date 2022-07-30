using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance; // meenjadikan pola singleton, sskrip lain menggunakan instan untuk mengakses fungsi skrip ini

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1; // dari panel judul
    public Text highScore2; // dari panel game over

    void Awake()
    {
        if (instance == null) // jika once belum dibuat
            instance = this; // memastikan hnya ada satu contoh stel ke yang pertama ini
    }

	// Use this for initialization
	void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); // bisa memberikan nama scene atau index of scene dalam pengaaturan
    }
}
