using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private SpawnController spawnController;

    public int player1Speed;
    public int enemy1Speed;
    public int enemy2Speed;
    public int enemy3Speed;




    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
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


  
    public void FindStats()
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
        Dictionary<string, int> turnTimeline = new Dictionary<string, int>();

        turnTimeline.Add("player1", player1Speed);
        turnTimeline.Add("enemy1", enemy1Speed);


        if (spawnController.enemyCount > 1)
        {
            turnTimeline.Add("enemy2", enemy2Speed);
        }
        
        if (spawnController.enemyCount == 3)
        {
            turnTimeline.Add("enemy3", enemy3Speed);
        }
        

        turnTimeline = turnTimeline.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);


        foreach (KeyValuePair<string, int> kvp in turnTimeline)
        {
            print("DictVal = " + kvp.Key + " + " + kvp.Value);
        }
    }
}
