using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool on;
    public GameObject cable;
    Material mat;
    // Start is called before the first frame update

    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        if (!on) mat.SetFloat("_Blend", 1);
        cable.GetComponent<Cable>().Switch(on);
    }

    void SwitchColor()
    {
        on = !on;
        if (on) mat.SetFloat("_Blend", 0);
        else mat.SetFloat("_Blend", 1);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.name=="Player1" || collision.name == "Player2")
        {
            SwitchColor();
            cable.GetComponent<Cable>().Switch(on);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "Player1" || collision.name == "Player2")
        {
            SwitchColor();
            cable.GetComponent<Cable>().Switch(on);
        }
    }
}
