using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    Vector3 offset; // buat kamera menjaga jarak tertentu dari bola saat mengikuti
    public float lerpRate; // tingkat kamera kan mengubah posisi untuk mengikuti bola
    public bool gameOver;

	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
            Follow();
	}

    void Follow()
    {
        Vector3 pos = transform.position; // posisi kamera saat ini
        Vector3 targetPos = ball.transform.position - offset; // jaga jarak tertentu dari bola
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime); // lerp berppindah dari satu nilai ke nilai lain pada  tingkat tertentu
        transform.position = pos;
    }
}
