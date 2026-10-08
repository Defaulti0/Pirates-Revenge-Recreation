using UnityEngine;

public class EnemyProjController : MonoBehaviour
{
    private float bulletSpeed = 20.0f;
    private float lifespan = 3.0f;
    private int damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (HealthManager.Instance.isInvincible) {
                return;
            } else {
                HealthManager.Instance.TakeDamage(damage);
                ScoreManager.Instance.AddScore(-25);
            }
            Destroy(gameObject);
        }
    }
}
