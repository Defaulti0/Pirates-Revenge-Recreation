using UnityEngine;

public class DiagREnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    // Adjust these in the inspector to change the angle
    // (1, 1) moves diagonally across the flat ground floor
    private Vector2 groundDirection = new Vector2(1f, 1f);

    private Vector3 movementVector;

    void Start()
    {
        groundDirection = groundDirection.normalized;

        // Convert the 2D direction into 3D space (X and Z, keeping Y at 0 so it stays flat)
        movementVector = new Vector3(groundDirection.x, 0f, groundDirection.y);
    }

    void Update()
    {
        transform.position += movementVector * enemyData.movementSpeed * Time.deltaTime;
    }
}
