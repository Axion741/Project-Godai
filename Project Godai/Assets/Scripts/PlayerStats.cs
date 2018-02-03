using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private ResultsController resController;

    private int baseStrength = 10;
    private int baseSpeed = 10;
    private int baseEndurance = 10;
    private int baseSpirit = 10;
    public int playerLevel;

    public int currentStrength;
    public int currentSpeed;
    public int currentEndurance;
    public int currentSpirit;
    public int breakPoint;

    public int modStrength;
    public int modSpeed;
    public int modEndurance;
    public int modSpirit;

    public float maxHealth;
    public float maxMP;
    public float maxPP;

    public float physicalDamage;
    public float magicDamage;
    public float evasionChance;

    public float experiencePoints;
    public float experienceThreshold;
    public int statPoints;
    public int breakChanceReset = 5;

    public GameObject confPanel;

    // Use this for initialization
    void Start ()
    {

  	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerStatsSetup()
    {
        GetSavedStats();
        DetermineStrength();
        DetermineSpirit();
        DetermineEndurance();
        DetermineSpeed();
        DetermineHealth();
        DetermineMP();
        DeterminePP();
        LevelUp();
        resController = FindObjectOfType<ResultsController>();
    }

    public void LevelTester()
    {
        experiencePoints = experiencePoints + 500;
        SetExperience();
    }

    public void LevelUp()
    {
        experienceThreshold = playerLevel * 500;
        if (experiencePoints >= experienceThreshold)
        {
            experiencePoints = experiencePoints - experienceThreshold;
            playerLevel++;
            experienceThreshold = playerLevel * 500;
            statPoints = statPoints + 5;
            PlayerPrefsManager.SetStatPoints(statPoints);
            PlayerPrefsManager.SetPlayerLevel(playerLevel);
            PlayerPrefsManager.SetExperiencePoints(experiencePoints);
            resController.TextEnabler();
            print("exp to next = " + experienceThreshold);
            print("current stat points = " + statPoints);
            LevelUp();
        }
        else return;
    }

    public void SetExperience()
    {
        PlayerPrefsManager.SetExperiencePoints(experiencePoints);
        LevelUp();
    }

    public void DetermineLevel()
    {
        if (playerLevel > 1)
        {
            playerLevel = 1;
            PlayerPrefsManager.SetPlayerLevel(playerLevel);
            PlayerPrefsManager.GetPlayerLevel();
        }
        else
        {
            playerLevel = PlayerPrefsManager.GetPlayerLevel();
        }
    }

    public void DetermineHealth()
    {
        maxHealth = currentEndurance*10;
        
    }

    public void DetermineMP()
    {
        maxMP = currentSpirit * 10;
       
    }

    public void DeterminePP()
    {
        maxPP = 3 * (breakPoint + 1);
    }

    public void DetermineStrength()
    {
        currentStrength = baseStrength + PlayerPrefsManager.GetStrengthMod();
        physicalDamage = currentStrength;
    }

    public void DetermineSpeed()
    {
        currentSpeed = baseSpeed + PlayerPrefsManager.GetSpeedMod();
        evasionChance = currentSpeed / 2;
    }

    public void DetermineEndurance()
    {
        currentEndurance = baseEndurance + PlayerPrefsManager.GetEnduranceMod();
    }

    public void DetermineSpirit()
    {
        currentSpirit = baseSpirit + PlayerPrefsManager.GetSpiritMod();
        magicDamage = currentSpirit * 1.5f;
    }

    public void LevelStrength()
    {
        if (statPoints > 0)
        {
            modStrength++;
            PlayerPrefsManager.SetStrengthMod(modStrength);
            DetermineStrength();
            statPoints--;
            PlayerPrefsManager.SetStatPoints(statPoints);
      }
    }

    public void LevelSpeed()
    {
        if (statPoints > 0)
        {
            modSpeed++;
            PlayerPrefsManager.SetSpeedMod(modSpeed);
            DetermineSpeed();
            statPoints--;
            PlayerPrefsManager.SetStatPoints(statPoints);
        }
    }

    public void LevelEndurance()
    {
        if (statPoints > 0)
        {
            modEndurance++;
            PlayerPrefsManager.SetEnduranceMod(modEndurance);
            DetermineEndurance();
            DetermineHealth();
            statPoints--;
            PlayerPrefsManager.SetStatPoints(statPoints);
        }
    }

    public void LevelSpirit()
    {
        if (statPoints > 0)
        {
            modSpirit++;
            PlayerPrefsManager.SetSpiritMod(modSpirit);
            DetermineSpirit();
            DetermineMP();
            statPoints--;
            PlayerPrefsManager.SetStatPoints(statPoints);
        }
    }

    public void ResetStats()
    {
        modStrength = 0;
        modSpeed = 0;
        modEndurance = 0;
        modSpirit = 0;
        playerLevel = 1;
        experiencePoints = 0;
        statPoints = 0;
        breakPoint = 0;
        PlayerPrefsManager.SetBreakPoint(breakPoint);
        PlayerPrefsManager.SetBreakChance(breakChanceReset);
        experienceThreshold = playerLevel * 500;
        PlayerPrefsManager.SetPlayerLevel(playerLevel);
        PlayerPrefsManager.SetExperiencePoints(experiencePoints);
        PlayerPrefsManager.SetStatPoints(statPoints);
        DetermineLevel();
        PlayerPrefsManager.SetStrengthMod(modStrength);
        DetermineStrength();
        PlayerPrefsManager.SetSpeedMod(modSpeed);
        DetermineSpeed();
        PlayerPrefsManager.SetEnduranceMod(modEndurance);
        DetermineEndurance();
        PlayerPrefsManager.SetSpiritMod(modSpirit);
        DetermineSpirit();
        DetermineHealth();
        DetermineMP();
        confPanel.SetActive(false);
    }

    public void CheckReset()
    {
        confPanel.SetActive(true);
    }

    public void DenyReset()
    {
        confPanel.SetActive(false);
    }

    public void GetSavedStats()
    {
        modStrength = PlayerPrefsManager.GetStrengthMod();
        modSpeed = PlayerPrefsManager.GetSpeedMod();
        modEndurance = PlayerPrefsManager.GetEnduranceMod();
        modSpirit = PlayerPrefsManager.GetSpiritMod();
        experiencePoints = PlayerPrefsManager.GetExperiencePoints();
        statPoints = PlayerPrefsManager.GetStatPoints();
        breakPoint = PlayerPrefsManager.GetBreakPoint();
        DetermineLevel();            
    }
}
