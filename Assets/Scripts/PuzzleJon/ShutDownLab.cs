using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDownLab : MonoBehaviour
{
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    public GameObject protector1;
    public GameObject protector2;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ShutDown()
    {
        Debug.Log("FINISHED THE PUZZLE");
        window1.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        window2.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        window3.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        protector1.GetComponent<Renderer>().material = mat;
        protector2.GetComponent<Renderer>().material = mat;
    }
}
