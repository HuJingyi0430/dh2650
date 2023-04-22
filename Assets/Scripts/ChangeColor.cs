
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    GameObject environment;
    private void Start()
    {
        print("Set everything under Environment be gray");

        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            if (rootObjects[i].name == "Environment") environment = rootObjects[i];
        }

        foreach (Transform area in environment.transform) // Child of Environmnet. E.g. area = PuzzleArea1 
        {
            foreach (Transform child in area.transform) // Grandchild of Environmnet. E.g. child = SquareOfForest 
            {
                foreach (Transform grandchild in child.transform) // Child of grandchild of environment. E.g. grandchild = Tree_Apple 
                {
                    foreach (Renderer m_ObjectRenderer in grandchild.GetComponents<Renderer>())
                    {
                        FindObjectOfType<FadeToGray>().DoTheFade(m_ObjectRenderer);
                    }
                }
            }
        }
    }

    public void ColorPuzzle(string name_of_puzzle)
    {
        Transform puzzle = environment.transform.Find(name_of_puzzle);
        
        foreach (Transform child in puzzle.transform)
        {
            foreach (Transform grandchild in child.transform)
            {
                Renderer m_ObjectRenderer;
                m_ObjectRenderer = grandchild.GetComponent<Renderer>();
                FindObjectOfType<FadeToGray>().DoTheColor(m_ObjectRenderer);
            }
        }
    }
    public void ColorAllPuzzles()
    {
        ColorPuzzle("PuzzleArea1");
        ColorPuzzle("PuzzleArea2");
        ColorPuzzle("PuzzleArea3");
    }
    private void Update()
    {
        if (Input.GetKey("1")) ColorPuzzle("PuzzleArea1");
        if (Input.GetKey("2")) ColorPuzzle("PuzzleArea2");
        if (Input.GetKey("3")) ColorPuzzle("PuzzleArea3");
    }
}
