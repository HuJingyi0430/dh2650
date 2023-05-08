using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    Rigidbody rigid;
    Transform tran;
    Transform player2Trans;

    Vector3 gravityOfWorld;
    Vector3 gravity;

    float requiredDistance = 2.5f;

    bool hasReversedGravity = false;

    void Start() {
        rigid = GetComponent<Rigidbody>();
        tran = GetComponent<Transform>();
        player2Trans = GameObject.Find("PlayerBase2").GetComponent<Transform>();

        rigid.useGravity = false;
        gravityOfWorld = Physics.gravity;
        gravity = gravityOfWorld;
    }

    void FixedUpdate() {
        rigid.AddForce(gravity, ForceMode.Acceleration);
    }

    void Update() {
        bool reverseGravity = Input.GetButtonDown("ReverseGravity");
        bool setNormalGravity = Input.GetButtonDown("NormalGravity");
        float distanceToPlayer = (player2Trans.position - tran.position).magnitude;

        if (reverseGravity && distanceToPlayer < requiredDistance) ReverseGravity(true);
        if (setNormalGravity) ReverseGravity(false);
    }

    void ReverseGravity(bool reversedGravity) {
        if (reversedGravity) gravity = -gravityOfWorld;
        else gravity = gravityOfWorld;
        hasReversedGravity = reversedGravity;
    }

    public bool GravityIsReversed() {
        return hasReversedGravity;
    } 
}
