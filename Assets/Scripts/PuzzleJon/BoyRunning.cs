using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyRunning : MonoBehaviour
{
    [SerializeField]
    Vector3 destination = new Vector3(0, 0, 0);

    public Shader shader;

    Quaternion _lookRotation;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void YouAreFree()
    {
        InvokeRepeating("Run", 0f, 0.5f);  //1s delay, repeat every 1s
    }

    void Run()
    {
        this.GetComponentInChildren<Renderer>().material.shader = shader;
        animator.SetBool("isWalking", true);
        Vector3 d = this.transform.localPosition;
        d.z = -100;
        this.transform.localRotation = Quaternion.Slerp(this.transform.localRotation, _lookRotation, Time.deltaTime * 100);
        _lookRotation = Quaternion.LookRotation(d.normalized);
        this.transform.localRotation = Quaternion.Slerp(this.transform.localRotation, _lookRotation, Time.deltaTime * 100);
        this.transform.localPosition += d.normalized * 10 * Time.deltaTime;

        if (d.magnitude < 2)
        {
            Destroy(this);
            this.enabled = false;
        }
    }
}
