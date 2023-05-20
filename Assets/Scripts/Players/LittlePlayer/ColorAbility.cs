using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class ColorAbility : MonoBehaviour
{
    public bool isInvincible;
    private bool triggered;
    private Collider collided;
    private bool startedStaffing;
    private bool freezeEnemy;
    private bool doMagicPV1;
    private bool doMagicPV2;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        collided = null;
        startedStaffing = false;
        freezeEnemy = false;
        doMagicPV1 = false;
        doMagicPV2 = false;
        isInvincible = false;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInvincible == true)
        {
            timer += Time.deltaTime;
            if (timer > 4)
            {
                timer = 0;
                isInvincible = false;
            }

        }
        if (triggered)
        {
            if (Input.GetKey("f") && !startedStaffing ) { 
                FindObjectOfType<FadeToGray>().DoTheColor(collided.gameObject.GetComponent<Renderer>());
                startedStaffing = true;
            }
            if (Input.GetKey("f") && doMagicPV1 && FindObjectOfType<Puzzleviol1>().isReady)
            {
                FindObjectOfType<Puzzleviol1>().putRoofCorrect();
                doMagicPV1 = false;
            }
            if (Input.GetKey("f") && doMagicPV2 && FindObjectOfType<Puzzleviol2>().isReady)
            {
                FindObjectOfType<Puzzleviol2>().putRoofCorrect();
                doMagicPV1 = false;
            }
            if (Input.GetKey("f") && freezeEnemy)
            {
                FindObjectOfType<AIController>().animationFreeze(collided.gameObject.GetComponent<Animator>());
                freezeEnemy = false;
            }

            if (!Input.GetKey("f") && startedStaffing) { 
                FindObjectOfType<FadeToGray>().DoTheFade(collided.gameObject.GetComponent<Renderer>());
                startedStaffing = false;
            }

            if (!Input.GetKey("f") && !doMagicPV1)
            {
                doMagicPV1 = false;
            }
            if (!Input.GetKey("f") && !doMagicPV2)
            {
                doMagicPV2 = false;
            }
        }
    }


private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Box" || col.gameObject.name == "RedPlane")
        {
            triggered = true;
            collided = col;
        }

        if (col.gameObject.name == "PT_Medieval_Male_Armor_Skeleton_01")
        {
            triggered = true;
            collided = col;
            freezeEnemy = true;
        }


        if (col.gameObject.name == "coffin")
        {
            triggered = true;
            collided = col;
            doMagicPV1 = true;
        }
        if (col.gameObject.name == "coffin2")
        {
            triggered = true;
            collided = col;
            doMagicPV2 = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Box" || col.gameObject.name == "RedPlane")
        {
            triggered = false;
            collided = null;
            //FindObjectOfType<FadeToGray>().DoTheFade(col.gameObject.GetComponent<Renderer>());
        }

        if (col.gameObject.name == "PT_Medieval_Male_Armor_Skeleton_01")
        {
            triggered = false;
            collided = null;
            freezeEnemy = false;
        }

        if (col.gameObject.name == "coffin" || col.gameObject.name == "coffin2")
        {
            triggered = false;
            collided = null;
        }

    }
}
