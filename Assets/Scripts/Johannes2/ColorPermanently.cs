using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPermanently : MonoBehaviour {

    Renderer[] ren;

    string[] colorOfRen;

    float lightObjectColor = 0.025f;

    void Start() {
        NewLightAbility[] lightAbilityObjects = FindObjectsOfType<NewLightAbility>();
        ren = new Renderer[lightAbilityObjects.Length];
        colorOfRen = new string[lightAbilityObjects.Length];
        for (int i = 0; i < lightAbilityObjects.Length; i++) {
            ren[i] = lightAbilityObjects[i].gameObject.GetComponent<Renderer>();
            colorOfRen[i] = lightAbilityObjects[i].GetColorOfObject();
        }
        this.enabled = false;
    }

    void Update() {
        ChangeColorPermanently();
    }

    void ChangeColorPermanently() {
        for (int i = 0; i < ren.Length; i++) {
            if (lightObjectColor > 1) this.enabled = false;

            if (colorOfRen[i] == "Red") ren[i].material.color = new Color(lightObjectColor, 0, 0);
            else if (colorOfRen[i] == "Green") ren[i].material.color = new Color(0, lightObjectColor, 0);
            else if (colorOfRen[i] == "Blue") ren[i].material.color = new Color(0, 0, lightObjectColor);

            if (lightObjectColor < 1) lightObjectColor += 0.01f;
            else lightObjectColor = 1;
        }
    }
}
