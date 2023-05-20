using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform tran;
    Transform cameraTran;
    Transform feet;

    Rigidbody rigid;
    Animator animator;

    LayerMask mask;

    float speed = 10;
    float jumpHeight = 10;

    void Start() {
        tran = GetComponent<Transform>();
        cameraTran = tran.Find("CameraCenter");
        feet = tran.Find("Feet");

        rigid = GetComponent<Rigidbody>();

        mask = LayerMask.GetMask("land");

        foreach (Transform animationLoc in gameObject.transform)
        {
            if (animationLoc.name == "PolyArtWizardStandardMat" || animationLoc.name == "PolyArtWizardMaskTintMat")
            {
                animator = animationLoc.gameObject.GetComponent<Animator>();
            }
        }
    }

    void Update() {

        float horizontal = 0;
        float vertical = 0;
        if (gameObject.tag == "Player1") {
            horizontal = Input.GetAxis("Horizontal2"); // HorizontalJoyLeft
            vertical = Input.GetAxis("Vertical2"); //VerticalJoyLeft
        }
        else if (gameObject.tag == "Player2") {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }

        Vector3 cameraForwardDir = cameraTran.forward;
        Vector3 cameraSideDir = cameraTran.right;

        cameraForwardDir = new Vector3(cameraForwardDir.x, 0, cameraForwardDir.z).normalized;
        cameraSideDir = new Vector3(cameraSideDir.x, 0, cameraSideDir.z).normalized;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dizzy") || animator.GetCurrentAnimatorStateInfo(0).IsName("Die") || animator.GetCurrentAnimatorStateInfo(0).IsName("DieRecovery"))
        {
            //print("get dizzy state");
            speed = 0;
        }
        else
        {
            speed = 10;
        }
        if (horizontal != 0 || vertical != 0) {
            float currentVelocityY = rigid.velocity.y;
            rigid.velocity = (cameraForwardDir * vertical * speed) + (cameraSideDir * horizontal * speed);
            rigid.velocity = new Vector3(rigid.velocity.x, currentVelocityY, rigid.velocity.z);
        }

        bool grounded = Physics.Raycast(feet.position, Vector3.down, 0.5f, mask);
        bool jump = false;
        if (gameObject.tag == "Player1") jump = Input.GetButtonDown("JumpJoy");
        else if (gameObject.tag == "Player2") jump = Input.GetButtonDown("Jump");
        if (grounded && jump) {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            print("jump pressed");
        } 
    }
}
