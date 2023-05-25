using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoof : MonoBehaviour
{
    Transform tranOfParent;

    Rigidbody rigidOfCylinder;

    // Gravity object 1 is colliding
    bool isColliding1 = false;
    // Gravity object 2 is colliding
    bool isColliding2 = false;

    bool activeRoofRotation = false;

    float rotationScale = 0.25f;

    // The Z rotation of the parent upon first running the script
    float startZRotation;

    bool activateOnce = true;

    void Start()
    {
        tranOfParent = transform.parent;

        rigidOfCylinder = GameObject.Find("PushableCylinder").GetComponent<Rigidbody>();

        startZRotation = tranOfParent.eulerAngles.z;
    }

    void Update()
    {
        if (activeRoofRotation)
        {
            if (activateOnce)
            {
                print("Force will be applied next!");
                rigidOfCylinder.AddForce(Vector3.right * 100, ForceMode.Impulse);
                activateOnce = false;
            }

            if (tranOfParent.eulerAngles.z > 270 || tranOfParent.eulerAngles.z == 0) RotateRoof90();
        }
    }

    // Rotate roof 90 degrees
    void RotateRoof90()
    {
        tranOfParent.Rotate(Vector3.forward, -rotationScale);
        if (rotationScale < 2) rotationScale += 0.1f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "GravityObject1") isColliding1 = true;
        if (col.gameObject.name == "GravityObject2") isColliding2 = true;

        if (isColliding1 && isColliding2) activeRoofRotation = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "GravityObject1") isColliding1 = false;
        if (col.gameObject.name == "GravityObject2") isColliding2 = false;
    }
}