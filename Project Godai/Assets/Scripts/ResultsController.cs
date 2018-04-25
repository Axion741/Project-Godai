using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour {

    public Canvas resultsCanvas;
    public Text titleText;
    public Text pointText;
    public Text pointText2;
    public Text pointText3;
    private PlayerStats playerStats;
    private PlayerStats2 playerStats2;
    private PlayerStats3 playerStats3;
    private BattleController battleController;

	// Use this for initialization
	void Start () {
        resultsCanvas = resultsCanvas.GetComponent<Canvas>();
        resultsCanvas.enabled = false;
        playerStats = FindObjectOfType<PlayerStats>();
        battleController = FindObjectOfType<BattleController>();

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
        battleController.AwardExperience();
       
    }

    public void LoseFight()
    {
        titleText.text = "Defeat!";
        ResultCanvasEnabler();
    }

    public void TextEnabler(int character)
    {
        switch (character)
        {
            case 1:
                pointText.text = playerStats.statPoints + " Skill Points Available!";
                pointText.enabled = true;
                break;

            case 2:
                playerStats2 = FindObjectOfType<PlayerStats2>();                
                pointText2.text = playerStats2.statPoints + " Skill Points Available!";
                pointText2.enabled = true;
                break;

            case 3:
                playerStats3 = FindObjectOfType<PlayerStats3>();
                pointText3.text = playerStats3.statPoints + " Skill Points Available!";
                pointText3.enabled = true;
                break;

        }


    }
}
