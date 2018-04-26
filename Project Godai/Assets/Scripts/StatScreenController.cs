using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreenController : MonoBehaviour {

    private ModNumberController modController;
    private PlayerStats playerStats;
    private PlayerStats2 playerStats2;
    private PlayerStats3 playerStats3;
    private GameObject p2Toggle;
    private GameObject p3Toggle;
    //private GameObject p1Selector;
    private GameObject p2Selector;
    private GameObject p3Selector;
    public GameObject p1Controls;
    public GameObject p2Controls;
    public GameObject p3Controls;

    public int selectedCharacter;


    // Use this for initialization
    void Start () {
        modController = FindObjectOfType<ModNumberController>();
        p2Toggle = GameObject.Find("Player2Toggle");
        p3Toggle = GameObject.Find("Player3Toggle");
        //p1Selector = GameObject.Find("Player1ToggleSwitch");
        p2Selector = GameObject.Find("Player2ToggleSwitch");
        p3Selector = GameObject.Find("Player3ToggleSwitch");
        p1Controls = GameObject.Find("Player1StatControls");
        p2Controls = GameObject.Find("Player2StatControls");
        p3Controls = GameObject.Find("Player3StatControls");
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats2 = FindObjectOfType<PlayerStats2>();
        playerStats3 = FindObjectOfType<PlayerStats3>();
        playerStats.PlayerStatsSetup();
        playerStats2.PlayerStatsSetup();
        playerStats3.PlayerStatsSetup();
        selectedCharacter = 1;
        p2Controls.SetActive(false);
        p3Controls.SetActive(false);

    }

    private void Update()
    {
       ToggleController();
    }

    void ToggleController()
    {
        if (playerStats.player2recruited == 1)
        {
            p2Toggle.GetComponent<Toggle>().isOn = true;
            p2Selector.SetActive(true);
        }else if (playerStats.player2recruited == 0)
        {
            p2Toggle.GetComponent<Toggle>().isOn = false;
            p2Selector.SetActive(false);
        }

        if (playerStats.player3recruited == 1)
        {
            p3Toggle.GetComponent<Toggle>().isOn = true;
            p3Selector.SetActive(true);
        }
        else if (playerStats.player3recruited == 0)
        {
            p3Toggle.GetComponent<Toggle>().isOn = false;
            p3Selector.SetActive(false);
        }

    }

    public void ToggleActiveCharacter(int character)
    {
        switch (character)
        {
            case 1:
                if (p1Controls.activeSelf == true)
                {
                    return; 
                }
                else
                {
                    p1Controls.SetActive(true);
                    p2Controls.SetActive(false);
                    p3Controls.SetActive(false);
                    selectedCharacter = 1;
                }
                break;

            case 2:
                if (p2Controls.activeSelf == true)
                {
                    return;
                }
                else
                {
                    p1Controls.SetActive(false);
                    p2Controls.SetActive(true);
                    p3Controls.SetActive(false);
                    selectedCharacter = 2;
                }
                break;

            case 3:
                if (p3Controls.activeSelf == true)
                {
                    return;
                }
                else
                {
                    p1Controls.SetActive(false);
                    p2Controls.SetActive(false);
                    p3Controls.SetActive(true);
                    selectedCharacter = 3;
                }
                break;
        }
    }



}
