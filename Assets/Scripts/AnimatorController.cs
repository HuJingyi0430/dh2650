using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Transform tran;
    Rigidbody parentRigid;

    void Start() {
        tran = GetComponent<Transform>();
        parentRigid = tran.parent.GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 dirOfPlayer = new Vector3(parentRigid.velocity.x, 0, parentRigid.velocity.z);
        if (dirOfPlayer.magnitude > 0.1) tran.rotation = Quaternion.LookRotation(dirOfPlayer);
    }
}
