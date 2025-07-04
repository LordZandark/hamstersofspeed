using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLocomotion : MonoBehaviour
{
    public LayerMask groundLayer;

    public MovementVector movementVector;

    public GameObject ballMesh;

    private Rigidbody ballRb;

    public float speedMultiplier = 1f;
    public float speedMax;
    public float brakesFactor = 5f;

    public float moveDeadzone = .2f;

    [Header("Dash")]
    public InputActionReference dashButton;
    public float dashForce = 10;
    public float dashDelay = 5;
    private bool dashReady = true;

    [Header("Jump")]
    public InputActionReference jumpButton;
    public float jumpForce = 10;
    public float jumpDelay = 10;
    private bool jumpReady = true;

    private float headDistance;
    private float speed;
    private Vector3 moveDirection;

    bool isGrounded;

    private void OnEnable()
    {
        dashButton.action.performed += Dash;
        dashButton.action.Enable();

        jumpButton.action.performed += Jump;
        jumpButton.action.Enable();
    }

    private void OnDisable()
    {
        dashButton.action.performed -= Dash;
        dashButton.action.Disable();

        jumpButton.action.performed -= Jump;
        jumpButton.action.Disable();
    }

    private void Awake()
    {
        //Define the ball's rigidbody
        ballRb = GetComponent<Rigidbody>();

        //Define the maximum speed
        speedMax = speedMultiplier * ballMesh.transform.localScale.y;
    }

    private void FixedUpdate()
    {
        //Check if the hamster ball is grounded
        CheckIfGrounded();

        //Updates the movement related variables
        UpdateMovementVariables();

        //Move the ball in the forward direction of the movement vector
        MoveBall();

        //Apply the brakes if necessary
        ApplyBrakes();
    }

    private void CheckIfGrounded()
    {
        //Projects a downward raycast from the center of the ball just over the length of its radius to check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1, 0), ((ballMesh.transform.localScale.y) + 0.1f), groundLayer, QueryTriggerInteraction.Ignore);
    }

    //Calculates any changes in the variables that influence the movement
    private void UpdateMovementVariables()
    {
        //Calculate head distance and move direction
        headDistance = Vector3.Distance(movementVector.transform.position, movementVector.targetPosition);
        moveDirection = movementVector.transform.forward;

        //Calculates the movement speed
        speed = headDistance * speedMultiplier;

        //Caps the movement speed
        if (speed > speedMax)
        {
            speed = speedMax;
        }

        Debug.Log("Current Speed: " + speed);
    }

    private void MoveBall()
    {
        //Don't move ball if the player is centered in the play area
        if (headDistance < moveDeadzone)
        {
            return;
        }

        
        //Calculate the movement force
        Vector3 moveForce = speed * moveDirection;

        //Makes sure that no y force is included in the moveforce calculation
        Vector3 finalMoveForce = new Vector3(moveForce.x, 0, moveForce.z);

        //Add movement force in target direction
        ballRb.AddForce(finalMoveForce);

        Debug.Log("Current Move Force: " + finalMoveForce);
    }

    private void ApplyBrakes()
    {
        if (headDistance > moveDeadzone)
        {
            return;
        }
        if (!isGrounded)
        {
            return;
        }
        if (speed <= 0)
        {
            return;
        }

        //Moves the x and z velocity toward zero
        Vector3 targetVelocity = Vector3.MoveTowards(ballRb.linearVelocity, Vector3.zero, ((speedMultiplier / brakesFactor) * Time.deltaTime));
        ballRb.linearVelocity = new Vector3 (targetVelocity.x, ballRb.linearVelocity.y, targetVelocity.z);
    }

    private void Dash(InputAction.CallbackContext context)
    {
        //The dash button shouldn't work if dashing isn't enabled
        if (!dashReady)
        {
            return;
        }

        //Apply a slight vertical force on the dash
        Vector3 verticalForce = new Vector3(0, (dashForce / 2), 0);
        Vector3 dashDirection = new Vector3(movementVector.head.forward.x, 0, movementVector.head.forward.z);

        //Shoots the ball in the direction of the movement vector
        ballRb.linearVelocity += (dashForce * dashDirection) + verticalForce;
        dashReady = false;
        StartCoroutine(DashCooldown());
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashDelay);
        dashReady = true;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //The jump button shouldn't work if jumping isn't enabled
        if (!jumpReady)
        {
            return;
        }
        if (!isGrounded)
        {
            return;
        }

        //Propels the ball upward
        ballRb.linearVelocity += (jumpForce * new Vector3(0, 1, 0));
        jumpReady = false;
        StartCoroutine (JumpCooldown());
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpDelay);
        jumpReady = true;
    }
}
