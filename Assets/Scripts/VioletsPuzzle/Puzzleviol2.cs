using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Puzzleviol2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool triggered;
    public bool magicDone;
    public bool isReady;
    Collider the_collider;
    Collider colliderBone;
    void Start()
    {
        triggered = false;
        magicDone = false;
        isReady = false;
        the_collider = null;
        colliderBone = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            isReady = (checkRoofCorrect(the_collider) && checkBoneCorrect(colliderBone));
        }
        else
        {
            if(the_collider != null) { 
                FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
                FindObjectOfType<FadeToGray>().DoTheFade(the_collider.gameObject.GetComponent<Renderer>());
            }
        }

        if (magicDone)
        {
            isReady = false;
            FindObjectOfType<FadeToGray>().DoTheColor(this.gameObject.GetComponent<Renderer>());
            FindObjectOfType<FadeToGray>().DoTheColor(the_collider.gameObject.GetComponent<Renderer>());
            print("do the color back pv2");
            FindObjectOfType<puzzleviol>().completesub2 = true;
        }
        else
        {
            if (the_collider != null)
            {
                FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
                FindObjectOfType<FadeToGray>().DoTheFade(the_collider.gameObject.GetComponent<Renderer>());
            }
        }

    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.tag == this.gameObject.tag)
        {
            if (collisionInfo.collider.gameObject.name == "coffinroof2")
            {
                the_collider = collisionInfo.collider;
                triggered = true;
            }
            else
            {
                colliderBone = collisionInfo.collider;
                triggered = true;
            }
            //print(collider.gameObject.name);
            //FindObjectOfType<FadeToGray>().DoTheColor(collider.gameObject.GetComponent<Renderer>());
        }
        //print(collisionInfo.collider.gameObject.name);
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.tag == this.gameObject.tag)
        {
            triggered = false;
            FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
            FindObjectOfType<FadeToGray>().DoTheFade(collisionInfo.collider.gameObject.GetComponent<Renderer>());
        }
        print("No longer in contact with " + collisionInfo.transform.name);
    }


    public void putRoofCorrect()
    {
        if (!magicDone)
        {
            Transform Transformed;
            print("do the magic");
            Transformed = this.gameObject.transform;
            Transformed.Rotate(-90, 0, 0);
            Transformed.position = Transformed.position - new Vector3(0, 4, 0);
            Transform roof = Transformed.GetChild(1);
            roof.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            magicDone = true;
        }
    }

     private bool checkRoofCorrect(Collider currentcollider)
    {
        bool result;
        //print(Vector3.Distance(this.gameObject.transform.position, currentcollider.gameObject.transform.position));
        result = (Vector3.Distance(this.gameObject.transform.position, currentcollider.gameObject.transform.position) < 0.35f);
        if (result)
        {
            if (colliderBone != null)
            {
                Transform light = colliderBone.gameObject.transform.GetChild(0);
                light.gameObject.GetComponent<Light>().intensity = 1;
            }
        }
        else {
            if (colliderBone != null)
            {
                Transform light = colliderBone.gameObject.transform.GetChild(0);
                light.gameObject.GetComponent<Light>().intensity = 10;
            }
        }
        return result;
    }
    private bool checkBoneCorrect(Collider currentcollider)
    {
        bool result;
        print(Vector3.Distance(this.gameObject.transform.position, currentcollider.gameObject.transform.position));
        result = (Vector3.Distance(this.gameObject.transform.position, currentcollider.gameObject.transform.position) < 4.3f);
        return result;
    }




}