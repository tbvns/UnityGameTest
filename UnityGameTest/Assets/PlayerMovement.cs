using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float Gravity = -19f;
    Vector3 Velocity;
    public Transform groundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float JumpHeight = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);

        if (isGrounded && Velocity.y < 0) { 
            Velocity.y = 0f;
        }

        float X = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            controller.Move(Velocity * Time.deltaTime);
        }

    }
}
