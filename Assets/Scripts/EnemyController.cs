using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int eHealth = 50;
    public static EnemyController Instance { get; private set; }

    private void Awake()
    {
        // Enforce the Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    // Called by projectiles to deal damage to the enemy
    public void DealDamage(int amount)
    {
        eHealth -= amount;
        Debug.Log("Enemy Health: " + eHealth);
    }

    void CheckHealth()
    {
        if (eHealth <= 0)
        {
            ScoreManager.Instance.AddScore(50);
            Destroy(gameObject);
        }
    }
}
