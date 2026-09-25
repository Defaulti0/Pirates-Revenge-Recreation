using UnityEngine;
using TMPro;

public class ProjController : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float lifespan = 3.0f;
    public int damage = 10;

    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GameObject hud = GameObject.Find("HUD");
        scoreText = hud.transform.Find("Player Score").GetComponent<TextMeshProUGUI>();

        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<EnemyController>(out EnemyController enemyVar)){
            enemyVar.health -= damage;
            Debug.Log("Enemy Health: " + enemyVar.health);

            if (other.TryGetComponent<PlayerMove>(out PlayerMove playerVar)){
                playerVar.score += 50;
                scoreText.SetText("SCORE: " + playerVar.score.ToString());
            }
            
            Destroy(gameObject);
        }
    }
}
