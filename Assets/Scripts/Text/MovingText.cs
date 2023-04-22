using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MovingText : MonoBehaviour
{
    private TextMeshPro inst;
    int len_output = 11;
    int i = 0;
    public string text = "Don't miss anything on Media";
    char[] list;
    int len_text;
    // Start is called before the first frame update
    void Start()
    {
        inst = GetComponent<TextMeshPro>();
        list = text.ToCharArray();
        len_text = text.Length;
        OutputTime();
        InvokeRepeating("OutputTime", 0f, 0.3f);  //1s delay, repeat every 1s

    }

    // Update is called once per frame
    void OutputTime()
    {
        string output = "";
        for(int k=i; k<(i+len_output); k++)
        {
            output += list[k % len_text];
        }
        inst.text = output;
        i = (i + 1) % len_text;
    }
}
