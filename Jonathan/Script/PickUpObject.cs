using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private bool colliding;
    private Collision collated_object;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        colliding = false;
        collated_object = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            if((collated_object.rigidbody.position-m_Rigidbody.position).magnitude <= (distance.magnitude + 0.5f))
            {
                if ((Input.GetButton("GrabJoy") && this.gameObject.tag == "Player1" && collated_object != null) || (Input.GetKey("f") && this.gameObject.tag == "Player2" && collated_object != null))
                {
                    Vector3 my_Input = new Vector3(0, 0, Input.GetAxis("Vertical"));
                    collated_object.rigidbody.MovePosition(m_Rigidbody.position + (distance * 1.1f));
                }
            } else { 
                colliding = false;
                FindObjectOfType<FadeToGray>().DoTheFade(collated_object.gameObject.GetComponent<Renderer>());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name); // print name of collided object

        if (collision.gameObject.name == "Box")
        {
            Debug.Log("COLLISION WITH BOX!");
            //collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            collated_object = collision; // Set global variable
            colliding = true; // Activate condition
            distance = (collision.rigidbody.position-m_Rigidbody.position); // Calculate distance to collided object
            FindObjectOfType<FadeToGray>().DoTheColor(collision.gameObject.GetComponent<Renderer>());
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "RedPlane") // If on RedPlane
        {
            FindObjectOfType<FadeToGray>().DoTheFade(col.gameObject.GetComponent<Renderer>());
        }
        if (col.gameObject.name == "Mushroom") // If collided with Mushroom
        {
            Destroy(col.gameObject);
            //this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",new Color(0, 0, 0, 1));
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "RedPlane") // If no longer on RedPlane
        {
            FindObjectOfType<FadeToGray>().DoTheFade(col.gameObject.GetComponent<Renderer>());
        }
    }
}
