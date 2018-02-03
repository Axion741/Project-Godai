using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public GameObject player1;
    public GameObject enemy1;
    public GameObject enemySpawn1;
    public GameObject enemy2;
    public GameObject enemySpawn2;
    public GameObject enemy3;
    public GameObject enemySpawn3;


    public PlayerStats playerStats1;
    public IEnemyStats enemyStats1;
    public IEnemyStats enemyStats2;
    public IEnemyStats enemyStats3;

    public EnemyAbilities enemyAbilities1; 

    public int player1Speed;
    public int enemy1Speed;
    public int enemy2Speed;
    public int enemy3Speed;




    // Use this for initialization
    void Start () {
        FindCharacters();
        FindStats();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindCharacters()
    {
        player1 = GameObject.Find("PlayerCharacter");
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");

        if (enemySpawn1.transform.GetChild(0).gameObject != null)
        {
            enemy1 = enemySpawn1.transform.GetChild(0).gameObject;
        }
        else //enemy1 = null;

        if (enemySpawn2.transform.GetChild(0).gameObject != null)
        {
            enemy2 = enemySpawn2.transform.GetChild(0).gameObject;
        }
        else //enemy2 = null;

        if (enemySpawn3.transform.GetChild(0).gameObject != null)
        {
            enemy3 = enemySpawn3.transform.GetChild(0).gameObject;
        }
        //else enemy3 = null;




    }

    void FindStats()
    {
        playerStats1 = GameObject.FindObjectOfType<PlayerStats>();
        player1Speed = playerStats1.currentSpeed;


        if(enemy1 != null)
        {
            enemyStats1 = enemy1.GetComponentInChildren<IEnemyStats>();
            //enemyAbilities1 = enemy1.GetComponent<EnemyAbilities>();
            Debug.Log("enemyStats1 = " + enemyStats1);
        enemy1Speed = enemyStats1.Speed;        
        }

        if (enemy2 != null)
        {
            enemyStats2 = enemy2.GetComponent<IEnemyStats>();
            enemy2Speed = enemyStats2.Speed;
        }

        if (enemy3 != null)
        {
            enemyStats3 = enemy3.GetComponent<IEnemyStats>();
            enemy3Speed = enemyStats3.Speed;
        }



    }
}
