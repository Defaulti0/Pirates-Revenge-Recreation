using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour {

    public int health = 50;
    public TextMeshProUGUI scoreText;
    public GameObject playerObj;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GameObject hud = GameObject.Find("HUD");
        scoreText = hud.transform.Find("Player Score").GetComponent<TextMeshProUGUI>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        CheckHealth();
    }

    void CheckHealth() {
        if(health <= 0){
            playerObj.GetComponent<PlayerMove>().score += 500;
            scoreText.SetText("SCORE: " + playerObj.GetComponent<PlayerMove>().score.ToString());

            Destroy(gameObject);
        }
    }
}
