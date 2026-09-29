using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyData enemyData;
    private int currentHealth;

    private void Awake()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        if (enemyData != null)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material.color = enemyData.variationColor;
            }
        } else {
            Debug.Log("EnemyData is not assigned to this enemy! Using default values.");

            currentHealth = 100;
            
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material.color = Color.red;
            }
        }
    }

    // Called by projectiles to deal damage to the enemy
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
        ScoreManager.Instance.AddScore(50);
        Destroy(gameObject);
    }

}
