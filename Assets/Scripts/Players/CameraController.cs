using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform tran;
    float rotationSpeed;

    void Start() {
        tran = GetComponent<Transform>();

        if (gameObject.tag == "Player1") rotationSpeed = 1.5f;
        else if (gameObject.tag == "Player2") rotationSpeed = 1.5f;
    }

    void Update() {
        float horizontal = 0;
        float vertical = 0;

        if (gameObject.tag == "Player1") {
            horizontal = Input.GetAxis("HorizontalJoyRight");
            vertical = Input.GetAxis("VerticalJoyRight");
        }
        else if (gameObject.tag == "Player2") {
            horizontal = Input.GetAxis("HorizontalJoy2Right");
            vertical = -Input.GetAxis("VerticalJoy2Right");
        }

        if (horizontal != 0 || vertical != 0) {
            tran.Rotate(vertical * rotationSpeed, horizontal * rotationSpeed, 0);
            tran.eulerAngles = new Vector3(tran.eulerAngles.x, tran.eulerAngles.y, 0);
        }
            
    }
}
