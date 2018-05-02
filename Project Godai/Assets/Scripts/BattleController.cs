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
    private PlayerStats2 playerStats2;
    private PlayerStats3 playerStats3;
    private PlayerAbilities playerAbilities;
    private PlayerAbilities playerAbilities2;
    private PlayerAbilities playerAbilities3;
    private ResultsController resultsController;
    private BattleButtonController battleButtonController;
    private BarController barController;
    private LevelFlagger levelFlagger;
    private BackgroundController backgroundController;

    private GameObject player1;
    private GameObject playerSpawn2;
    private GameObject playerSpawn3;
    private GameObject enemySpawn1;
    private GameObject enemySpawn2;
    private GameObject enemySpawn3;
    private TargetToggler enemy1Target;
    private TargetToggler enemy2Target;
    private TargetToggler enemy3Target;

    public float enemy1XP;
    public float enemy2XP;
    public float enemy3XP;
    public float totalXP;

    public int playerCount;
    private bool victorious = false;
    private bool defeated = false;
    public string battleType;



    // Use this for initialization
    void Awake () {
        Setup();
        spawnController.RunSpawnScript(battleType);
        spawnController.SpawnAllies(playerStats.player2recruited, playerStats.player3recruited);
        TargetSetup();
        FindAlliedCharacters();
        FindCharacters();
        EnemyAbilitiesSequence();
        EnemyTargetSetup();
        battleButtonController.Setup();
        turnManager.TurnManagerSetup();
        turnManager.RunTurn();
        levelFlagger.FlagSetup(battleType);
        backgroundController.SetBackground(battleType);
        
    }

    private void Update()
    {
        CheckVictory();
        CheckDefeat();
    }

    void Setup()
    {
        levelManager = FindObjectOfType<LevelManager>();
        turnManager = FindObjectOfType<TurnManager>();
        resultsController = FindObjectOfType<ResultsController>();
        spawnController = FindObjectOfType<SpawnController>();
        battleButtonController = FindObjectOfType<BattleButtonController>();
        barController = FindObjectOfType<BarController>();
        levelFlagger = FindObjectOfType<LevelFlagger>();
        backgroundController = FindObjectOfType<BackgroundController>();
        backgroundController.GetBackgrounds();
        player1 = GameObject.Find("PlayerCharacter");
        playerStats = player1.GetComponent<PlayerStats>();
        playerStats.PlayerStatsSetup();
        playerSpawn2 = GameObject.Find("PlayerSpawn2");
        playerSpawn3 = GameObject.Find("PlayerSpawn3");
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");
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

    public void FindAlliedCharacters()
    {
        playerAbilities = player1.GetComponent<PlayerAbilities>();
        playerAbilities.PlayerAbilitiesSetup();
        playerCount++;
        barController.EXPBarStart(1);

        if(playerStats.player2recruited == 1)
        {
            playerStats2 = playerSpawn2.GetComponentInChildren<PlayerStats2>();
            playerAbilities2 = playerSpawn2.GetComponentInChildren<PlayerAbilities>();
            playerStats2.PlayerStatsSetup();
            playerAbilities2.PlayerAbilitiesSetup();
            playerCount++;
            barController.EXPBarStart(2);
        }

        if(playerStats.player3recruited == 1)
        {
            playerStats3 = playerSpawn3.GetComponentInChildren<PlayerStats3>();
            playerAbilities3 = playerSpawn3.GetComponentInChildren<PlayerAbilities>();
            playerStats3.PlayerStatsSetup();
            playerAbilities3.PlayerAbilitiesSetup();
            playerCount++;
            barController.EXPBarStart(3);
        }

    }


    void EnemyAbilitiesSequence()
    {
        enemyAbilities1.Setup();
        enemyAbilities1.GrabStats();
        enemyAbilities1.SetupStats();
        enemy1XP = enemyAbilities1.experienceValue;

        if (spawnController.enemyCount > 1)
        {
            enemyAbilities2.Setup();
            enemyAbilities2.GrabStats();
            enemyAbilities2.SetupStats();
            enemy2XP = enemyAbilities2.experienceValue;
        }
        else return;
        if (spawnController.enemyCount == 3)
        {
            enemyAbilities3.Setup();
            enemyAbilities3.GrabStats();
            enemyAbilities3.SetupStats();
            enemy3XP = enemyAbilities3.experienceValue;
        }
        else return;

    }

    void EnemyTargetSetup()
    {

        enemyAbilities1.SwitchTargets();

        if (spawnController.enemyCount > 1)
        {

            enemyAbilities2.SwitchTargets();

        }
        else return;
        if (spawnController.enemyCount == 3)
        {

            enemyAbilities3.SwitchTargets();

        }
        else return;

    }

    void TargetSetup()
    {
        enemy1Target = enemySpawn1.GetComponentInChildren<TargetToggler>();
        enemy1Target.TargetTogglerSetup();
        enemy1Target.ToggleOn();


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
                if (enemyAbilities1.defeated == false)
                {
                    enemy1Target.ToggleOn();
                    if (spawnController.enemyCount > 1)
                    {
                    enemy2Target.ToggleOff();
                     }
                    if (spawnController.enemyCount == 3)
                    {
                    enemy3Target.ToggleOff();
                    }
                    playerAbilities.ChangeTarget("enemy1");
                    playerAbilities2.ChangeTarget("enemy1");
                    playerAbilities3.ChangeTarget("enemy1");
                }
                break;

            case "EnemySpawn2":
                if (enemyAbilities2.defeated == false)
                {
                    enemy2Target.ToggleOn();
                    enemy1Target.ToggleOff();
                    if (spawnController.enemyCount == 3)
                    {
                        enemy3Target.ToggleOff();
                    }
                    playerAbilities.ChangeTarget("enemy2");
                    playerAbilities2.ChangeTarget("enemy2");
                    playerAbilities3.ChangeTarget("enemy2");
                }
                break;

            case "EnemySpawn3":
                if (enemyAbilities3.defeated == false)
                {
                    enemy3Target.ToggleOn();
                    enemy1Target.ToggleOff();
                    enemy2Target.ToggleOff();
                    playerAbilities.ChangeTarget("enemy3");
                    playerAbilities2.ChangeTarget("enemy3");
                    playerAbilities3.ChangeTarget("enemy3");
                }
                break;
        }
    }

    public void AutoTargetSwap()
    {
        if (enemyAbilities1.defeated != true)
        {
            TargetSwapper("EnemySpawn1");
        }
        else if (enemyAbilities2.defeated != true)
        {
            TargetSwapper("EnemySpawn2");
        }
        else if (enemyAbilities3.defeated != true)
        {
            TargetSwapper("EnemySpawn3");
        }
    }

    private void CheckVictory()
    {

        switch (spawnController.enemyCount)
        {
            case 1:
                if (victorious == false & enemyAbilities1.defeated == true)
                {
                    resultsController.WinFight();
                    victorious = true;
                    levelFlagger.FlagTrigger();
                }
                break;

            case 2:
                if (victorious == false & enemyAbilities1.defeated == true & enemyAbilities2.defeated == true)
                {
                    resultsController.WinFight();
                    victorious = true;
                    levelFlagger.FlagTrigger();
                }
                break;

            case 3:
                if (victorious == false & enemyAbilities1.defeated == true & enemyAbilities2.defeated == true & enemyAbilities3.defeated == true)
                {
                    resultsController.WinFight();
                    victorious = true;
                    levelFlagger.FlagTrigger();
                }
                break;
        }

    }

    private void CheckDefeat()
    {

        switch (playerCount)
        {
            case 1:
                if (defeated == false & playerAbilities.defeated == true)
                {
                    resultsController.LoseFight();
                    defeated = true;
                }
                break;

            case 2:
                if (defeated == false & playerAbilities.defeated == true & playerAbilities2.defeated == true)
                {
                    resultsController.LoseFight();
                    defeated = true;
                }
                break;

            case 3:
                if (defeated == false & playerAbilities.defeated == true & playerAbilities2.defeated == true & playerAbilities3.defeated == true)
                {
                    resultsController.LoseFight();
                    defeated = true;
                }
                break;
        }


    }


        public void AwardExperience()
        {
        totalXP = enemy1XP + enemy2XP + enemy3XP;
        playerStats.experiencePoints = playerStats.experiencePoints + totalXP;
        barController.EXPBarWin(1);
        playerStats.LevelUp();

        if (playerStats.player2recruited == 1)
        {
            playerStats2.experiencePoints = playerStats2.experiencePoints + totalXP;
            barController.EXPBarWin(2);
            playerStats2.LevelUp();
        }

        if (playerStats.player3recruited == 1)
        {
            playerStats3.experiencePoints = playerStats3.experiencePoints + totalXP;
            barController.EXPBarWin(3);
            playerStats3.LevelUp();
        }
    }




}
