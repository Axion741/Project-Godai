using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    
    public SaveData saveData;

    private PlayerStats playerStats;
    private string filePath;

    // Use this for initialization
    void Start()
    {
        saveData = GetComponent<SaveData>();
        filePath = Path.Combine (Application.persistentDataPath, "save.txt");
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void WriteSave()
    {
        string jsonString = JsonUtility.ToJson(saveData);
        File.WriteAllText(filePath, jsonString);
        print("Game Saved");
    }

    void Load()
    {
        if (File.Exists(filePath))
        {

            string jsonString = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonString, saveData);
            print("Save Loaded");
            SaveAllData();
        }
        else
        {
            WriteSave();
            Load();
        }
    }

    //CHARACTER STAT SETTING METHODS//

    public void SaveAllData()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        //SET STATS IN SAVEDATA TO THOSE IN PLAYERSTATS
        if(playerStats != null)
        {
            saveData.modStrength1 = playerStats.modStrength;
            saveData.modSpeed1 = playerStats.modSpeed;
            saveData.modEndurance1 = playerStats.modEndurance;
            saveData.modSpirit1 = playerStats.modSpirit;

            saveData.playerLevel1 = playerStats.playerLevel;
            saveData.experiencePoints1 = playerStats.experiencePoints;
            saveData.statPoints1 = playerStats.statPoints;
        }

        WriteSave();
    }

    public void ImportPlayerStats()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        //SET STATS IN SAVEDATA TO THOSE IN PLAYERSTATS

        if(playerStats != null)
        {
            playerStats.modStrength = saveData.modStrength1;
            playerStats.modSpeed = saveData.modSpeed1;
            playerStats.modEndurance = saveData.modEndurance1;
            playerStats.modSpirit = saveData.modSpirit1;

            playerStats.playerLevel = saveData.playerLevel1;
            playerStats.experiencePoints = saveData.experiencePoints1;
            playerStats.statPoints = saveData.statPoints1;
        }
    }
}







