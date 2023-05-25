using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot3 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void KillRobot()
    {
        animator.SetBool("isDead", true);
        this.GetComponentInChildren<Light>().enabled = false;
    }
}
