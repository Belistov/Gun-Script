using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float sprintSpeed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        // Set speed based on sprinting and crouching
        float currentSpeed;
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        // Move player
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
