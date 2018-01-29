using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour {

    public Canvas resultsCanvas;
    public Text titleText;
    public Text pointText;
    public Text pointMessage;
    private PlayerStats playerStats;
    private EnemyAbilities enemyAbilities;


	// Use this for initialization
	void Start () {
        resultsCanvas = resultsCanvas.GetComponent<Canvas>();
        resultsCanvas.enabled = false;
        playerStats = FindObjectOfType<PlayerStats>();
        enemyAbilities = FindObjectOfType<EnemyAbilities>();

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ResultCanvasEnabler()
    {
        resultsCanvas.enabled = true;
    }

    public void WinFight()
    {
        titleText.text = "Victory!";
        ResultCanvasEnabler();
        playerStats.experiencePoints = playerStats.experiencePoints + enemyAbilities.experienceValue;
        playerStats.SetExperience();

    }

    public void LoseFight()
    {
        titleText.text = "Defeat!";
        ResultCanvasEnabler();
    }

    public void TextEnabler()
    {
        pointText.text = playerStats.statPoints + " Skill Points Available!";
        pointMessage.enabled = true;
    }
}
