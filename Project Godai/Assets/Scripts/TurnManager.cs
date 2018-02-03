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
    public EnemyAbilities enemyAbilities1;
    public EnemyAbilities enemyAbilities2;
    public EnemyAbilities enemyAbilities3;

    public int player1Speed;
    public int enemy1Speed;
    public int enemy2Speed;
    public int enemy3Speed;




    // Use this for initialization
    void Start () {
        FindCharacters();
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

        if (enemySpawn2.transform.GetChild(0).gameObject != null)
        {
            enemy2 = enemySpawn2.transform.GetChild(0).gameObject;
        }
  
        if (enemySpawn3.transform.GetChild(0).gameObject != null)
        {
            enemy3 = enemySpawn3.transform.GetChild(0).gameObject;
        }
    }


    //Called from EnemyAbilities.SetupStats to ensure turnspeeds are set correctly
    public void FindStats()
    {
        playerStats1 = GameObject.FindObjectOfType<PlayerStats>();
        player1Speed = playerStats1.currentSpeed;


        if(enemy1 != null)
        {
            //enemyStats1 = enemy1.GetComponentInChildren<IEnemyStats>();
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
}
