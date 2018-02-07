using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

    private LevelManager levelManager;
    private TurnManager turnManager;
    private SpawnController spawnController;
    private EnemyAbilities enemyAbilities1;
    private EnemyAbilities enemyAbilities2;
    private EnemyAbilities enemyAbilities3;
    private PlayerStats playerStats;
    private PlayerAbilities playerAbilities;

    private GameObject enemySpawn1;
    private GameObject enemySpawn2;
    private GameObject enemySpawn3;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;

    public string battleType;



    // Use this for initialization
    void Awake () {
        Setup();
        playerStats.PlayerStatsSetup();
        spawnController.RunSpawnScript(battleType);
        playerAbilities.PlayerAbilitiesSetup();
        FindCharacters();
        EnemyAbilitiesSequence();
        turnManager.TurnManagerSetup();
        turnManager.RunTurn();
    }

    void Setup()
    {
        levelManager = FindObjectOfType<LevelManager>();
        turnManager = FindObjectOfType<TurnManager>();
        spawnController = FindObjectOfType<SpawnController>();
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");
        playerStats = FindObjectOfType<PlayerStats>();
        playerAbilities = FindObjectOfType<PlayerAbilities>();
        battleType = levelManager.battleType;
        Debug.Log("battleType = " + battleType);
    }

    public void FindCharacters()
    {
        enemyAbilities1 = enemySpawn1.GetComponentInChildren<EnemyAbilities>();
        if (spawnController.enemyCount > 1)
        {
            enemyAbilities2 = enemySpawn2.GetComponentInChildren<EnemyAbilities>();
        }
        else enemyAbilities2 = null; enemyAbilities3 = null;
        if (spawnController.enemyCount == 3)
        {
            enemyAbilities3 = enemySpawn3.GetComponentInChildren<EnemyAbilities>();
        }
        else enemyAbilities3 = null;
    }

    void EnemyAbilitiesSequence()
    {
        enemyAbilities1.GrabStats();
        enemyAbilities1.SetupStats();

        if (spawnController.enemyCount > 1)
        {
            enemyAbilities2.GrabStats();
            enemyAbilities2.SetupStats();
        }
        else return;
        if (spawnController.enemyCount == 3)
        {
            enemyAbilities3.GrabStats();
            enemyAbilities3.SetupStats();
        }
        else return;

    }










}
