using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLightAbility : MonoBehaviour {

    Transform tran;

    GameObject player2;
    Transform player2Tran;

    Renderer ren;

    [SerializeField]
    string colorOfObject;

    [SerializeField]
    float maxDistanceToPlayer2;
    // The color value as a float
    float currentColorValue = 0.025f;
    float minColorValue;

    // The speed at which the color changes
    float colorChangeSpeed = 0.025f;

    bool activeLightAbility = false;

    void Start() {
        tran = GetComponent<Transform>();
        player2 = GameObject.Find("PlayerBase2");
        player2Tran = player2.GetComponent<Transform>();

        ren = GetComponent<Renderer>();

        minColorValue = currentColorValue;

        if (colorOfObject == "Red") ren.material.color = new Color(currentColorValue, 0, 0);
        else if (colorOfObject == "Green") ren.material.color = new Color(0, currentColorValue, 0);
        else if (colorOfObject == "Blue") ren.material.color = new Color(0, 0, currentColorValue);
    }

    void Update() {
        float distanceToPlayer2 = (player2Tran.position - tran.position).magnitude;
        if (distanceToPlayer2 < maxDistanceToPlayer2 && Input.GetButtonDown("UseWand")) activeLightAbility = true;

        if (activeLightAbility) ChangeColor(colorChangeSpeed);
        else if (!activeLightAbility && currentColorValue > minColorValue) ChangeColor(-colorChangeSpeed);
    }

    void ChangeColor(float additiveValue) {
        Color changingColor = new Color();
        if (colorOfObject == "Red") changingColor = new Color(currentColorValue, 0, 0);
        else if (colorOfObject == "Green") changingColor = new Color(0, currentColorValue, 0);
        else if (colorOfObject == "Blue") changingColor = new Color(0, 0, currentColorValue);
        ren.material.color = changingColor;
        currentColorValue += additiveValue;
        if (currentColorValue >= 1) activeLightAbility = false;
    }

    public string GetColorOfObject() {
        return colorOfObject;
    }
}
