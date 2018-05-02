using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {

    private int randomSelection;

    public RawImage backgroundImage;
    private Texture[] backgroundArray;
    public Dictionary<string, Texture> backgroundDict = new Dictionary<string, Texture>();


	//Called from BattleController.Setup
    public void GetBackgrounds()
    {
        backgroundImage = GameObject.Find("ForestBackground").GetComponent<RawImage>();
        backgroundArray = Resources.LoadAll<Texture>("Backgrounds");
        BuildBackgroundDictionary();
    }

    private void BuildBackgroundDictionary()
    {
        foreach (Texture texture in backgroundArray)
        {
            backgroundDict.Add(texture.name, texture);
        }
    }
    //Called from BattleController.Awake
    public void SetBackground(string battleType)
    {
        switch (battleType)
        {
            case "random":
                randomSelection = Random.Range(0, backgroundArray.Length);
                backgroundImage.texture = backgroundArray[randomSelection];
                break;

            case "test1":
                backgroundImage.texture = backgroundDict["ForestMorning"];
                break;

            case "test2":
                backgroundImage.texture = backgroundDict["Forest"];
                break;

            case "test3":
                backgroundImage.texture = backgroundDict["ForestEvening"]; break;

            case "test4":
                backgroundImage.texture = backgroundDict["ForestRocks"]; break;

            case "test5":
                backgroundImage.texture = backgroundDict["Forest"]; break;

            case "test6":
                backgroundImage.texture = backgroundDict["ForestRocks"]; break;

            case "test7":
                backgroundImage.texture = backgroundDict["ForestMorning"]; break;

            case "test8":
                backgroundImage.texture = backgroundDict["Forest"]; break;

            case "test9":
                backgroundImage.texture = backgroundDict["ForestEvening"]; break;

            case "test10":
                backgroundImage.texture = backgroundDict["ForestRocks"]; break;
        }
    }
}
