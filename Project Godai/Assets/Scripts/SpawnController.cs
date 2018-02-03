﻿using System.Collections;
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
    private int randomChoice;
    public int enemyCount;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SpawnSequence()
    {
        SpawnerSetup();
        RandomiseSpawn();
        SpawnEnemies(enemyCount);
    }


    void SpawnerSetup()
    {
        enemyPrefabArray = Resources.LoadAll<GameObject>("EnemyPrefabs");
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");
        enemyCount = Random.Range(1, 4);
        print("enemycount = " + enemyCount);
    }

    void RandomiseSpawn()
    {
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy1 = enemyPrefabArray[randomChoice];
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy2 = enemyPrefabArray[randomChoice];
        randomChoice = Random.Range(0, enemyPrefabArray.Length);
        enemy3 = enemyPrefabArray[randomChoice];
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
}
