using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController_Player2 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool useWand = Input.GetButtonDown("UseWand") || Input.GetButtonDown("ReverseGravity") || Input.GetButtonDown("NormalGravity");

        if (Input.GetAxis("HorizontalJoy2Left") != 0 || Input.GetAxis("VerticalJoy2Left") != 0)
        {
            if (Input.GetButtonDown("JumpJoy2"))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isJumping", true);

            }
            else if (useWand)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isStaffing", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isStaffing", false);
                animator.SetBool("isWalking", true);
            }
        }
        else animator.SetBool("isWalking", false);

        if (useWand) animator.SetBool("isStaffing", true);
        else animator.SetBool("isStaffing", false);

        if (Input.GetButtonDown("JumpJoy2")) animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);
    }

    public void player2Dead()
    {
        animator.SetTrigger("isDead");
    }
}
