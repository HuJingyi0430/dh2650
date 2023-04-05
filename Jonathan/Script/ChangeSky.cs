using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
    private Camera cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSky()
    {
        cm.backgroundColor = new Color(0.4f, 0.6f, 0.7f, 1);
    }
}
