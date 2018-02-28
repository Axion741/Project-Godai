using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject[] enemyPrefabArray;
    public GameObject enemySpawn1;
    public GameObject enemySpawn2;
    public GameObject enemySpawn3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject player2;
    public GameObject player3;
    public GameObject playerSpawn2;
    public GameObject playerSpawn3;
    private int enemy1Index;
    private int enemy2Index;
    private int enemy3Index;
    private int randomChoice;
    public int enemyCount;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SpawnAllies(int player2Recruited, int player3Recruited)
    {
        playerSpawn2 = GameObject.Find("PlayerSpawn2");
        playerSpawn3 = GameObject.Find("PlayerSpawn3");
        player2 = (GameObject)Resources.Load("PlayerCharacter2");
        player3 = (GameObject)Resources.Load("PlayerCharacter3");

        if (player2Recruited == 1)
        {
            GameObject PlayerCharacter2 = Instantiate(player2, playerSpawn2.transform.position, Quaternion.identity, playerSpawn2.transform);
        }
        if(player3Recruited == 1)
        {
            GameObject PlayerCharacter3 = Instantiate(player3, playerSpawn3.transform.position, Quaternion.identity, playerSpawn3.transform);
        }
    }

    public void RunSpawnScript(string battleType)
    {
        if (battleType == "random")
        {
            RandomSpawnSequence();
        }
        else
        {
            PresetSpawnSequence(battleType);
        }
    }

    void PresetSpawnSequence(string battleType)
    {
        SpawnerSetup();
        AssignPresetSpawns(battleType);
        SpawnEnemies(enemyCount);
    }

    public void RandomSpawnSequence()
    {
        SpawnerSetup();
        AssignRandomSpawns();
        SpawnEnemies(enemyCount);
    }


    void SpawnerSetup()
    {
        enemyPrefabArray = Resources.LoadAll<GameObject>("EnemyPrefabs");
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");


    }

    void AssignRandomSpawns()
    {
        enemyCount = Random.Range(1, 4);
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy1 = enemyPrefabArray[randomChoice];
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy2 = enemyPrefabArray[randomChoice];
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy3 = enemyPrefabArray[randomChoice];
    }

    void AssignPresetSpawns(string battleType)
    {
        DetermineBattletype(battleType);
        enemy1 = enemyPrefabArray[enemy1Index];
        enemy2 = enemyPrefabArray[enemy2Index];
        enemy3 = enemyPrefabArray[enemy3Index];
    }



    void SpawnEnemies(int enemyCount)
    {
        SpawnEnemy1();
        if (enemyCount > 1)
        {
            SpawnEnemy2();
        }
        if (enemyCount == 3)
        {
            SpawnEnemy3();
        }
    }


    void SpawnEnemy1()
    {
        GameObject SpawnedEnemy1 = Instantiate(enemy1, enemySpawn1.transform.position, Quaternion.identity, enemySpawn1.transform);
        SpawnedEnemy1.name = enemy1.name;
    }

    void SpawnEnemy2()
    {
        GameObject SpawnedEnemy2 = Instantiate(enemy2, enemySpawn2.transform.position, Quaternion.identity, enemySpawn2.transform);
        SpawnedEnemy2.name = enemy2.name;
    }

    void SpawnEnemy3()
    {
       GameObject SpawnedEnemy3 = Instantiate(enemy3, enemySpawn3.transform.position, Quaternion.identity, enemySpawn3.transform);
       SpawnedEnemy3.name = enemy3.name;  
    }


    //BattleTypes are for prebaked/story battles. Indexes are based on the order in the prefab folder. Buttons initiating battle should run LoadBattle and input the battleType as a string.
    void DetermineBattletype(string battleType)
    {
        switch (battleType)
        {
            case "goblin party":
                enemyCount = 3;
                enemy1Index = 0;
                enemy2Index = 0;
                enemy3Index = 0;

                break;


            case "skeletal smash":
        
                enemyCount = 3;
                enemy1Index = 1;
                enemy2Index = 1;
                enemy3Index = 1;

                break;

            case "speedtest":

                enemyCount = 3;
                enemy1Index = 1;
                enemy2Index = 0;
                enemy3Index = 1;

                break;
        }
    }













}
