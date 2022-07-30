using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	// Use this for initialization
	void Start () {
        gameOver = false;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        UiManager.instance.GameStart();
        //ScoreManager.instance.StartScore(); // mungkin tidak perlu dilakukan jika melakukan skor dengan setiap tap
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); // hanya mulai menularkan paltformbaru saat game mulai.
    }

    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
