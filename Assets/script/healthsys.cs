using System;
using UnityEngine;
using UnityEngine.UI;

public class healthsys : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;
    private int currentloc = 0;
    private int currenthealth = 3;
    private int maxHealth = 3;
    public bool getDamage = false;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;

    private void Start()
    {
        heartContainers = new GameObject[maxHealth];
        heartFills = new Image[maxHealth];

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
            InstantiateHeartContainers();
            UpdateHeartsHUD();
            currenthealth = 3;
        }
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
    }
}