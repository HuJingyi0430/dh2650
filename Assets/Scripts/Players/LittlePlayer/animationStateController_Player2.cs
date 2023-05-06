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
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isJumping", true);

            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);

            if (Input.GetButtonDown("Jump")) animator.SetBool("isJumping", true);
            else animator.SetBool("isJumping", false);
        }
    }

    public void player2Dead()
    {
        animator.SetTrigger("isDead");
    }
}
