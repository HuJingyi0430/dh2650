using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController_Player1 : MonoBehaviour
{
    Animator animator;
    bool grabbing;
    // Start is called before the first frame update
    void Start()
    {
        grabbing = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(Input.GetAxis("HorizontalJoyLeft") != 0 || Input.GetAxis("VerticalJoyLeft") != 0)
        if (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0)
         {
            if (Input.GetButtonDown("JumpJoy"))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isJumping", true);

            }
            else if (grabbing)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isGrabbing", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isGrabbing", false);
                animator.SetBool("isWalking", true);
            }
        }
        else animator.SetBool("isWalking", false);
        
        if (grabbing) animator.SetBool("isGrabbing", true);
        else animator.SetBool("isGrabbing", false);

        if (Input.GetButtonDown("JumpJoy")) animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);
    }

    public void Grab()
    {
        grabbing = true;
        Debug.Log("IS GRABBING");
    }
    public void StopGrab()
    {
        grabbing = false;
    }
}
