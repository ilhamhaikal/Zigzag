using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPosition; // posisi ukuran platform
    float size; // ukuran platform

	// Use this for initialization
	void Start () {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x; // x atau z keduanya sama	

        for (int i = 0; i < 20; i++) // buat pertama set untuk platform
            SpawnPlatform();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameOver == true)
            CancelInvoke("SpawnPlatform");
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f); // mulai membuat yang berikutnya
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6); // 0 sampai 5
        if (rand < 3)
            SpawnX();
        else if (rand >= 3)
            SpawnZ();
    }

    void SpawnX() // platform spawn dalam arah x
    {
        Vector3 pos = lastPosition;
        pos.x += size; // pindahkan yang baru pada sumbu x dengan ukuran platform
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }

    void SpawnZ() // bentuk plat spawn dalam sumbu z
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }
}
