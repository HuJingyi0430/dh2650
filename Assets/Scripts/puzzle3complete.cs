using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle3complete : MonoBehaviour
{
    //public bool complete;
    private GameObject puzzle;
    private bool completesub1;
    private bool completesub2;
    private bool completesub3;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = this.gameObject;
        //complete = false;
        completesub1 = false;
        completesub2 = false;
        completesub3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform subpuzzle in puzzle.transform) // Child of Environmnet. E.g. area = PuzzleArea1 
        {
            if ((completesub1 == false) && (subpuzzle.name == "top1"))
            {
                if (subpuzzle.gameObject.GetComponent<Rigidbody>().mass == 100)
                {
                    completesub1 = true;
                }
            }
            else if ((completesub2 == false) && (subpuzzle.name == "top2"))
            {
                if (subpuzzle.gameObject.GetComponent<Rigidbody>().mass == 100)
                {
                    completesub2 = true;
                }
            }
            else if ((completesub3 == false) && (subpuzzle.name == "top3"))
            {
                if (subpuzzle.gameObject.GetComponent<Rigidbody>().mass == 100)
                {
                    completesub3 = true;
                }
            }

            if (completesub1 && completesub2 && completesub3)
            {
                FindObjectOfType<ChangeColor>().ColorPuzzle("PuzzleArea3");
            }
        }

    }
}
