﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    private enum TurnStates { player1Turn, enemy1Turn, enemy2Turn, enemy3Turn };
    private TurnStates currentState;
    private SpawnController spawnController;


    private string currentActiveCharacter;
    private string storedCharacter;


    public GameObject player1;
    public GameObject enemy1;
    public GameObject enemySpawn1;
    public GameObject enemy2;
    public GameObject enemySpawn2;
    public GameObject enemy3;
    public GameObject enemySpawn3;
    public GameObject ControlBlocker;


    public List<string> turnTimeline;


    public PlayerStats playerStats1;
    public EnemyAbilities enemyAbilities1;
    public EnemyAbilities enemyAbilities2;
    public EnemyAbilities enemyAbilities3;


    public int player1Speed;
    public int enemy1Speed;
    public int enemy2Speed;
    public int enemy3Speed;




    // Use this for initialization
    void Start () {
        currentState = TurnStates.enemy3Turn;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnManagerSetup()
    {
        ControlBlocker = GameObject.Find("Control Blocker");
        FindCharacters();
        FindSpeed();
        BuildTurnTimeline();
    }

    public void RunTurn()
    {
        DetermineTurn();
        CurrentTurn();
    }
    
    //CycleTurn is called in PlayerAbilities and EnemyAbilities
    public void CycleTurn()
    {
        storedCharacter = turnTimeline.FirstOrDefault();
        turnTimeline.RemoveAt(0);
        turnTimeline.Add(storedCharacter);

        RunTurn();
    }

    public void FindCharacters()
    {
        spawnController = FindObjectOfType<SpawnController>();
        player1 = GameObject.Find("PlayerCharacter");
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");

            enemy1 = enemySpawn1.transform.GetChild(0).gameObject;
        
        if (spawnController.enemyCount > 1)
        {
            enemy2 = enemySpawn2.transform.GetChild(0).gameObject;
        }
        else enemy2 = null;

        if (spawnController.enemyCount == 3)
        {
            enemy3 = enemySpawn3.transform.GetChild(0).gameObject;
        }
        else enemy3 = null;
    }
  
    public void FindSpeed()
    {
        playerStats1 = GameObject.FindObjectOfType<PlayerStats>();
        player1Speed = playerStats1.currentSpeed;


        if(enemy1 != null)
        {

            enemyAbilities1 = enemy1.GetComponent<EnemyAbilities>();
            enemy1Speed = enemyAbilities1.turnSpeed;
        }

        if (enemy2 != null)
        {
            enemyAbilities2 = enemy2.GetComponent<EnemyAbilities>();
            enemy2Speed = enemyAbilities2.turnSpeed;
        }

        if (enemy3 != null)
        {
            enemyAbilities3 = enemy3.GetComponent<EnemyAbilities>();
            enemy3Speed = enemyAbilities3.turnSpeed;
        }
    }

    public void BuildTurnTimeline()
    {
        Dictionary<string, int> turnDict = new Dictionary<string, int>();


        turnDict.Add("player1", player1Speed);
        turnDict.Add("enemy1", enemy1Speed);


        if (spawnController.enemyCount > 1)
        {
            turnDict.Add("enemy2", enemy2Speed);
        }
        
        if (spawnController.enemyCount == 3)
        {
            turnDict.Add("enemy3", enemy3Speed);
        }


        turnDict = turnDict.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        
        turnTimeline = turnDict.Keys.ToList();

        //foreach (KeyValuePair<string, int> kvp in turnDict)
        //{
        //    print("DictVal = " + kvp.Key + " + " + kvp.Value);
        //}

        //foreach (string characterName in turnTimeline)
        //{
        //    print(characterName);
        //}
    }

    void DetermineTurn()
    {
        currentActiveCharacter = turnTimeline.FirstOrDefault();

        switch (currentActiveCharacter)
        {
            case ("player1"):
                currentState = TurnStates.player1Turn;
                break;

            case ("enemy1"):
                currentState = TurnStates.enemy1Turn;
                break;

            case ("enemy2"):
                currentState = TurnStates.enemy2Turn;
                break;

            case ("enemy3"):
                currentState = TurnStates.enemy3Turn;
                break;
        }
    }

    void CurrentTurn()
    {
        switch (currentState)
        {
            case (TurnStates.player1Turn):
                print("player1's turn");
                ControlBlocker.SetActive(false);
                break;

            case (TurnStates.enemy1Turn):
                print("enemy1's turn");
                ControlBlocker.SetActive(true);
                enemyAbilities1.EnemyAI();
                break;

            case (TurnStates.enemy2Turn):
                print("enemy2's turn");
                ControlBlocker.SetActive(true);
                enemyAbilities2.EnemyAI();
                break;

            case (TurnStates.enemy3Turn):
                print("enemy3's turn");
                ControlBlocker.SetActive(true);
                enemyAbilities3.EnemyAI();
                break;
        }
    }

    public void RemoveFromList(string character)
    {
        turnTimeline.Remove(character);
    }


    public void QuickHide()
    {
        ControlBlocker.SetActive(true);
    }


}
