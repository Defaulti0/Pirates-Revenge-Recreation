using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public TextMeshProUGUI scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GameObject hud = GameObject.Find("HUD");
        scoreText = hud.transform.Find("Player Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        
    }


}