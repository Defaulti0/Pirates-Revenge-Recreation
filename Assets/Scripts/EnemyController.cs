using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health = 50;
    public GameObject playerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            ScoreManager.Instance.AddScore(50);
            Destroy(gameObject);
        }
    }
}
