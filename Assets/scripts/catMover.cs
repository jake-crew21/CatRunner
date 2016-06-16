using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class catMover : MonoBehaviour {
    private KeyCode jump = KeyCode.Space;
    public float jumpHeight;
    private Rigidbody myRigidbody;
    public bool canJump;
    private Animator myAnim;
    private GameManager gameManager;
	void Start () {
        myAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        canJump = true;
    }
	void Update () {
        startRun();
    }
    void FixedUpdate() {
        jumping();
    }
    void startRun() {
        if(gameManager.gameStarted == true) {
            //myAnim.SetBool("canRun", true);
            myAnim.Play("run");
        }
    }
    void jumping() {
        if ((Input.GetMouseButton(0) || Input.touchCount > 0) && canJump && gameManager.gameStarted) {
            myRigidbody.AddForce(Vector3.up * jumpHeight * Time.deltaTime);
            canJump = false;
        }
    }
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "platform") {
            canJump = true;
        }
        if (col.gameObject.tag == "Box") {
            Debug.Log("dead");
            SceneManager.LoadScene(0);
        }
    }
}
