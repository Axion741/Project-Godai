using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour {

    public GameObject enemy;
    private EnemyAbilities enemyAbilities;
    public GameObject[] blastParts;
    public Color32 levelColor;
    public int levelNumber;


    // Use this for initialization
    void Start()
    {
        enemy = GameObject.Find("EnemySpawn1");
        enemyAbilities = enemy.GetComponentInChildren<EnemyAbilities>();
        SetLevelColor();
        ProjectileColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetLevelColor()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        if (levelNumber == 7)
        {
            levelColor = new Color32(178, 0, 0, 255);
        }
        else if(levelNumber == 8)
        {
            levelColor = new Color32(0, 0, 0, 255);
        }
        else if(levelNumber == 9)
        {
            levelColor = new Color32(38, 134, 161, 255);
        }
        else if (levelNumber == 10)
        {
            levelColor = new Color32(42, 44, 114, 255);
        }
        else if (levelNumber == 11)
        {
            levelColor = new Color32(220,255,0,255);
        }
    }

    private void ProjectileColor()
    {
        blastParts = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        foreach (GameObject bP in blastParts)
            bP.GetComponent<SpriteRenderer>().color = levelColor;
            
    }
    private void OnTriggerEnter2D(Collider2D impact)
    {
        Debug.Log("Collision");
        enemyAbilities.BlastBarrageDamage();
        Destroy(gameObject);
    }
}