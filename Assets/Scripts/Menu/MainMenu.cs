using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject pauseMenu1;
    public GameObject pauseMenu2;
    public GameObject pauseMenu3;
    public GameObject pauseMenu4;
    public GameObject xboxMenu;
    public GameObject psMenu;
    // Start is called before the first frame update
    int current;
    int i;
    int state;
    private void Start()
    {
        current = 0;
        i = 0;
        state = 0;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        i += 1;
        if (i > 10)
        {
            if(state == 0)
                {
                if (Input.GetAxisRaw("DpadVertical") > 0 || Input.GetAxisRaw("VerticalJoyLeft") > 0 || Input.GetAxisRaw("VerticalJoy2Left") > 0)
                {
                    current = (current - 1 + 4) % 4;
                    Debug.Log("PRESSED DOWN: " + current);
                    pauseMenu1.SetActive(false);
                    pauseMenu2.SetActive(false);
                    pauseMenu3.SetActive(false);
                    pauseMenu4.SetActive(false);
                }
                if (Input.GetAxisRaw("DpadVertical") < 0 || Input.GetAxisRaw("VerticalJoyLeft") < 0 || Input.GetAxisRaw("VerticalJoy2Left") < 0)
                {
                    Debug.Log("PRESSED UP: " + current);
                    current = (current + 1 + 4) % 4;
                    pauseMenu1.SetActive(false);
                    pauseMenu2.SetActive(false);
                    pauseMenu3.SetActive(false);
                    pauseMenu4.SetActive(false);
                }
                if (current == 0) pauseMenu1.SetActive(true);
                else if (current == 1) pauseMenu2.SetActive(true);
                else if (current == 2) pauseMenu3.SetActive(true);
                else if (current == 3) pauseMenu4.SetActive(true);
                if (Input.GetButton("X"))
                {
                    if (current == 0)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                    }
                    else if (current == 1)
                    {
                        pauseMenu1.SetActive(false);
                        pauseMenu2.SetActive(false);
                        pauseMenu3.SetActive(false);
                        pauseMenu4.SetActive(false);
                        xboxMenu.SetActive(true);
                        state = 1;
                    }
                    else if (current == 2)
                    {
                        pauseMenu1.SetActive(false);
                        pauseMenu2.SetActive(false);
                        pauseMenu3.SetActive(false);
                        pauseMenu4.SetActive(false);
                        psMenu.SetActive(true);
                        state = 2;
                    }
                    else if (current == 3)
                    {
                        Application.Quit();
                        Debug.Log("You clicked QUIT (only works in the actual game)");
                    }
                }
            }else if (state == 1)
            {
                if (Input.GetButton("B") && i > 10)
                {
                    state = 0;
                    xboxMenu.SetActive(false);
                }
            }
            else if (state == 2)
            {
                if (Input.GetButton("B") && i > 10)
                {
                    state = 0;
                    psMenu.SetActive(false);
                }
            }
            i = 0;
        }
    }
}
