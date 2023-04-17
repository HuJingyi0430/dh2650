using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAbility : MonoBehaviour
{
    private bool triggered;
    private Collider collided;
    private bool startedStaffing;
    private bool freezeEnemy;
    private bool doMagicPuzzle2;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        collided = null;
        startedStaffing = false;
        freezeEnemy = false;
        doMagicPuzzle2 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggered)
        {
            if (Input.GetKey("f") && !startedStaffing ) { 
                FindObjectOfType<FadeToGray>().DoTheColor(collided.gameObject.GetComponent<Renderer>());
                startedStaffing = true;
            }
            if (Input.GetKey("f") && !doMagicPuzzle2)
            {
                Transform transformed;
                transformed = collided.gameObject.GetComponent<Transform>();
                transformed.Rotate(90, 0, 0);
                doMagicPuzzle2 = true;
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

            if (!Input.GetKey("f") && doMagicPuzzle2)
            {
                doMagicPuzzle2 = false;
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


        if (col.gameObject.name == "top1" || col.gameObject.name == "top2" || col.gameObject.name == "top3")
        {
            triggered = true;
            collided = col;
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

        if (col.gameObject.name == "top1"|| col.gameObject.name == "top2" || col.gameObject.name == "top3")
        {
            triggered = false;
            collided = null;
        }

    }
}
