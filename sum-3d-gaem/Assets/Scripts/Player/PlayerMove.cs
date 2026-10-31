using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    public Vector3 gravityModifier;

    [Header("Input")]

    public InputActionReference jumpAction;

    public InputActionReference moveAction;
    Vector2 moveInput;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y-(playerHeight * 0.5f + 0.3f), transform.position.z), Color.red);

        MyInput();
        SpeedControl();


        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 1f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {

        moveInput = moveAction.action.ReadValue<Vector2>();

        if(jumpAction.action.IsPressed() && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier + gravityModifier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce + gravityModifier, ForceMode.VelocityChange);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}