using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGoal : MonoBehaviour
{
    ChangeColor changeColor;

    ColorPermanently colorPermanently;

    void Start() {
        changeColor = GameObject.Find("Environment").GetComponent<ChangeColor>();
        colorPermanently = GetComponent<ColorPermanently>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "PushableCylinder") {
            colorPermanently.enabled = true;
            changeColor.ColorPuzzle("PuzzleArea2");
        }
    }
}
