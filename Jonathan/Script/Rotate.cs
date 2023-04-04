using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform tran;
    float rotationSpeed = 2;

    void Start()
    {
        tran = GetComponent<Transform>();
    }

    void Update()
    {
        float horizontalJoy = Input.GetAxis("Mouse X");
        float verticalJoy = Input.GetAxis("Mouse Y");

        if (horizontalJoy != 0 || verticalJoy != 0)
        {
            tran.Rotate(verticalJoy * rotationSpeed, horizontalJoy * rotationSpeed, 0);
            tran.eulerAngles = new Vector3(tran.eulerAngles.x, tran.eulerAngles.y, 0);
        }

    }
}