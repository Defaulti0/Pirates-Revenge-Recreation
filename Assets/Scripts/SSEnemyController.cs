using UnityEngine;

public class SSEnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public float distance = 5.0f;

    private Vector3 startPosition;
    private int direction = 1; // 1 = Right, -1 = Left

    void Start()
    {
        // Save the starting point
        startPosition = transform.position;
    }

    void Update()
    {
        // Move left or right
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Check if the NPC traveled too far from its start position
        if (Mathf.Abs(transform.position.x - startPosition.x) >= distance)
        {
            // Reverse direction
            direction *= -1;
        }
    }
}
