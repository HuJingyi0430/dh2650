using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTile : MonoBehaviour
{
    public bool active;
    Renderer render;
    public GameObject cable;
    Renderer[] cable_renderer;
    // Start is called before the first frame update
    void Start()
    {
        render = this.GetComponent<Renderer>();
        FindObjectOfType<FadeToGray>().DoTheFade(render);
        cable_renderer = cable.GetComponentsInChildren<Renderer>();
        foreach (Renderer cable in cable_renderer)
        {
            cable.material.SetFloat("_Blend", 1);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!FindObjectOfType<ActivateLab>().active && (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2"))
        {
            render.material.SetFloat("_Blend", 0);
            foreach (Renderer cable in cable_renderer)
            {
                cable.material.SetFloat("_Blend", 0);
            }
            if (this.name == "Tile1") FindObjectOfType<ActivateLab>().ActivateTile("Tile1");
            else if (this.name == "Tile2") FindObjectOfType<ActivateLab>().ActivateTile("Tile2");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            if (!FindObjectOfType<ActivateLab>().active)
            {
                render.material.SetFloat("_Blend", 1);
                foreach (Renderer cable in cable_renderer)
                {
                    cable.material.SetFloat("_Blend", 1);
                }
                if (this.name == "Tile1") FindObjectOfType<ActivateLab>().DeactivateTile("Tile1");
                else if (this.name == "Tile2") FindObjectOfType<ActivateLab>().DeactivateTile("Tile2");
            }
        }
    }


}
