using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController_Player1 : MonoBehaviour
{
    Animator animator;
    PushAbility pushing;
    // Start is called before the first frame update
    void Start()
    {
        pushing = FindObjectOfType<PushAbility>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(Input.GetAxis("HorizontalJoyLeft") != 0 || Input.GetAxis("VerticalJoyLeft") != 0)
        if (Input.GetAxis("HorizontalJoyLeft") != 0 || Input.GetAxis("VerticalJoyLeft") != 0)
         {
            if (Input.GetButtonDown("JumpJoy"))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isJumping", true);

            }
            else if (pushing.GetIsGrabbing())
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
        
        if (pushing.GetIsGrabbing()) animator.SetBool("isGrabbing", true);
        else animator.SetBool("isGrabbing", false);

        if (Input.GetButtonDown("JumpJoy")) animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);
    }

    public void player1Dead()
    {
        animator.SetTrigger("isDead");
    }
}
