using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Robot : MonoBehaviour
{
    public GameObject tv;
    private TextMeshPro mouth;
    private TextMeshPro eyes;
    bool alive;
    Animator animator;
    bool callable;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        callable = true;
        animator = GetComponent<Animator>();
        eyes = tv.transform.Find("Eyes").GetComponent<TextMeshPro>();
        mouth = tv.transform.Find("Mouth").GetComponent<TextMeshPro>();
        
    }
    IEnumerator SpeakRobot()
    {
        mouth.text = "D";
        yield return new WaitForSeconds(0.5f);
        mouth.text = ")";
        yield return new WaitForSeconds(0.5f);
        callable = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            if (callable)
            {
                callable = false;
                StartCoroutine(SpeakRobot());
            }
            if (Input.GetKey("t")) KillRobot();
        }
    }

    void KillRobot()
    {
        alive = false;
        mouth.text = "D";
        eyes.text = "x x";
        animator.SetBool("isDead", true);
        FindObjectOfType<RobotAudio>().KillAudio();
        FindObjectOfType<ChangeColor>().ColorPuzzle("PuzzleArea2");
    }
}
