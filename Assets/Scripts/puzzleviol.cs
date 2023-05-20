using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleviol : MonoBehaviour
{
    public bool completesub1;
    public bool completesub2;
    // Start is called before the first frame update
    void Start()
    {
        //complete = false;
        completesub1 = false;
        completesub2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (completesub1 && completesub2)
        {
            FindObjectOfType<ChangeColor>().ColorPuzzle("PuzzleArea3");
        }
    }
}
