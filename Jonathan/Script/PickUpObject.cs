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
                if (Input.GetKey("f") && collated_object != null)
                {
                    Vector3 my_Input = new Vector3(0, 0, Input.GetAxis("Vertical"));
                    collated_object.rigidbody.MovePosition(m_Rigidbody.position + (distance * 1.1f));
                }
            } else { 
                colliding = false;
                //collider.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                float H, S, V;
                Color.RGBToHSV(collated_object.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), out H, out S, out V); // Get HSV value of collided object
                Debug.Log("Collided object's color 3 : " + collated_object.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
                collated_object.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(H, 0, V)); // Update color of collided object
                Debug.Log("Collided object's color  : " + collated_object.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
                //collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
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
            float H=0, S=0, V=0;
            collated_object = collision; // Set global variable
            Material mat = collision.gameObject.GetComponent<Renderer>().material;
            Color.RGBToHSV(mat.GetColor("_Color"), out H, out S, out V);
            Debug.Log("Collided object's color 1: " + collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
            // Put saturation of collided object to max:
            mat.SetColor("_Color", Color.HSVToRGB(H, 1, V));
            Debug.Log("Collided object's color 2: "+collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
            colliding = true; // Activate condition
            distance = (collision.rigidbody.position-m_Rigidbody.position); // Calculate distance to collided object
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "RedPlane") // If on RedPlane
        {
            float H, S, V;
            Color.RGBToHSV(col.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), out H, out S, out V);
            // Put saturation of plane to max
            col.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(H, 1, V));
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
            float H, S, V;
            Color.RGBToHSV(col.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), out H, out S, out V);
            // Put saturation of plane to min
            col.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(H, 0, V));
        }
    }
}
