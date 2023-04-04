
using System.Collections;
using UnityEngine;

public class FadeToGrayPuzzle1 : MonoBehaviour
{
    //public Renderer currentrenderer;


    public void DoTheFadeP1(Renderer renderer)
    {
        StartCoroutine(DoTheFadeCRP1(renderer));
    }

    private IEnumerator DoTheFadeCRP1(Renderer renderer)
    {
        float time = 0;
        while (time < 1f)
        {
            renderer.material.SetFloat("_Blend", time);
            time += Time.deltaTime;
            yield return null;
        }

        renderer.material.SetFloat("_Blend", 1);
    }




    public void DoTheColorP1(Renderer renderer)
    {
        StartCoroutine(DoTheColorCRP1(renderer));
    }

    private IEnumerator DoTheColorCRP1(Renderer renderer)
    {
        float time = 0;
        while (time < 1f)
        {
            renderer.material.SetFloat("_Blend", 1-time);
            time += Time.deltaTime;
            yield return null;
        }

        renderer.material.SetFloat("_Blend", 0);

    }
}