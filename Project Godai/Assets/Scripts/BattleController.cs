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
    private TargetToggler enemy1Target;
    private TargetToggler enemy2Target;
    private TargetToggler enemy3Target;

    public GameObject currentTarget;
    public string battleType;



    // Use this for initialization
    void Awake () {
        Setup();
        playerStats.PlayerStatsSetup();
        spawnController.RunSpawnScript(battleType);
        TargetSetup();
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

    void TargetSetup()
    {
        enemy1Target = enemySpawn1.GetComponentInChildren<TargetToggler>();
        enemy1Target.TargetTogglerSetup();
        enemy1Target.ToggleOn();
        currentTarget = enemy1;

        if (spawnController.enemyCount > 1)
        {
            enemy2Target = enemySpawn2.GetComponentInChildren<TargetToggler>();
            enemy2Target.TargetTogglerSetup();
        }
        else enemy2Target = null; enemy3Target = null;

        if (spawnController.enemyCount == 3)
        {
            enemy3Target = enemySpawn3.GetComponentInChildren<TargetToggler>();
            enemy3Target.TargetTogglerSetup();

        }
        else enemy3Target = null;

    }

    public void TargetSwapper(string targetName)
    {
        switch (targetName)
        {
            case "EnemySpawn1":
                enemy1Target.ToggleOn();
                enemy2Target.ToggleOff();
                enemy3Target.ToggleOff();
                currentTarget = enemy1;
                break;

            case "EnemySpawn2":
                enemy2Target.ToggleOn();
                enemy1Target.ToggleOff();
                enemy3Target.ToggleOff();
                currentTarget = enemy2;
                break;

            case "EnemySpawn3":
                enemy3Target.ToggleOn();
                enemy1Target.ToggleOff();
                enemy2Target.ToggleOff();
                currentTarget = enemy3;
                break;
        }
    }








}
