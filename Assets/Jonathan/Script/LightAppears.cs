using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAppears : MonoBehaviour
{
    Light lamp;
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        lamp = transform.Find("Point Light").GetComponent<Light>();
        mesh = transform.Find("Cube").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") == true) {
            lamp.enabled = true;
            mesh.enabled = true;
        }
        else
        {
            lamp.enabled = false;
            mesh.enabled = false;
        }
    }
}
