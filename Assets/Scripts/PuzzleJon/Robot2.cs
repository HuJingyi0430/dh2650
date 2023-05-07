using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2 : MonoBehaviour
{
    bool rollband = true;
    public GameObject player1;
    public GameObject player2;
    Quaternion _lookRotation;
    Vector3 d1;
    Vector3 d2;
    Rigidbody m_Rigidbody;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("9")) {
            rollband = false;
            anim.SetBool("isWalking", true);
        }
        if (rollband) {
            transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime;
            if (transform.localPosition.x > 16) transform.localPosition = new Vector3(-16, transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            d1 = player1.transform.position - this.transform.position;
            d2 = player2.transform.position - this.transform.position;
            if (d1.magnitude < d2.magnitude)
            {
                this.transform.position +=  d1.normalized * 2 * Time.deltaTime;
                //create the rotation we need to be in to look at the target
                _lookRotation = Quaternion.LookRotation(d1.normalized);

                //rotate us over time according to speed until we are in the required rotation
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, _lookRotation, Time.deltaTime * 100);
            }
            else
            {
                //this.m_Rigidbody.AddForce(d2.normalized * 1f);
                this.transform.position += d2.normalized * 2 * Time.deltaTime;  
                //create the rotation we need to be in to look at the target
                _lookRotation = Quaternion.LookRotation(d2.normalized);

                //rotate us over time according to speed until we are in the required rotation
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, _lookRotation, Time.deltaTime * 100);

            }
        }
        
    }
}
