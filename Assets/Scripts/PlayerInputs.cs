using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Variables
    public float playerSpeed = 0.0f;
    public int health = 100;
    public bool isInvincible = false;
    public float superMeter = 0.0f;

    public GameObject projectile;
    public float fireRate = 1.0f;

    private Rigidbody rb;
    private float movementX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        rb.AddForce(movement * playerSpeed);
    }

    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnFire (InputValue fireValue) {
        if (fireValue.isPressed) {
            Instantiate(projectile, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        }
    }

}
