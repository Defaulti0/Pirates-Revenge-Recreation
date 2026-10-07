using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    // Variables
    private float playerSpeed = 10.0f;
    // private float forwardMovement = 10.0f;
    // private float superMeter = 0.0f;
    private float fireRate = 0.2f;
    private float attackTimer = 0.0f;

    private bool canDodge = true;
    private bool isDodging;
    private float dodgePower = 20.0f;
    private float dodgingTime = 0.2f;
    private float dodgingCooldown = 1.0f;

    [SerializeField]private InputActionReference holdAttackLeft;
    [SerializeField]private InputActionReference holdAttackRight;
    [SerializeField]private InputActionReference dodgeAction;

    [SerializeField]private GameObject projectile;
    [SerializeField]private Transform firePointLeft;
    [SerializeField]private Transform firePointRight;
    [SerializeField]private Transform firePointCenter;

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
        if (isDodging) return;
        CheckMovementInput();
    }


    void Update()
    {
        CheckDodgeInput();
        CheckAttackInput();
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

    void CheckDodgeInput()
    {
        if (dodgeAction.action.IsPressed() && canDodge)
        {
            Debug.Log("Dodge pressed");
            StartCoroutine(Dodge());
        }
    }

    void CheckMovementInput()
    {
        // Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        // rb.AddForce(movement, ForceMode.Force);

        // 1. Get the current velocity
        // 2. Set the x component of the velocity
        // 3. Set the new velocity
        Vector3 newVelocity = rb.linearVelocity;
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

    private IEnumerator Dodge()
    {
        canDodge = false;
        isDodging = true;
        HealthManager.Instance.isInvincible = true;
        rb.linearVelocity = new Vector3(movementX * dodgePower, 0f);
        yield return new WaitForSeconds(dodgingTime);
        isDodging = false;
        HealthManager.Instance.isInvincible = false;
        yield return new WaitForSeconds(dodgingCooldown);
        canDodge = true;
    }
}

