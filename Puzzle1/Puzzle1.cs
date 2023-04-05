using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    // Start is called before the first frame update
    bool triggered;
    Collider collider;
    void Start()
    {
        triggered = false;
        collider = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            float H, S, V;
            Color.RGBToHSV(collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), out H, out S, out V);
            collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(H, 1, V));
            Color.RGBToHSV(this.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), out H, out S, out V);
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(H, 1, V));
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        // Destroy the shell if it hits something (e.g. rock, ground, enemytank, etc.). 
        // If the shell hits enemy tank, the enemy tank will also be destroyed.
        // Your code here.
        //collision.gameObject.Destroy;
        Debug.Log(col.gameObject.name);

        if (col.gameObject.tag == this.gameObject.tag)
        {

            Debug.Log("Hello there my darling");
            collider = col;
            triggered = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        // Destroy the shell if it hits something (e.g. rock, ground, enemytank, etc.). 
        // If the shell hits enemy tank, the enemy tank will also be destroyed.
        // Your code here.
        //collision.gameObject.Destroy;
        Debug.Log(col.gameObject.name);

        if (col.gameObject.tag == this.gameObject.tag)
        {

            triggered = false;

            float H, S, V;
            Color.RGBToHSV(this.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), out H, out S, out V);
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(H, 1, V));
        }
    }
}
