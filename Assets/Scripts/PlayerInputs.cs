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
    public float fireRate = 1.0f;
    public float attackTimer = 0.0f;

    public InputActionReference holdAttackAction;

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
        CheckMovementInput();
    }


    void Update(){
        CheckAttackInput();
    }

    void CheckAttackInput(){
        if(holdAttackAction.action.IsPressed()) {
            // Debug.Log("Button held");
            attackTimer += Time.deltaTime;

            if(attackTimer >= fireRate){
                Shoot();
                attackTimer = 0.0f;
            }
        } else if(holdAttackAction.action.WasReleasedThisFrame()) {
            // Debug.Log("Button released");
            attackTimer = 0.0f;
        }
    }

    void CheckMovementInput(){
        // Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        // rb.AddForce(movement, ForceMode.Force);

        // 1. Get the current velocity
        // 2. Set the x component of the velocity
        // 3. Set the new velocity
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = movementX * playerSpeed;
        rb.linearVelocity = newVelocity;
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
    
    void Shoot(){
        // Creates an instance of the projectile at the fire point's position
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
