using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private bool colliding;
    private int direction;
    private Rigidbody collider;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            if (Input.GetKey("f") && collider != null) {
                if((collider.position-m_Rigidbody.position).magnitude <= (distance.magnitude + 0.5f))
                {
                    Vector3 my_Input = new Vector3(0, 0, Input.GetAxis("Vertical"));
                    collider.MovePosition(m_Rigidbody.position + (distance*1.1f));
                }
                else { colliding = false; }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the shell if it hits something (e.g. rock, ground, enemytank, etc.). 
        // If the shell hits enemy tank, the enemy tank will also be destroyed.
        // Your code here.
        //collision.gameObject.Destroy;
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Box1")
        {
            Debug.Log("Hello");
            collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0, 1));
            //collision.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1, 1)*3);
            colliding = true;
            collider = collision.rigidbody;
            distance = (collider.position-m_Rigidbody.position);
        }
        if (collision.gameObject.name == "Mushroom")
        {
            Destroy(collision.gameObject);
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",new Color(0, 0, 0, 1));
        }
    }
    

}
