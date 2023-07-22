using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 5f;
    public float Gravity = -19f;
    Vector3 Velocity;
    public Transform groundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float JumpHeight = 1f;
    public float X = 0;
    public float Z = 0;
    public Vector3 right = Vector3.zero;
    public Vector3 forward = Vector3.zero;
    public bool wasgrounded = false;
    public bool asjumped = false;
    public float timegrounded = 0;
    public float FootStepTime;
    public SoundPack GrassSoundPack;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);

        if (isGrounded && Velocity.y < 0) { 
            Velocity.y = -2f;

            X = Input.GetAxis("Horizontal");
            Z = Input.GetAxis("Vertical");
            right = transform.right;
            forward = transform.forward;

            if (Input.GetAxis("Horizontal") != 0)
            {
                FootStep();
            } else if(Input.GetAxis("Vertical") != 0) {
                FootStep();
            }

            if (!wasgrounded && asjumped)
            {
                timegrounded = timegrounded + Time.deltaTime;
                X = Input.GetAxis("Horizontal") * timegrounded;
                Z = Input.GetAxis("Vertical") * timegrounded;
                if (timegrounded > 1) {
                    wasgrounded = true;
                    asjumped = false;
                    timegrounded = 0;
                }
            }
        } else
        {
            wasgrounded = false;
        }

        

        Vector3 move = right * X + forward * Z;

        controller.Move(move * speed * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            controller.Move(Velocity * Time.deltaTime);
            asjumped = true;
        }
    }
    public void FootStep()
    {
        FootStepTime = FootStepTime + Time.deltaTime;
        if (FootStepTime > 0.45)
        {
            int randomindex = Random.Range(0, GrassSoundPack.Container.Count);
            AudioClip sound = GrassSoundPack.Container[randomindex];
            AudioSource.GetComponent<AudioSource>().clip = sound;
            AudioSource.Play();
            FootStepTime = 0;
        }
    }
}
