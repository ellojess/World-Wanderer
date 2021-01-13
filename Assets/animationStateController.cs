using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f; // velocity to control animation 
    public float acceleration = 0.4f;
    public float deceleration = 0.8f;
    int VelocityHash;

    public float MaxWalkingSpeed = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // set reference for animator 
        animator = GetComponent<Animator>();

        // inceases performance 
        VelocityHash = Animator.StringToHash("Velocity");
        
    }

    // Update is called once per frame
    void Update()
    {
        // get key input from player 
        bool forwardPressed = Input.GetKey("w"); // walk trigger
        bool runPressed = Input.GetKey("r"); // run trigger 

        // logic for acceleration: if walking key is triggered 
        if (forwardPressed && velocity < MaxWalkingSpeed)
        {
            // increase velocity at a steady rate based on .deltaTime 
            velocity += Time.deltaTime * acceleration; 
        }

        // if walking and running keys are pressed (dynamic movement in between)
        if (runPressed && forwardPressed && velocity < 1.0f)
        {
            // increase velocity at a steady rate based on .deltaTime 
            velocity += Time.deltaTime * acceleration;
        }

        // slow down when walking button is released 
        if (!forwardPressed && velocity > 0.0f) // added condition to limit velocity 
        {
            // decrease velocity at a steady rate 
            velocity -= Time.deltaTime * deceleration; 
        }

        // if moving keys are removed but character is still moving 
        if ((!forwardPressed || !runPressed) && velocity > MaxWalkingSpeed)
        {
            // decrease velocity at a steady rate, 
            velocity -= Time.deltaTime * deceleration;
        }

        // set velocity back to 0 if it ever drops below 0 
        if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f; 
        }

        // set animator's velocity param to locally defined velocity variable 
        animator.SetFloat(VelocityHash, velocity);
    }
}
