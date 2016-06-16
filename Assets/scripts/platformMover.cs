using UnityEngine;
using System.Collections;

public class platformMover : MonoBehaviour {
    public float scrollSpeed = 0.5f;
    private Renderer rend;
    private GameManager gameManager;
    void Start() {
        rend = GetComponent<Renderer>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update() {
        if(gameManager.gameStarted == true) {
            float offset = Time.time * scrollSpeed;
            rend.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
        }
    }
}
