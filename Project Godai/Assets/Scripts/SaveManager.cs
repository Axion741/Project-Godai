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
    private PlayerStats2 playerStats2;
    private PlayerStats3 playerStats3;
    private string filePath;

    // Use this for initialization
    void Start()
    {
        saveData = GetComponent<SaveData>();
        filePath = Path.Combine (Application.persistentDataPath, "save.txt");
        Load();
    }

    //WRITES EVERYTHING IN THE "SAVEDATA" CLASS TO A JSONSTRING
    void WriteSave()
    {
        string jsonString = JsonUtility.ToJson(saveData);
        File.WriteAllText(filePath, jsonString);
        print("Game Saved");
    }

    //CHECKS IF SAVE EXISTS AT FILEPATH, LOADS IF PRESENT, OVERWRITING SAVEDATA CLASS.
    void Load()
    {
        if (File.Exists(filePath))
        {

            string jsonString = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonString, saveData);
            print("Save Loaded");
            //SaveAllData();
        }
        else //IF NO SAVE PRESENT, WRITE ONE AND "LOAD IT" FOR GOOD MEASURE
        {
            WriteSave();
            Load();
        }
    }

    //CHARACTER STAT SETTING METHODS//

    public void SaveAllData()
    {
        //////SAVE CHARACTER1 STATS/////////
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

        //////SAVE CHARACTER2 STATS/////////
        playerStats2 = FindObjectOfType<PlayerStats2>();

        //SET STATS IN SAVEDATA TO THOSE IN PLAYERSTATS2
        if (playerStats2 != null)
        {
            saveData.modStrength2 = playerStats2.modStrength;
            saveData.modSpeed2 = playerStats2.modSpeed;
            saveData.modEndurance2 = playerStats2.modEndurance;
            saveData.modSpirit2 = playerStats2.modSpirit;

            saveData.playerLevel2 = playerStats2.playerLevel;
            saveData.experiencePoints2 = playerStats2.experiencePoints;
            saveData.statPoints2 = playerStats2.statPoints;
        }

        //////SAVE CHARACTER3 STATS/////////
        playerStats3 = FindObjectOfType<PlayerStats3>();

        //SET STATS IN SAVEDATA TO THOSE IN PLAYERSTATS3
        if (playerStats3 != null)
        {
            saveData.modStrength3 = playerStats3.modStrength;
            saveData.modSpeed3 = playerStats3.modSpeed;
            saveData.modEndurance3 = playerStats3.modEndurance;
            saveData.modSpirit3 = playerStats3.modSpirit;

            saveData.playerLevel3 = playerStats3.playerLevel;
            saveData.experiencePoints3 = playerStats3.experiencePoints;
            saveData.statPoints3 = playerStats3.statPoints;
        }

        WriteSave();
    }

    public void ImportPlayerStats()
    {

        //////LOAD CHARACTER1 STATS/////////
        playerStats = FindObjectOfType<PlayerStats>();

        //SET STATS IN PLAYERSTATS TO THOSE IN SAVEDATA

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

        //////LOAD CHARACTER2 STATS/////////
        playerStats2 = FindObjectOfType<PlayerStats2>();

        //SET STATS IN PLAYERSTATS2 TO THOSE IN SAVEDATA

        if (playerStats2 != null)
        {
            playerStats2.modStrength = saveData.modStrength2;
            playerStats2.modSpeed = saveData.modSpeed2;
            playerStats2.modEndurance = saveData.modEndurance2;
            playerStats2.modSpirit = saveData.modSpirit2;

            playerStats2.playerLevel = saveData.playerLevel2;
            playerStats2.experiencePoints = saveData.experiencePoints2;
            playerStats2.statPoints = saveData.statPoints2;
        }

        //////LOAD CHARACTER3 STATS/////////
        playerStats3 = FindObjectOfType<PlayerStats3>();

        //SET STATS IN PLAYERSTATS3 TO THOSE IN SAVEDATA

        if (playerStats3 != null)
        {
            playerStats3.modStrength = saveData.modStrength3;
            playerStats3.modSpeed = saveData.modSpeed3;
            playerStats3.modEndurance = saveData.modEndurance3;
            playerStats3.modSpirit = saveData.modSpirit3;

            playerStats3.playerLevel = saveData.playerLevel3;
            playerStats3.experiencePoints = saveData.experiencePoints3;
            playerStats3.statPoints = saveData.statPoints3;
        }

    }
}







