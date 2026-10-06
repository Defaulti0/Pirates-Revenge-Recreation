using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Variables
    public float playerSpeed = 0.0f;
    public float superMeter = 0.0f;
    public float forwardMovement = 10.0f;
    public float fireRate = 1.0f;
    public float attackTimer = 0.0f;
    public float dodgeSpeed = 20.0f;
    public bool isDodging = false;
    public int score = 0;
    public bool isInvincible = false;

    public InputActionReference holdAttackLeft;
    public InputActionReference holdAttackRight;
    public InputActionReference dodgeAction;

    public GameObject projectile;
    public Transform firePointLeft;
    public Transform firePointRight;
    public Transform firePointCenter;

    private Rigidbody rb;
    private float movementX;

    // Start is called once at object instantiation
    //  Get Rigidbody of the player object.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Physics calculations should be done in FixedUpdate.
    // Add force to the player based on the movement input.
    void FixedUpdate()
    {
        CheckMovementInput();
    }


    void Update()
    {
        CheckAttackInput();
        // CheckDodgeInput();
    }

    void CheckAttackInput()
    {
        if (holdAttackRight.action.IsPressed() && holdAttackLeft.action.IsPressed()) {
            // Debug.Log("Button held");
            attackTimer += Time.deltaTime;

            if (attackTimer >= fireRate)
            {
                Shoot(firePointCenter);
                attackTimer = 0.0f;
            }
        } else if (holdAttackRight.action.IsPressed()) {
            // Debug.Log("Button held");
            attackTimer += Time.deltaTime;

            if (attackTimer >= fireRate)
            {
                Shoot(firePointRight);
                attackTimer = 0.0f;
            }
        }
        else if (holdAttackLeft.action.IsPressed()) {
            // Debug.Log("Button held");
            attackTimer += Time.deltaTime;

            if (attackTimer >= fireRate)
            {
                Shoot(firePointLeft);
                attackTimer = 0.0f;
            }
        } else if (holdAttackLeft.action.WasReleasedThisFrame() || holdAttackRight.action.WasReleasedThisFrame())
        {
            // Debug.Log("Button released");
            attackTimer = 0.0f;
        }
    }

    // void CheckDodgeInput()
    // {
    //     if (movementX != 0.0f && dodgeAction.action.IsPressed()){
    //         isDodging = true;
    //     } else {
    //         isDodging = false;
    //     }
    // }

    void CheckMovementInput()
    {
        // Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        // rb.AddForce(movement, ForceMode.Force);

        // 1. Get the current velocity
        // 2. Set the x component of the velocity
        // 3. Set the new velocity
        Vector3 newVelocity = rb.linearVelocity;

        // if (isDodging){
        //     BecomeInvincible();
        // } else {
        //     BecomeVulnerable();
        // }

        // if (isDodging){
        //     newVelocity.x = movementX * dodgeSpeed;
        // }
        // else {
        //     newVelocity.x = movementX * playerSpeed;
        // }
        
        newVelocity.x = movementX * playerSpeed;

        rb.linearVelocity = newVelocity;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void Shoot(Transform firePoint)
    {
        // Creates an instance of the projectile at the the passed firepoint location
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }

    void BecomeInvincible()
    {
        isInvincible = true;
    }

    void BecomeVulnerable()
    {
        isInvincible = false;
    }
}
