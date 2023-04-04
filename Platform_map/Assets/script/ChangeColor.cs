
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private void Start()
    {
        print("Set everything under Environment be gray");

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
                        Renderer[] m_ObjectRenderers;
                        m_ObjectRenderers = child.GetComponents<Renderer>();
                        foreach (Renderer m_ObjectRenderer in m_ObjectRenderers)
                        {
                            //print("The names of current renderer " + m_ObjectRenderer.name);
                            FindObjectOfType<FadeToGray>().DoTheFade(m_ObjectRenderer);
                        }
                    }

                }

            }






        }
    }




    private void Update()
    {
        if (Input.GetKey("left"))
        {
            print("Up arrow key is held down, change the puzzle1 to colorful");
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
                                FindObjectOfType<FadeToGray>().DoTheColor(m_ObjectRenderer);
                            }
                        }
                    }

                }

            }//for (int i = 0; i < rootObjects.Count; ++i)
        }//Input.GetKey("left")

        if (Input.GetKey("up"))
        {

            print("down arrow key is held down, change the puzzle2 to colorful");
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
                    foreach (Transform puzzle2 in gameObject.transform)
                    {
                        if (puzzle2.name == "puzzle2area")
                        {
                            foreach (Transform child in puzzle2.transform)
                            {
                                print("The names of current root " + child.name);
                                Renderer m_ObjectRenderer;
                                m_ObjectRenderer = child.GetComponent<Renderer>();
                                FindObjectOfType<FadeToGray>().DoTheColor(m_ObjectRenderer);
                            }
                        }
                    }

                }

            }//for (int i = 0; i < rootObjects.Count; ++i)
        }//Input.GetKey("up")



        if (Input.GetKey("right"))
        {

            print("right arrow key is held down, change the puzzle3 to colorful");
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
                    foreach (Transform puzzle3 in gameObject.transform)
                    {
                        if (puzzle3.name == "puzzle3area")
                        {
                            foreach (Transform child in puzzle3.transform)
                            {
                                print("The names of current root " + child.name);
                                Renderer m_ObjectRenderer;
                                m_ObjectRenderer = child.GetComponent<Renderer>();
                                FindObjectOfType<FadeToGray>().DoTheColor(m_ObjectRenderer);
                            }
                        }
                    }

                }

            }//for (int i = 0; i < rootObjects.Count; ++i)
        }//Input.GetKey("right")


        if (Input.GetKey("down"))
        {

            print("down arrow key is held down, change the puzzle2 to colorful");
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
                    foreach (Transform area1 in gameObject.transform)
                    {
                        if (area1.name == "area1")
                        {
                            foreach (Transform child in area1.transform)
                            {
                                print("The names of current root " + child.name);
                                Renderer m_ObjectRenderer;
                                m_ObjectRenderer = child.GetComponent<Renderer>();
                                FindObjectOfType<FadeToGray>().DoTheColor(m_ObjectRenderer);
                            }
                        }
                    }

                }

            }//for (int i = 0; i < rootObjects.Count; ++i)
        }//Input.GetKey("down")
    }
}
