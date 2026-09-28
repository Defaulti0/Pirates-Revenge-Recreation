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
        if (other.CompareTag("Enemy"))
        {
            EnemyController.Instance.DealDamage(damage);
            ScoreManager.Instance.AddScore(25);
            Destroy(gameObject);
        }
    }
}
