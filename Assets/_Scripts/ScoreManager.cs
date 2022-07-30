using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public int highScore;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    // Use this for initialization
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score); // "score" adalah kunci, score adalah nilai yang disimpan dalam kata kunci
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        score += 2;
    }

  /* public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }*/

    public void StopScore()
    {
       // CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score); // untuk akhir scor

        if (PlayerPrefs.HasKey("highScore")) // jika sudah ada kata kunci highscore yang dibuat
        {
            if(score > PlayerPrefs.GetInt("highScore")) // jika skor pemai lebih tinggi dari highscor mereka
            {
                PlayerPrefs.SetInt("highScore", score); // kunci skor tinggi ke sekor saat ini
            }
        }
        else // buat kunci highscore dan atur scor seperti itu
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
