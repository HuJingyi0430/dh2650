
using System.Collections;
using UnityEngine;

public class FadeToGray : MonoBehaviour
{
    public void DoTheFade(Renderer renderer)
    {
        StartCoroutine(DoTheFadeCR(renderer));
    }

    private IEnumerator DoTheFadeCR(Renderer renderer)
    {
        float time = 0;
        while (time < 1f)
        {
            foreach (Material currentmaterial in renderer.materials)
            {
                currentmaterial.SetFloat("_Blend", time);
            }
            time += Time.deltaTime;
            yield return null;
        }

        renderer.material.SetFloat("_Blend", 1);
    }




    public void DoTheColor(Renderer renderer)
    {
        StartCoroutine(DoTheColorCR(renderer));
    }

    private IEnumerator DoTheColorCR(Renderer renderer)
    {
        float time = 0;
        while (time < 1f)
        {
            foreach (Material currentmaterial in renderer.materials)
            {
                currentmaterial.SetFloat("_Blend", 1-time);
            }
            time += Time.deltaTime;
            yield return null;
        }

        foreach (Material currentmaterial in renderer.materials)
        {
            currentmaterial.SetFloat("_Blend", 0);
        }
    }
}