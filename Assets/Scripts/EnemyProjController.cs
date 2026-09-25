using UnityEngine;
using TMPro;

public class EnemyProjController : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float lifespan = 3.0f;
    public int damage = 10;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GameObject hud = GameObject.Find("HUD");
        scoreText = hud.transform.Find("Player Score").GetComponent<TextMeshProUGUI>();
        healthText = hud.transform.Find("Player Health").GetComponent<TextMeshProUGUI>();

        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PlayerMove>(out PlayerMove playerVar)){
            playerVar.health -= damage;
            playerVar.score -= 25;

            scoreText.SetText("SCORE: " + playerVar.score.ToString());
            healthText.SetText("HEALTH: " + playerVar.health.ToString());

            Destroy(gameObject);
        }
    }
}
