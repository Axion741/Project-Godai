using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlagger : MonoBehaviour {

    public SaveData saveData;
    private SaveManager saveManager;
    public int oldHighestLevel;
    public int newHighestLevel;

	// Use this for initialization
	void Start () {
        saveData = FindObjectOfType<SaveData>();
        saveManager = FindObjectOfType<SaveManager>();
        oldHighestLevel = saveData.highestLevelUnlocked;
	}
	
    //Called from BattleController.Awake
    public void FlagSetup(string battleType)
    {

        print("battletype =" + battleType);
        switch (battleType)
        {
            case "random":
                break;

            case "test1":
                newHighestLevel = 2;
                break;

            case "test2":
                newHighestLevel = 3;
                break;

            case "test3":
                newHighestLevel = 4;
                break;

            case "test4":
                newHighestLevel = 5;
                break;

            case "test5":
                newHighestLevel = 6;
                break;

            case "test6":
                newHighestLevel = 7;
                break;

            case "test7":
                newHighestLevel = 8;
                break;

            case "test8":
                newHighestLevel = 9;
                break;

            case "test9":
                newHighestLevel = 10;
                break;

            case "test10":
                newHighestLevel = 11;
                break;

        }
    }
    //Called from BattleController.CheckVictory
    public void FlagTrigger()
    {
        if(oldHighestLevel >= newHighestLevel)
        {
            return;
        }
        else
        {
            saveData.highestLevelUnlocked = newHighestLevel;
            saveManager.SaveAllData();
        }
    }
}
