using UnityEngine;

public class ProjController : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float lifespan = 3.0f;
    public int damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out EnemyController enemyVar))
        {
            enemyVar.health -= damage;
            Debug.Log("Enemy Health: " + enemyVar.health);

            if (enemyVar.health <= 0)
            {
                ScoreManager.Instance.AddScore(50);
            }

            Destroy(gameObject);
        }
    }
}
