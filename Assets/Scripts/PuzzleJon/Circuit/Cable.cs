using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public bool on;
    public GameObject gate_R;
    public GameObject gate_L;
    int counter = 0;
    public void Switch(bool val)
    {
        Renderer[] renders = this.transform.GetComponentsInChildren<Renderer>();
        on = val;
        if (!on)
        {
            foreach (Renderer render in renders)
            {
                render.material.SetFloat("_Blend", 1);
            }
        }
        else
        {
            foreach (Renderer render in renders)
            {
                render.material.SetFloat("_Blend", 0);
            }
        }
        if (gate_R != null) gate_R.GetComponent<Gate>().Switch();
        if (gate_L != null) gate_L.GetComponent<Gate>().Switch();
        if (this.CompareTag("FinishCable") && !on)
        {
            counter++;
            if (counter == 3) FindObjectOfType<ShutDownLab>().ShutDown();
        }
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        if (!on) this.GetComponent<Renderer>().material.SetFloat("_Blend", 1);
    }
    void ChangeColor(bool val)
    {
        if (on) this.GetComponent<Renderer>().material.SetFloat("_Blend", 0); // color this object yellow
        else this.GetComponent<Renderer>().material.SetFloat("_Blend", 1); // remove color from this object
        if (connection != null) // if this object has connection
        {
            if (connection.CompareTag("Cable")) connection.GetComponent<Cable>().Change(val); // change on value of cable 
            else // if connection is not cable, i.e. a gate
            {
                if (is_right_input) connection.GetComponent<Gate>().ChangeRightInput(val); // change right input of gate
                if (is_left_input) connection.GetComponent<Gate>().ChangeLeftInput(val); // change left input of gate
            }
        }
    }

    public void Change(bool val)
    {
        on = val;
        ChangeColor(val);
    }
    */
}