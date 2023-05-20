using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    Transform tran;
    Transform gravityBox;

    Transform cameraOfPlayer2;

    void Start() {
        tran = GetComponent<Transform>();
        gravityBox = GameObject.Find("GravityObject1").GetComponent<Transform>();

        cameraOfPlayer2 = GameObject.Find("PlayerBase2").GetComponent<Transform>().Find("CameraCenter").Find("Main Camera");
    }

    void Update() {
        tran.position = gravityBox.position + new Vector3(0, 2, 0);
        tran.LookAt(cameraOfPlayer2);

        if (gravityBox.gameObject.GetComponent<GravityController>().GravityIsReversed()) Destroy(gameObject);
    }
}
