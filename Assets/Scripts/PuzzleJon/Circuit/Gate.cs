using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject input_R;
    public GameObject input_L;
    public GameObject output;
    
    public void Switch()
    {
        bool input_R_on = input_R.GetComponent<Cable>().on;
        bool input_L_on = input_L.GetComponent<Cable>().on;

        if (this.CompareTag("AND"))
        {
            if (input_R_on && input_L_on) {
                foreach (Renderer render in this.transform.GetComponentsInChildren<Renderer>())
                {
                    render.material.SetFloat("_Blend", 0);
                }
                output.GetComponent<Cable>().Switch(true);
            }
            else
            {
                foreach (Renderer render in this.transform.GetComponentsInChildren<Renderer>())
                {
                    render.material.SetFloat("_Blend", 1);
                }
                output.GetComponent<Cable>().Switch(false);
            }
        }else if (this.CompareTag("OR"))
        {
            if (input_R_on || input_L_on)
            {
                this.GetComponent<Renderer>().material.SetFloat("_Blend", 0);
                output.GetComponent<Cable>().Switch(true);
            }
            else
            {
                this.GetComponent<Renderer>().material.SetFloat("_Blend", 1);
                output.GetComponent<Cable>().Switch(false);
            }
        }

    }
    /*
    void ChangeColor()
    {
        if ((this.CompareTag("AND") && (on_right && on_left)) || (this.CompareTag("OR") && (on_right || on_left)))
        {
            this.GetComponent<Renderer>().material.SetFloat("_Blend", 0);
            connection.GetComponent<Cable>().Change(true);
        } else {
            Debug.Log("Right I: " + on_right + " Left I: " + on_left);
            this.GetComponent<Renderer>().material.SetFloat("_Blend", 1);
            connection.GetComponent<Cable>().Change(false);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }
    public void ChangeRightInput(bool val)
    {
        on_right = val;
        ChangeColor();
    }
    public void ChangeLeftInput(bool val)
    {
        on_left = val;
        ChangeColor();
    }
    */
}
