using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionCollider : MonoBehaviour {

    bool isColliding = false;

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter(Collider other) {
        if (gameObject.name == "PurpleCollider") {
            if (other.transform.GetChild(0).name == "PurpleBox") {
                isColliding = true;
                //print("purple is colliding!");
            }
        }
        else if (gameObject.name == "CyanCollider") {
            //print("Something entered the collider");
            if (other.transform.GetChild(0).name == "CyanBox") {
                isColliding = true;
                //print("cyan is colliding!");
            }
        }
        
    }

    void OnTriggerExit(Collider other) {
        if (gameObject.name == "PurpleCollider") {
            if (other.transform.GetChild(0).name == "PurpleBox") {
                isColliding = false;
            }
        }
        else if (gameObject.name == "CyanCollider") {
            if (other.transform.GetChild(0).name == "CyanBox") {
                isColliding = false;
            }
        }
    }

    public bool GetIsColliding() {
        return isColliding;
    }
}
