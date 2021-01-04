using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptController : MonoBehaviour
{
    Animator animator; 
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        // Debug.Log(animator);
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("r");

        // if player presses w
        if (!isWalking && forwardPressed)
        {
            // then set isWalking to true 
            animator.SetBool(isWalkingHash, true);
        }

        // if player does not press w
        if (isWalking && !forwardPressed)
        {
            // then set isWalking to false 
            animator.SetBool(isWalkingHash, false);
        }
        
        // if player is walking and not running and presses left shift 
        if (!isRunning && (forwardPressed && runPressed))
        {
            // then set isRunning bool to true 
            animator.SetBool(isRunningHash, true);
        }

        // if player is runnings and stops running or stops walking 
        if (isRunning && (!forwardPressed || !runPressed))
        {
            // then set isRunning bool to false 
            animator.SetBool(isRunningHash, false);
        }

    }
}
