using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu1;
    public GameObject pauseMenu2;
    public GameObject pauseMenu3;
    public GameObject pauseMenu4;

    public GameObject xboxMenu;
    public GameObject psMenu;
    // Start is called before the first frame update
    int current;
    /*
     STATES:
     0) Off
     1) Pause Menu
     2) Xbox One
     3) PS 
     */
    int state;
    int i;
    public GameObject player1;
    public GameObject player2;
    private void Start()
    {
        current = 0;
        state = 0;
        i = 0;
    }
    // Update is called once per frame
    void ActivatePlayersScripts(bool value)
    {
        foreach(MonoBehaviour script in player1.GetComponents<MonoBehaviour>())
        {
            script.enabled = value;
        }
        foreach (MonoBehaviour script in player1.GetComponentsInChildren<MonoBehaviour>())
        {
            script.enabled = value;
        }
        foreach (MonoBehaviour script in player2.GetComponents<MonoBehaviour>())
        {
            script.enabled = value;
        }
        foreach (MonoBehaviour script in player2.GetComponentsInChildren<MonoBehaviour>())
        {
            script.enabled = value;
        }
    }
    
    void FixedUpdate()
    {
        if (Input.GetButton("Menu"))
        {
            this.ActivatePlayersScripts(false);
            state = 1;
            current = 0;
        }

        i += 1;
        if (state == 1 && i > 10) {
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
            if (Input.GetButton("B") || Input.GetButton("Back"))
            {
                state = 0;
                pauseMenu1.SetActive(false);
                pauseMenu2.SetActive(false);
                pauseMenu3.SetActive(false);
                pauseMenu4.SetActive(false);
                this.ActivatePlayersScripts(true);
            }
            if (Input.GetButton("X")) { 
                if (current == 1) {
                    state = 2;
                    pauseMenu1.SetActive(false);
                    pauseMenu2.SetActive(false);
                    pauseMenu3.SetActive(false);
                    pauseMenu4.SetActive(false);
                    xboxMenu.SetActive(true);
                }else if(current == 2){
                    state = 3;
                    pauseMenu1.SetActive(false);
                    pauseMenu2.SetActive(false);
                    pauseMenu3.SetActive(false);
                    pauseMenu4.SetActive(false);
                    psMenu.SetActive(true);
                }
                else if (current == 0)
                {
                    state = 0;
                    pauseMenu1.SetActive(false);
                    pauseMenu2.SetActive(false);
                    pauseMenu3.SetActive(false);
                    pauseMenu4.SetActive(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else if (current == 3)
                {
                    Application.Quit();
                    Debug.Log("You clicked QUIT (only works in the actual game)");
                }
            }
            i = 0;
        }else if(state == 2)
        {
            i += 1;
            if (Input.GetButton("B") && i>15)
            {
                state = 1;
                xboxMenu.SetActive(false);
                i = 0;
            }
        }else if (state == 3)
        {
            i += 1;
            if (Input.GetButton("B") && i > 15)
            {
                state = 1;
                psMenu.SetActive(false);
                i = 0;
            }
        }
    }
}
