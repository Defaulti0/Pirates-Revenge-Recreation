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
    public Transform firePoint;
    public float fireRate = 1.0f;
    public float bulletSpeed = 20.0f;

    private Rigidbody rb;
    private float movementX;

    // Start is called once at object instantiation
    //  Get Rigidbody of the player object.
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Physics calculations should be done in FixedUpdate.
    // Add force to the player based on the movement input.
    void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        rb.AddForce(movement * playerSpeed, ForceMode.Force);
    }

    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnAttack (InputValue fireValue) {
        GameObject bullet = Instantiate(projectile, firePoint.position, 
            Quaternion.identity);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        bulletRb.linearVelocity = firePoint.forward * bulletSpeed;

        Destroy(bullet, 3.0f);
    }

}
