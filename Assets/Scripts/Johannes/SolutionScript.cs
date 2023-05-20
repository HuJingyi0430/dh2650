using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour {

    SolutionCollider col1;
    SolutionCollider col2;

    void Start() {
        col1 = GameObject.Find("CyanCollider").GetComponent<SolutionCollider>();
        col2 = GameObject.Find("PurpleCollider").GetComponent<SolutionCollider>();
    }

    void Update() {
        print("col1: " + col1.GetIsColliding() + " col2: " + col2.GetIsColliding());
        if (col1.GetIsColliding() && col2.GetIsColliding()) {
            FindObjectOfType<ChangeColor>().ColorAllPuzzles();
        }
    }
}
