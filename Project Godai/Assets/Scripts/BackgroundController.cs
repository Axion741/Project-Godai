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
        //Background set in SpawnController.DetermineBattleType
    public void SetBackgroundImage(string background)
    {
        switch (background)
        {
            case null:
                randomSelection = Random.Range(0, backgroundArray.Length);
                backgroundImage.texture = backgroundArray[randomSelection];
                break;

            case "Forest":
                backgroundImage.texture = backgroundDict["Forest"]; 
                break;

            case "ForestMorning":
                backgroundImage.texture = backgroundDict["ForestMorning"];
                break;

            case "ForestEvening":
                backgroundImage.texture = backgroundDict["ForestEvening"];
                break;

            case "ForestRocks":
                backgroundImage.texture = backgroundDict["ForestRocks"];
                break;
        }
    }
}
