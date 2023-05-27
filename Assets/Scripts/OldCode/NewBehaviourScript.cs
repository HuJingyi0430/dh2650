using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody my_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            Vector3 my_Input = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            my_Rigidbody.MovePosition(transform.position + my_Input * Time.deltaTime * 5f);
        }
    }
}

/*public class NewBehaviourScript : MonoBehaviour
{
    Transform tran;
    Transform cameraTran;
    Transform feet;

    Rigidbody rigid;

    LayerMask mask;

    float speed = 3;
    float jumpHeight = 5;

    void Start()
    {
        tran = GetComponent<Transform>();
        cameraTran = tran.Find("CameraCenter");
        feet = tran.Find("Feet");

        rigid = GetComponent<Rigidbody>();

        mask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        float horizontalJoy = Input.GetAxis("Horizontal");
        float verticalJoy = Input.GetAxis("Vertical");

        Vector3 cameraForwardDir = cameraTran.forward;
        Vector3 cameraSideDir = cameraTran.right;

        cameraForwardDir = new Vector3(cameraForwardDir.x, 0, cameraForwardDir.z).normalized;
        cameraSideDir = new Vector3(cameraSideDir.x, 0, cameraSideDir.z).normalized;

        if (horizontalJoy != 0 || verticalJoy != 0)
        {
            float currentVelocityY = rigid.velocity.y;
            rigid.velocity = (cameraForwardDir * verticalJoy * speed) + (cameraSideDir * horizontalJoy * speed);
            rigid.velocity = new Vector3(rigid.velocity.x, currentVelocityY, rigid.velocity.z);
        }

        bool grounded = Physics.Raycast(feet.position, Vector3.down, 0.5f, mask);
        Debug.Log(grounded);
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
*/
