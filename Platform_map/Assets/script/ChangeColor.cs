
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public int index = 0;



    private void Start()
    {
        print("down arrow key is held down");
        //FindObjectOfType<FadeToGray>().DoTheFade(index);
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            if (gameObject.name == "Environment")
            {
                foreach (Transform areas in gameObject.transform)
                {
                    foreach (Transform child in areas.transform)
                    {
                        print("The names of current root " + child.name);
                        Renderer m_ObjectRenderer;
                        m_ObjectRenderer = child.GetComponent<Renderer>();
                        FindObjectOfType<FadeToGrayPuzzle1>().DoTheFadeP1(m_ObjectRenderer);
                    }

                }

            }






        }
    }




    private void Update()
    {
        if (Input.GetKey("up"))
        {
            print("Up arrow key is held down");
            //acess scene root game objects
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
            scene.GetRootGameObjects(rootObjects);

            // iterate root objects and find the root object "Envirnoment"
            for (int i = 0; i < rootObjects.Count; ++i)
            {
                GameObject gameObject = rootObjects[i];
                if (gameObject.name == "Environment")
                {
                    print("The names of current root " + gameObject.name);
                    foreach (Transform puzzle1 in gameObject.transform)
                    {
                        if (puzzle1.name == "puzzle1area")
                        {
                            foreach (Transform child in puzzle1.transform)
                            {
                                print("The names of current root " + child.name);
                                Renderer m_ObjectRenderer;
                                m_ObjectRenderer = child.GetComponent<Renderer>();
                                FindObjectOfType<FadeToGrayPuzzle1>().DoTheColorP1(m_ObjectRenderer);
                            }
                        }
                    }

                }

            }//for (int i = 0; i < rootObjects.Count; ++i)
        }

        if (Input.GetKey("down"))
        {

            print("down arrow key is held down");
            //FindObjectOfType<FadeToGray>().DoTheFade(index);
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
            scene.GetRootGameObjects(rootObjects);

            // iterate root objects and do something
            for (int i = 0; i < rootObjects.Count; ++i)
            {
                GameObject gameObject = rootObjects[i];
                if (gameObject.name == "Environment")
                {
                    foreach (Transform puzzle1 in gameObject.transform)
                    {
                        if (puzzle1.name == "puzzle1area")
                        {
                            foreach (Transform child in puzzle1.transform)
                            {
                                print("The names of current root " + child.name);
                                Renderer m_ObjectRenderer;
                                m_ObjectRenderer = child.GetComponent<Renderer>();
                                FindObjectOfType<FadeToGrayPuzzle1>().DoTheFadeP1(m_ObjectRenderer);
                            }
                        }
                    }

                }

            }//for (int i = 0; i < rootObjects.Count; ++i)
        }//Input.GetKey("down")
    }
}
