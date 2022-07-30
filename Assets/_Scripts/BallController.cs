using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;

    [SerializeField]
    private float speed; // kecepatn bola
    [SerializeField]
    private float fallSpeed; // kecepataa bola pada saat diatas platform
    bool started; // lacak pemain telah dimulai yaitu saat permainan pertama berada dipuncak
    bool gameOver; // bola terputus dari platform/ jtuh dari platform
    Rigidbody rb;

    // Use for anything happening before Start()
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        started = false; // permaian tidak akan dimuai / layar tidak disentuh / mouse tidak di klik
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0); // bola hanya akan bergerak kearah x
                started = true;

                GameManager.instance.GameStart(); // game meneger mengontrol awal permainan
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f)) // jika tiadk menyentuh apapun / bolajatuh
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -fallSpeed, 0);
            Destroy(gameObject, 1.0f);

            Camera.main.GetComponent<CameraFollow>().gameOver = true; // akses game over dalam skrip kamera tetapkan ke true

            GameManager.instance.GameOver(); // game maager kontras/muncul di akhir game
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirections();
            ScoreManager.instance.IncrementScore();
        }
	}

    void SwitchDirections()
    {
        if (rb.velocity.z > 0)
            rb.velocity = new Vector3(speed, 0, 0);
        else if (rb.velocity.x > 0)
            rb.velocity = new Vector3(0, 0, speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1.0f);
            ScoreManager.instance.DiamondScore();
             
        }
    }
}
