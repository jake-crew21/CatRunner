using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public bool gameStarted = false;
    public GameObject box;
    public int score;
    public GameObject btt;
    public Text scoretxt;
    void FixedUpdate() {
        StartCoroutine("spawner");
        scoretxt.text = "Score: " + score;
    }
    public void StartGame() {
        gameStarted = true;
        btt.SetActive(false);
    }
    IEnumerator spawner() {
        yield return new WaitForSeconds(2);
        Instantiate(box, new Vector3(4.608869f, 0.0499877f, 0.0f), Quaternion.identity);
        StopCoroutine("spawner");
    }
}
