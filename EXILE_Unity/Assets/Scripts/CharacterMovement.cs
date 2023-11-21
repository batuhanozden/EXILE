using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;
using Debug = UnityEngine.Debug;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class CharacterMovement : MonoBehaviour
{
    public AudioSource footstepSound;
    public Transform cam;
    
    public float turnSmoothTime = 0.4f;

    private float turnSmoothVelocity = 0.0f;
    // private bool mRunning = false;
    
    
    private Rigidbody myRigidbody;
    
    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    
    // private float scrollSpeed = 10f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    
    private float yaw;
    private float pitch;


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.freezeRotation = true;
        myRigidbody.useGravity = false;

        cam = Camera.main.transform;
    }
    
    void Update()
    {
        if(Input.GetKey("left shift"))
        {
            speed = 4f;
        }
        
        if (!Input.GetKey("left shift"))
        {
        
            speed = 2f;
        
        }
    }
    
    
    void FixedUpdate () {
        if (grounded) {
            // Calculate how fast we should be moving

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            

            Vector3 targetVelocity = new Vector3(horizontal, 0, vertical);
            targetVelocity = Camera.main.transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg+ Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime, 800.0f);

            if (horizontal != 0 || vertical != 0)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = myRigidbody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            myRigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
            // Jump
            if (canJump && Input.GetButton("Jump")) {
                myRigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }
 
        // We apply gravity manually for more tuning control
        myRigidbody.AddForce(new Vector3 (0, -gravity * myRigidbody.mass, 0));
 
        grounded = false;
    }
 
    void OnCollisionStay () {
        grounded = true;
    }
 
    float CalculateJumpVerticalSpeed () {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(jumpHeight * gravity);
    }
}
