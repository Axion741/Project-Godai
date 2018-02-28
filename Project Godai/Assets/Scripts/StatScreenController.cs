using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreenController : MonoBehaviour {

    private PlayerStats playerStats;
    private GameObject p2Toggle;
    private GameObject p3Toggle;

	// Use this for initialization
	void Start () {
        p2Toggle = GameObject.Find("Player2Toggle");
        p3Toggle = GameObject.Find("Player3Toggle");
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats.PlayerStatsSetup();

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
        }else if (playerStats.player2recruited == 0)
        {
            p2Toggle.GetComponent<Toggle>().isOn = false;
        }

        if (playerStats.player3recruited == 1)
        {
            p3Toggle.GetComponent<Toggle>().isOn = true;
        }
        else if (playerStats.player3recruited == 0)
        {
            p3Toggle.GetComponent<Toggle>().isOn = false;
        }

    }



}
