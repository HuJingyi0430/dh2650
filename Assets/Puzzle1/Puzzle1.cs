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
            FindObjectOfType<FadeToGray>().DoTheColor(this.gameObject.GetComponent<Renderer>());
            FindObjectOfType<FadeToGray>().DoTheColor(collider.gameObject.GetComponent<Renderer>());
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
            collider = col;
            triggered = true;
            FindObjectOfType<ChangeColor>().ColorPuzzle2();
            foreach(ChangeSky obj in FindObjectsOfTypeAll(typeof(ChangeSky)))
            {
                obj.ColorSky();
            }
            RenderSettings.fog = false;
            //FindObjectOfType<ChangeSky>().ColorSky();
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

            FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
        }
    }
}
