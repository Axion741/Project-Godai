using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScreenController : MonoBehaviour {

    private PlayerStats playerStats;

	// Use this for initialization
	void Start () {
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats.PlayerStatsSetup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
