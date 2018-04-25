using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats3 : MonoBehaviour, IPlayerStats {

    private ResultsController resController;
    public SaveManager saveManager;
    public SaveData saveData;
    public GameObject confPanel;

    private int baseStrength = 10;
    private int baseSpeed = 10;
    private int baseEndurance = 10;
    private int baseSpirit = 10;
    public int playerLevel = 1;

    public int currentStrength;
    public int currentSpeed;
    public int currentEndurance;
    public int currentSpirit;

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

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerStatsSetup()
    {
        saveManager = FindObjectOfType<SaveManager>();
        saveData = FindObjectOfType<SaveData>();
        GetSavedStats();
        DetermineStat("all");
        LevelUp();
        resController = FindObjectOfType<ResultsController>();
    }

    public void GetSavedStats()
    {
        saveManager.ImportPlayerStats();
        modStrength = saveData.modStrength3;
        modSpeed = saveData.modSpeed3;
        modEndurance = saveData.modEndurance3;
        modSpirit = saveData.modSpirit3;
        experiencePoints = saveData.experiencePoints3;
        statPoints = saveData.statPoints3;
        DetermineLevel();
    }

    public void DetermineLevel()
    {
        if (playerLevel <= 1)
        {
            playerLevel = 1;
            saveManager.SaveAllData();
        }
        else
        {
            playerLevel = saveData.playerLevel2;
        }
    }

    public void DetermineStat(string stat)
    {
        switch (stat)
        {
            case "health":
                MaxHealth = currentEndurance * 10;
                break;

            case "magicpoints":
                MaxMP = currentSpirit * 10;
                break;

            case "strength":
                currentStrength = baseStrength + modStrength;
                PhysicalDamage = currentStrength;
                break;

            case "speed":
                currentSpeed = baseSpeed + modSpeed;
                EvasionChance = currentSpeed / 2;
                break;

            case "endurance":
                currentEndurance = baseEndurance + modEndurance;
                break;

            case "spirit":
                currentSpirit = baseSpirit + modSpirit;
                MagicDamage = currentSpirit * 1.5f;
                break;

            case "all":
                currentEndurance = baseEndurance + modEndurance;
                currentSpirit = baseSpirit + modSpirit;
                MaxHealth = currentEndurance * 10;
                MaxMP = currentSpirit * 10;
                currentStrength = baseStrength + modStrength;
                PhysicalDamage = currentStrength;
                currentSpeed = baseSpeed + modSpeed;
                EvasionChance = currentSpeed / 2;
                MagicDamage = currentSpirit * 1.5f;
                break;
        }
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
            saveManager.SaveAllData();
            resController.TextEnabler(3);
            print("exp to next = " + experienceThreshold);
            print("current stat points = " + statPoints);
            LevelUp();
        }
        else saveManager.SaveAllData();
    }

    //For Dev Use Only//
    public void LevelTester()
    {
        experiencePoints = experiencePoints + 500;
        LevelUp();
    }

    public void LevelStrength()
    {
        if (statPoints > 0)
        {
            modStrength++;
            DetermineStat("strength");
            statPoints--;
            saveManager.SaveAllData();
        }
    }

    public void LevelSpeed()
    {
        if (statPoints > 0)
        {
            modSpeed++;
            DetermineStat("speed");
            statPoints--;
            saveManager.SaveAllData();
        }
    }

    public void LevelEndurance()
    {
        if (statPoints > 0)
        {
            modEndurance++;
            DetermineStat("endurance");
            DetermineStat("health");
            statPoints--;
            saveManager.SaveAllData();
        }
    }

    public void LevelSpirit()
    {
        if (statPoints > 0)
        {
            modSpirit++;
            DetermineStat("spirit");
            DetermineStat("magicpoints");
            statPoints--;
            saveManager.SaveAllData();
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
        experienceThreshold = playerLevel * 500;

        saveManager.SaveAllData();

        DetermineStat("all");

        confPanel.SetActive(false);
    }
}
