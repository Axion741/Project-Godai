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

    private PlayerStats playerStats;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
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
        strengthMod = PlayerPrefsManager.GetStrengthMod();
        text.text = ("<Color=#00ff00ff>+" + strengthMod.ToString() + "</Color>");
    }

    public void SpeedText()
    {
        speedMod = PlayerPrefsManager.GetSpeedMod();
        text.text = ("<Color=#00ff00ff>+" + speedMod.ToString() + "</Color>");
    }

    public void EnduranceText()
    {
        enduranceMod = PlayerPrefsManager.GetEnduranceMod();
        text.text = ("<Color=#00ff00ff>+" + enduranceMod.ToString() + "</Color>");
    }

    public void SpiritText()
    {
        spiritMod = PlayerPrefsManager.GetSpiritMod();
        text.text = ("<Color=#00ff00ff>+" + spiritMod.ToString() + "</Color>");
    }

    public void LevelText()
    {
        playerLevel = PlayerPrefsManager.GetPlayerLevel();
        text.text = ("<Color=white> Lvl: " + playerLevel.ToString() + "</Color>");
    }

    public void ExpText()
    {
        experiencePoints = PlayerPrefsManager.GetExperiencePoints();
        text.text = ("<Color=white> Exp: " + experiencePoints.ToString() + "/" + playerStats.experienceThreshold + "</Color>");
    }

    public void StatText()
    {
        statPoints = PlayerPrefsManager.GetStatPoints();
        text.text = ("<Color=white> Stat Points: " + statPoints.ToString() + "</Color>");
    }
}
