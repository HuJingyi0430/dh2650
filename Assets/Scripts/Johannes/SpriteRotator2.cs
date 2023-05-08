using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator2 : MonoBehaviour
{
    Transform tran;

    Transform anchor;
    Transform cameraOfPlayer2;

    SpriteRenderer ren;

    GravityController gravityScript;

    bool allowDestruction = false;

    void Start() {
        tran = GetComponent<Transform>();
        anchor = GameObject.Find("PlayerBase2").GetComponent<Transform>();

        cameraOfPlayer2 = anchor.Find("CameraCenter").Find("Main Camera");
        ren = GetComponent<SpriteRenderer>();
        ren.enabled = false;

        gravityScript = GameObject.Find("GravityObject1").GetComponent<GravityController>();
    }

    void Update() {
        tran.position = anchor.position + new Vector3(0, 1.5f, 0);
        tran.LookAt(cameraOfPlayer2);

        if (gravityScript.GravityIsReversed()) {
            ren.enabled = true;
            allowDestruction = true;
        }
        if (!gravityScript.GravityIsReversed() && allowDestruction) Destroy(gameObject);
    }
}
