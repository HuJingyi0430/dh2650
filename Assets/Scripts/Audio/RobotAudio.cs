using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAudio : MonoBehaviour
{
    Transform robotTV;
    Transform player1;
    Transform player2;
    AudioSource audioSource;
    public AudioClip help_clip;
    public AudioClip success_clip;
    public AudioClip content_clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = help_clip;
        audioSource.Play();
        
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
        scene.GetRootGameObjects(rootObjects);
        robotTV = null;
        player1 = null;
        player2 = null;
        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            if (rootObjects[i].name == "Puzzle3") robotTV = rootObjects[i].transform.Find("RobotTV");
            else if (rootObjects[i].name == "Player1") player1 = rootObjects[i].transform;
            else if (rootObjects[i].name == "Player2") player2 = rootObjects[i].transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance_to_player1 = (player1.position - robotTV.position).magnitude;
        float distance_to_player2 = (player2.position - robotTV.position).magnitude;
        if (distance_to_player2 < distance_to_player1 && distance_to_player2 < 100) this.transform.position = -1*(player2.position - robotTV.position);
        else if (distance_to_player1 < distance_to_player2 && distance_to_player1 < 100) this.transform.position = -1*(player1.position - robotTV.position);
    }

    public void KillAudio()
    {
        this.gameObject.SetActive(false);
    }
    public IEnumerator RobotSuccess()
    {
        audioSource.clip = success_clip;
        audioSource.Play();
        yield return new WaitForSeconds(14);
        audioSource.clip = content_clip;
        audioSource.Play();
    }
}
