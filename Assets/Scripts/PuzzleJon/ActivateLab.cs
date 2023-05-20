using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivateLab : MonoBehaviour
{
    bool tile1;
    bool tile2;
    Light tv;
    Renderer renderer;
    public GameObject cable;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        tile1 = false;
        tile2 = false;
        cable.GetComponent<Renderer>().material.SetFloat("_Blend", 1);
        tv = transform.Find("Spot Light").GetComponent<Light>();
        tv.enabled = false;
        renderer = transform.Find("Window").GetComponent<Renderer>();
    }

    void ColorWindow()
    {
        active = true;
        cable.GetComponent<Renderer>().material.SetFloat("_Blend", 0);
        tv.enabled = true;
        renderer.material.color = new Color(0.5f, 0.6f, 0.6f, 0.7f);
        try {
            StartCoroutine(FindObjectOfType<RobotAudio>().RobotSuccess());
        }
        catch (Exception e)
        {
            Debug.Log("Error!");
        }
    }

    // Update is called once per frame
    public void ActivateTile(string tile_name)
    {
        if (tile_name == "Tile1")
        {
            tile1 = true;
            if (tile2) ColorWindow();
        }
        else if (tile_name == "Tile2")
        {
            tile2 = true;
            if (tile1) ColorWindow();
        }
    }
    public void DeactivateTile(string tile_name)
    {
        if (tile_name == "Tile1") tile1 = false; 
        else if (tile_name == "Tile2") tile2 = false;
    }
}
