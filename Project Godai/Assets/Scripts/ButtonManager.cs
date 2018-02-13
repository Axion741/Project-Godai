using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    private LevelManager levelManager;
    

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
    public void SendToBattle(string BattleIndex)
    {
        levelManager.LoadBattle(BattleIndex);
    }

    public void LoadStart(string name)
    {
        levelManager.LoadStart(name);
    }

    public void LoadLevel(string name)
    {
        levelManager.LoadLevel(name);
    }

    public void Quit()
    {
        levelManager.QuitRequest();
    }
}
