using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTopOfPost : MonoBehaviour {

    void Start() {
        
    }

    void Update() {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "GravityObject")
            Destroy(gameObject);
    }
}
