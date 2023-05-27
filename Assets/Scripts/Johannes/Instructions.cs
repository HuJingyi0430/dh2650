using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

    SpriteRenderer renInstructions;

    Transform tran;

    Transform tranR1Button;
    SpriteRenderer renR1Button;

    Transform cameraOfPlayer2;
    Transform tranOfPlayer2;
    Transform tranGoal;

    bool once = true;

    void Start() {
        renInstructions = GetComponent<SpriteRenderer>();
        tran = GetComponent<Transform>();

        tranR1Button = GameObject.Find("R1Sprite").GetComponent<Transform>();
        renR1Button = tranR1Button.gameObject.GetComponent<SpriteRenderer>();

        cameraOfPlayer2 = GameObject.Find("PlayerBase2").GetComponent<Transform>().Find("CameraCenter").Find("Main Camera");
        tranOfPlayer2 = GameObject.Find("PlayerBase2").GetComponent<Transform>();
        tranGoal = GameObject.Find("Goal").GetComponent<Transform>();
    }

    void Update() {
        tranR1Button.LookAt(cameraOfPlayer2);
        tran.LookAt(cameraOfPlayer2);

        float distanceToPlayer2 = (tranOfPlayer2.position - tranGoal.position).magnitude;
        if (distanceToPlayer2 < 5 && Input.GetButtonDown("UseWand") && once) {
            once = false;
            renR1Button.enabled = false;
            renInstructions.enabled = true;
        }
    }
}
