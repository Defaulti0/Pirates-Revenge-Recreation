using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreAmount = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreAmount);
            Destroy(gameObject);
        }
    }
}
