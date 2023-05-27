using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGoal : MonoBehaviour
{
    ChangeColor changeColor;

    ColorPermanently colorPermanently;

    SpriteRenderer renOfInstructions;

    void Start() {
        changeColor = GameObject.Find("Environment").GetComponent<ChangeColor>();
        colorPermanently = GetComponent<ColorPermanently>();
        renOfInstructions = GameObject.Find("InstructionSprite").GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "PushableCylinder") {
            colorPermanently.enabled = true;
            renOfInstructions.enabled = false;
            changeColor.ColorPuzzle("PuzzleArea1");
        }
    }
}
