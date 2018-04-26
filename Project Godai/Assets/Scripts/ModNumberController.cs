using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModNumberController : MonoBehaviour {

    public Text text;

    private int strengthMod;
    private int speedMod;
    private int enduranceMod;
    private int spiritMod;
    private int playerLevel;    
    private int statPoints;
    private float experiencePoints;

    private StatScreenController statScreenController;
    private PlayerStats playerStats;
    private PlayerStats2 playerStats2;
    private PlayerStats3 playerStats3;
    private SaveData saveData;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        playerStats2 = GameObject.FindObjectOfType<PlayerStats2>();
        playerStats3 = GameObject.FindObjectOfType<PlayerStats3>();
        statScreenController = FindObjectOfType<StatScreenController>();
        saveData = FindObjectOfType<SaveData>();
	}
	
	// Update is called once per frame
	void Update () {
        ButtonChecker();
	}

    public void ButtonChecker()
    {
        if (gameObject.name == "ModStr")
        {
            StrengthText();
        }
        else if (gameObject.name == "ModSpd")
        {
            SpeedText();
        }
        else if (gameObject.name == "ModEnd")
        {
            EnduranceText();
        }
        else if (gameObject.name == "ModSpt")
        {
            SpiritText();
        }
        else if (gameObject.name == "Current Level")
        {
            LevelText();
        }
        else if (gameObject.name == "Exp Points")
        {
            ExpText();
        }
        else if (gameObject.name == "Stat Points")
        {
            StatText();
        }
    }

    public void StrengthText()
    {
        switch (statScreenController.selectedCharacter)
        {
            case 1:
                strengthMod = saveData.modStrength1;
                text.text = ("<Color=#00ff00ff>+" + strengthMod.ToString() + "</Color>");
                break;

            case 2:
                strengthMod = saveData.modStrength2;
                text.text = ("<Color=#00ff00ff>+" + strengthMod.ToString() + "</Color>");
                break;

            case 3:
                strengthMod = saveData.modStrength3;
                text.text = ("<Color=#00ff00ff>+" + strengthMod.ToString() + "</Color>");
                break;
        }
    }

    public void SpeedText()
    {
        switch (statScreenController.selectedCharacter)
        {
            case 1:
                speedMod = saveData.modSpeed1;
                text.text = ("<Color=#00ff00ff>+" + speedMod.ToString() + "</Color>");
                break;

            case 2:
                speedMod = saveData.modSpeed2;
                text.text = ("<Color=#00ff00ff>+" + speedMod.ToString() + "</Color>");
                break;

            case 3:
                speedMod = saveData.modSpeed3;
                text.text = ("<Color=#00ff00ff>+" + speedMod.ToString() + "</Color>");
                break;
        }
    }

    public void EnduranceText()
    {
        switch (statScreenController.selectedCharacter)
        {
            case 1:
                enduranceMod = saveData.modEndurance1;
                text.text = ("<Color=#00ff00ff>+" + enduranceMod.ToString() + "</Color>");
                break;

            case 2:
                enduranceMod = saveData.modEndurance2;
                text.text = ("<Color=#00ff00ff>+" + enduranceMod.ToString() + "</Color>");
                break;

            case 3:
                enduranceMod = saveData.modEndurance3;
                text.text = ("<Color=#00ff00ff>+" + enduranceMod.ToString() + "</Color>");
                break;
        }

    }

    public void SpiritText()
    {

        switch (statScreenController.selectedCharacter)
        {
            case 1:
                spiritMod = saveData.modSpirit1;
                text.text = ("<Color=#00ff00ff>+" + spiritMod.ToString() + "</Color>");
                break;

            case 2:
                spiritMod = saveData.modSpirit2;
                text.text = ("<Color=#00ff00ff>+" + spiritMod.ToString() + "</Color>");
                break;

            case 3:
                spiritMod = saveData.modSpirit3;
                text.text = ("<Color=#00ff00ff>+" + spiritMod.ToString() + "</Color>");
                break;
        }


    }

    public void LevelText()
    {
        switch (statScreenController.selectedCharacter)
        {
            case 1:
                playerLevel = saveData.playerLevel1;
                text.text = ("<Color=white> Lvl: " + playerLevel.ToString() + "</Color>");
                break;

            case 2:
                playerLevel = saveData.playerLevel2;
                text.text = ("<Color=white> Lvl: " + playerLevel.ToString() + "</Color>");
                break;

            case 3:
                playerLevel = saveData.playerLevel3;
                text.text = ("<Color=white> Lvl: " + playerLevel.ToString() + "</Color>");
                break;
        }

    }

    public void ExpText()
    {
        switch (statScreenController.selectedCharacter)
        {
            case 1:
                experiencePoints = saveData.experiencePoints1;
                text.text = ("<Color=white> Exp: " + experiencePoints.ToString() + "/" + playerStats.experienceThreshold + "</Color>");
                break;

            case 2:
                experiencePoints = saveData.experiencePoints2;
                text.text = ("<Color=white> Exp: " + experiencePoints.ToString() + "/" + playerStats2.experienceThreshold + "</Color>");
                break;

            case 3:
                experiencePoints = saveData.experiencePoints3;
                text.text = ("<Color=white> Exp: " + experiencePoints.ToString() + "/" + playerStats3.experienceThreshold + "</Color>");
                break;
        }

    }

    public void StatText()
    {
        switch (statScreenController.selectedCharacter)
        {
            case 1:
                statPoints = saveData.statPoints1;
                text.text = ("<Color=white> Stat Points: " + statPoints.ToString() + "</Color>");
                break;

            case 2:
                statPoints = saveData.statPoints2;
                text.text = ("<Color=white> Stat Points: " + statPoints.ToString() + "</Color>");
                break;

            case 3:
                statPoints = saveData.statPoints3;
                text.text = ("<Color=white> Stat Points: " + statPoints.ToString() + "</Color>");
                break;
        }

    }
}
