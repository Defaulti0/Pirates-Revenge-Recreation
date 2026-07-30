using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Variables
    public float playerSpeed = 0.0f;
    public int health = 100;
    public bool isInvincible = false;
    public float superMeter = 0.0f;
    public float forwardMovement = 10.0f;
    public float attackCooldown = 0.2f;

    public GameObject projectile;
    public Transform firePoint;

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
        // Check if the player is actively pressing a movement key
        // if (Mathf.Abs(movementX) > 0.01f) {
            Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
            rb.AddForce(movement * playerSpeed, ForceMode.Force);
        // } else {
        //     // Kills the horizontal (X) velocity instantly when keys are released
        //     // This preserves gravity (Y) and depth (Z) movement
        //     rb.linearVelocity = new Vector3(0.0f, rb.linearVelocity.y, 0.0f);
        // }
    }

    void Update(){

    }

    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    // Checks if the collided object has the tag "Collectible"
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collectible")){
            Destroy(other.gameObject);
        }
    }


    void OnAttack (InputValue fireValue) {
        if (fireValue.isPressed) {
            // Creates an instance of the projectile at the fire point's position
            Instantiate(projectile, firePoint.position, Quaternion.identity);
        }
    }

}
