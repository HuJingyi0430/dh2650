using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using System.Numerics;

public class healthsys2 : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;
    private int currentloc = 0;
    public int currenthealth = 3;
    private int maxHealth = 3;
    public bool getDamage = false;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;
    public GameObject player2;

    private void Start()
    {
        heartContainers = new GameObject[maxHealth];
        heartFills = new Image[maxHealth];
        //player2 = GameObject.Find("Player2");

        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    void Update()
    {
        if (getDamage && (currenthealth > 0))
        {
            Destroy(heartContainers[currenthealth-1]);
            currenthealth = currenthealth - 1;
            print("destroy");
            getDamage = false;
        }
        if (currenthealth == 0)
        {
            FindObjectOfType<animationStateController_Player2>().player2Dead();
            print("dead");
            StartCoroutine(DelayTheRecover(5.0f));
            StartCoroutine(ReliveatBeginning(4.5f));
            currenthealth = 3;
        }

    }
    IEnumerator ReliveatBeginning(float delay)
    {
        yield return new WaitForSeconds(delay);
        player2.transform.position = new Vector3(50f, 5f, 50f);
    }
    IEnumerator DelayTheRecover(float delay)
    {
        yield return new WaitForSeconds(delay);
        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }


    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < maxHealth)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < maxHealth)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            temp.transform.localPosition = new Vector3(currentloc, 0, 0);
            currentloc = currentloc + 30;
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
        currentloc = 0;
    }
}