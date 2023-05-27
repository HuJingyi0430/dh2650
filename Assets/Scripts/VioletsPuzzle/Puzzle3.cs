using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Numerics;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    // Start is called before the first frame update
    bool triggered;
    Collider the_collider;
    void Start()
    {
        triggered = false;
        the_collider = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            if (checkCrossCorrect(the_collider.gameObject.transform.eulerAngles.x))
            {
                FindObjectOfType<FadeToGray>().DoTheColor(this.gameObject.GetComponent<Renderer>());
                FindObjectOfType<FadeToGray>().DoTheColor(the_collider.gameObject.GetComponent<Renderer>());
                the_collider.gameObject.GetComponent<Rigidbody>().mass = 100;
                //this.gameObject.GetComponent<Collider>().isTrigger = false;
                //FindObjectOfType<ChangeColor>().ColorPuzzle("PuzzleArea3");
            }
            else {
                FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
                FindObjectOfType<FadeToGray>().DoTheFade(the_collider.gameObject.GetComponent<Renderer>());
            }
        }
        else
        {
            if(the_collider != null) { 
                FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
                FindObjectOfType<FadeToGray>().DoTheFade(the_collider.gameObject.GetComponent<Renderer>());
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == this.gameObject.tag)
        {
                print(col.gameObject.transform.localRotation.x);
            the_collider = col;
                triggered = true;
                //FindObjectOfType<FadeToGray>().DoTheColor(collider.gameObject.GetComponent<Renderer>());
        }
    }
    private void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == this.gameObject.tag)
        {
            triggered = false;
            FindObjectOfType<FadeToGray>().DoTheFade(this.gameObject.GetComponent<Renderer>());
            FindObjectOfType<FadeToGray>().DoTheFade(col.gameObject.GetComponent<Renderer>());
        }
    }



    public void putCrossCorrect(Transform Transformed)
    {
       
        if (Transformed.gameObject.tag == this.gameObject.tag)
        {
        Transformed.Rotate(90, 0, 0);
        Transformed.position = this.gameObject.transform.position;
        }
    }

     private bool checkCrossCorrect(float xnumber)
    {
        //print(xnumber);
        bool result;
        result = ((xnumber < 360) && (350 < xnumber)) || ((xnumber < 10) && (10 < xnumber));
        return result;
    }




}