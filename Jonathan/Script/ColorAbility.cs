using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAbility : MonoBehaviour
{
    private bool triggered;
    private Collider collided;
    private bool startedStaffing;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        collided = null;
        startedStaffing = false;
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
            if(!Input.GetKey("f") && startedStaffing) { 
                FindObjectOfType<FadeToGray>().DoTheFade(collided.gameObject.GetComponent<Renderer>());
                startedStaffing = false;
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
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Box" || col.gameObject.name == "RedPlane")
        {
            triggered = false;
            collided = null;
            //FindObjectOfType<FadeToGray>().DoTheFade(col.gameObject.GetComponent<Renderer>());
        }
    }
}
