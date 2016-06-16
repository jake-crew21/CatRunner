using UnityEngine;
using System.Collections;

public class obstacleMover : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody boxRigidbody;
    private GameManager gameManager;
    void Start () {
        boxRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }	
	void Update () {
        if (gameManager.gameStarted) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
	}
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Respawn") {
            gameManager.score++;
            Destroy(gameObject);
        }
    }
}
