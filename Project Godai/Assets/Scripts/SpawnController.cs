using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject[] enemyPrefabArray;
    public GameObject enemySpawn1;
    public GameObject enemy1;

    private int randomChoice;

	// Use this for initialization
	void Start () {
        SpawnerSetup();
        RandomiseSpawn();
        SpawnEnemy();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnerSetup()
    {
        enemyPrefabArray = Resources.LoadAll<GameObject>("EnemyPrefabs");
        enemySpawn1 = GameObject.Find("EnemySpawn1");
    }

    void RandomiseSpawn()
    {
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy1 = enemyPrefabArray[randomChoice];
        
    }

    void SpawnEnemy()
    {
        GameObject SpawnedEnemy = Instantiate(enemy1, new Vector3(0, 0, 0), Quaternion.identity, enemySpawn1.transform);
        SpawnedEnemy.name = enemy1.name;
    }

}
