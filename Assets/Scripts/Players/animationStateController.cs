using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    bool grab;
    // Start is called before the first frame update
    void Start()
    {
        grab = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        bool jump = false;

        if (this.CompareTag("Player1"))
        {
            horizontal = Input.GetAxis("HorizontalJoyLeft"); 
            vertical = Input.GetAxis("VerticalJoyLeft");
            jump = Input.GetButtonDown("JumpJoy");
        }else if (this.CompareTag("Player2"))
        {
            horizontal = Input.GetAxis("HorizontalJoy2Left");
            vertical = Input.GetAxis("VerticalJoy2Left");
        }

        if (horizontal != 0 || vertical != 0)
         {
            if (grab) // IF RUNNING AND PUSHING
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isGrabbing", true);
            }
            else // IF JUST RUNNING
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isGrabbing", false);
                animator.SetBool("isWalking", true);
            }
        }
        else animator.SetBool("isWalking", false);
        
        // IF STILL AND PUSHING
        if (grab) animator.SetBool("isGrabbing", true);
        else animator.SetBool("isGrabbing", false);

        // IF STILL AND JUMPING
    }

    public void Grab()
    {
        grab = true;
        Debug.Log("IS GRABBING");
    }
    public void StopGrab()
    {
        grab = false;
    }

    public void playerDead()
    {
        animator.SetTrigger("isDead");
    }
}
