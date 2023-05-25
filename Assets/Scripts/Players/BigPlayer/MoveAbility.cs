using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbility : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private bool colliding;
    private Collision collated_object;
    Vector3 distance;
    animationStateController animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = FindObjectOfType<animationStateController>();
        m_Rigidbody = GetComponent<Rigidbody>();
        colliding = false;
        collated_object = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            if((collated_object.rigidbody.position-m_Rigidbody.position).magnitude <= (distance.magnitude + 0.2f))
            {
                // if ( Input.GetButton("GrabJoy") && collated_object != null) collated_object.rigidbody.MovePosition(m_Rigidbody.position + (distance * 1.1f));
                animation.Grab();
            } else { 
                colliding = false;
                animation.StopGrab();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name); // print name of collided object

        if (collision.gameObject.name == "Box")
        {
            Debug.Log("COLLISION WITH BOX!");
   
            collated_object = collision; // Set global variable
            colliding = true; // Activate condition
            distance = (collision.rigidbody.position-m_Rigidbody.position); // Calculate distance to collided object
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Mushroom") // If collided with Mushroom
        {
            Destroy(col.gameObject);
        }
    }
}
