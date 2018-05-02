using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour {

    private SaveData saveData;

    public Button level2;
    private Button level3;
    private Button level4;
    private Button level5;
    private Button level6;
    private Button level7;
    private Button level8;
    private Button level9;
    private Button level10;

    private int unlockedLevels;

    // Use this for initialization
    void Start () {
        saveData = FindObjectOfType<SaveData>();
        ButtonSetup();
        CheckUnlockedLevels();
	}
	
    private void ButtonSetup()
    {
        level2 = GameObject.Find("MapButtons/Level2/Button").GetComponent<Button>();
        level2.interactable = false;
        level3 = GameObject.Find("MapButtons/Level3/Button").GetComponent<Button>();
        level3.interactable = false;
        level4= GameObject.Find("MapButtons/Level4/Button").GetComponent<Button>();
        level4.interactable = false;
        level5 = GameObject.Find("MapButtons/Level5/Button").GetComponent<Button>();
        level5.interactable = false;
        level6 = GameObject.Find("MapButtons/Level6/Button").GetComponent<Button>();
        level6.interactable = false;
        level7 = GameObject.Find("MapButtons/Level7/Button").GetComponent<Button>();
        level7.interactable = false;
        level8 = GameObject.Find("MapButtons/Level8/Button").GetComponent<Button>();
        level8.interactable = false;
        level9 = GameObject.Find("MapButtons/Level9/Button").GetComponent<Button>();
        level9.interactable = false;
        level10 = GameObject.Find("MapButtons/Level10/Button").GetComponent<Button>();
        level10.interactable = false;
    }

    //LevelUnlocks triggered by LevelFlagger in BattleScene
    private void CheckUnlockedLevels()
    {
        unlockedLevels = saveData.highestLevelUnlocked;

        if(unlockedLevels >= 2)
        {
            level2.interactable = true;
        }
        if (unlockedLevels >= 3)
        {
            level3.interactable = true;
        }
        if (unlockedLevels >= 4)
        {
            level4.interactable = true;
        }
        if (unlockedLevels >= 5)
        {
            level5.interactable = true;
        }
        if (unlockedLevels >= 6)
        {
            level6.interactable = true;
        }
        if (unlockedLevels >= 7)
        {
            level7.interactable = true;
        }
        if (unlockedLevels >= 8)
        {
            level8.interactable = true;
        }
        if (unlockedLevels >= 9)
        {
            level9.interactable = true;
        }
        if (unlockedLevels >= 10)
        {
            level10.interactable = true;
        }
    }
}
