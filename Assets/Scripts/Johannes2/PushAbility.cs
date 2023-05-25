using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAbility : MonoBehaviour {
    Transform tran;
    Transform tranCol;

    [SerializeField]
    float pushForce;

    // Max distance to pushable object
    [SerializeField]
    float maxDisToObject;

    bool isGrabbing = false;

    void Start() {
        tran = GetComponent<Transform>();
    }

    void Update() {
        if (tranCol != null) {
            // Distance to pushable object
            float distance = (tranCol.position - tran.position).magnitude;
            if (distance > maxDisToObject) isGrabbing = false;
        }
    }

    void OnCollisionStay(Collision col) {
        if (col.gameObject.tag == "Pushable") {
            tranCol = col.gameObject.GetComponent<Transform>();
            Rigidbody rigidCol = col.gameObject.GetComponent<Rigidbody>();

            if (rigidCol != null) {
                Vector3 dir = col.transform.position - tran.position;
                dir.y = 0;
                dir = dir.normalized;

                rigidCol.AddForceAtPosition(dir * pushForce/4, tran.position, ForceMode.Impulse);
            }
            isGrabbing = true;
        }
    }

    public bool GetIsGrabbing() {
        return isGrabbing;
    }
}
