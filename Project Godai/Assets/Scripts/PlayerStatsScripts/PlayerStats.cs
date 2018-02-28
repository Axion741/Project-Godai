using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IPlayerStats {

    private ResultsController resController;

    public int player2recruited = 0;
    public int player3recruited = 0;

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

    public float MaxHealth { get; set; }
    public float MaxMP { get; set; }

    public float PhysicalDamage { get; set; }
    public float MagicDamage { get; set; }
    public float EvasionChance { get; set; }

    public float experiencePoints;
    public float experienceThreshold;
    public int statPoints;

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
        MaxHealth = currentEndurance*10;
        
    }

    public void DetermineMP()
    {
        MaxMP = currentSpirit * 10;
       
    }


    public void DetermineStrength()
    {
        currentStrength = baseStrength + PlayerPrefsManager.GetStrengthMod();
        PhysicalDamage = currentStrength;
    }

    public void DetermineSpeed()
    {
        currentSpeed = baseSpeed + PlayerPrefsManager.GetSpeedMod();
        EvasionChance = currentSpeed / 2;
    }

    public void DetermineEndurance()
    {
        currentEndurance = baseEndurance + PlayerPrefsManager.GetEnduranceMod();
    }

    public void DetermineSpirit()
    {
        currentSpirit = baseSpirit + PlayerPrefsManager.GetSpiritMod();
        MagicDamage = currentSpirit * 1.5f;
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
        player2recruited = PlayerPrefsManager.GetPlayer2Recruited();
        player3recruited = PlayerPrefsManager.GetPlayer3Recruited();
        DetermineLevel();            
    }

    public void RecruitPlayer2()
    {
        if (player2recruited == 0)
        {
            player2recruited = 1;
            PlayerPrefsManager.SetPlayer2Recruited(player2recruited);
            print("Player 2 recruited");
        }
        else if (player2recruited == 1)
        {
            player2recruited = 0;
            PlayerPrefsManager.SetPlayer2Recruited(player2recruited);
            print("Player 2 left");
        }
    }

    public void RecruitPlayer3()
    {
        if (player3recruited == 0)
        {
            player3recruited = 1;
            PlayerPrefsManager.SetPlayer3Recruited(player3recruited);
            print("Player 3 recruited");
        }
        else if (player3recruited == 1)
        {
            player3recruited = 0;
            PlayerPrefsManager.SetPlayer3Recruited(player3recruited);
            print("Player 3 left");
        }

    }
}
