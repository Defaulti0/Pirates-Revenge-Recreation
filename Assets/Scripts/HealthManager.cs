using TMPro;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    // Player health managed here, enemies have their own health managed in enemycontroller
    [SerializeField] private int health = 100;
    [SerializeField] private bool isInvincible = false;
    // [SerializeField] private float invincibilityDuration = 1.0f;
    [SerializeField] private TextMeshProUGUI healthText;
    private int maxHealth = 100;

    // Getters
    public static HealthManager Instance { get; private set; }

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
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        healthText.SetText("HEALTH: " + health + "/" + maxHealth);
    }


    public void TakeDamage(int amount)
    {
        if (isInvincible) return;
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();
    }

    private void Die()
    {
        // Call the game over method in the game manager
        GameManager.Instance.TriggerGameOver();
    }
}
