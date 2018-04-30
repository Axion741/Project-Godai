using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilities : MonoBehaviour
{

    private Animator pAnim;
    private Animator eAnim;
    private EnemyAbilities enemyAbilities;
    //private ResultsController resultsController;
    private TurnManager turnManager;
    //private SpriteRenderer frontRender;
    //private SpriteRenderer backRender;

    public IPlayerStats playerStats;
    public GameObject enemySpawn1;
    public GameObject enemySpawn2;
    public GameObject enemySpawn3;
    public GameObject enemy;
    public GameObject blast;
    public GameObject auraFront;
    public GameObject auraBack;

    public bool defeated = false;
    public float currentHealth;
    public float maxHealth;
    public float currentMP;
    public float maxMP;
    public float evasionChance;
    public float physicalResist;
    public float magicalResist;

    private float damage;
    private float sDamage;
    private float hitValue;
    private float enemyDodge;
    private float totalDamage;





    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeTarget(string targetCharacter)
    {
        switch (targetCharacter)
        {
            case "enemy1":
                enemy = enemySpawn1.transform.GetChild(0).gameObject;
                enemyAbilities = enemy.GetComponent<EnemyAbilities>();
                eAnim = enemy.GetComponent<Animator>();
                break;

            case "enemy2":
                enemy = enemySpawn2.transform.GetChild(0).gameObject;
                enemyAbilities = enemy.GetComponent<EnemyAbilities>();
                eAnim = enemy.GetComponent<Animator>();
                break;

            case "enemy3":
                enemy = enemySpawn3.transform.GetChild(0).gameObject;
                enemyAbilities = enemy.GetComponent<EnemyAbilities>();
                eAnim = enemy.GetComponent<Animator>();
                break;
        }
    }

    public void PlayerAbilitiesSetup()
    {
        //playerStats = GetComponent<PlayerStats>();
        //resultsController = FindObjectOfType<ResultsController>();
        turnManager = FindObjectOfType<TurnManager>();
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");
        enemy = enemySpawn1.transform.GetChild(0).gameObject;
        enemyAbilities = enemy.GetComponent<EnemyAbilities>();
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();   
        GetStats();
        //frontRender = auraFront.GetComponent<SpriteRenderer>();
        //backRender = auraBack.GetComponent<SpriteRenderer>();
    }

    //Stat Control
    public void GetStats()
    {
        if (gameObject.GetComponent <PlayerStats>()){
            playerStats = GetComponent<PlayerStats>();
            print("ps1 = " + playerStats);
        }
        if (gameObject.GetComponent<PlayerStats2>())
        {
            playerStats = GetComponent<PlayerStats2>();
            print("ps2 = " + playerStats);
        }
        if (gameObject.GetComponent<PlayerStats3>())
        {
            playerStats = GetComponent<PlayerStats3>();
            print("ps3 = " + playerStats);
        } 

        maxHealth = playerStats.MaxHealth;
        currentHealth = maxHealth;
        maxMP = playerStats.MaxMP;
        currentMP = maxMP;
        damage = playerStats.PhysicalDamage;
        sDamage = playerStats.MagicDamage;
        evasionChance = playerStats.EvasionChance;
        physicalResist = playerStats.PhysicalResist;
        magicalResist = playerStats.MagicalResist;
    }

    public void TakeDamage(float damage, string damageType)
    {
        switch (damageType)
        {
            case "physical":
                totalDamage = (damage - (damage * (physicalResist/100)));
                currentHealth = currentHealth - totalDamage;
                Debug.Log("Taken " + totalDamage + " physical damage");
                pAnim.SetTrigger("isDamaged");
                HealthChecker();
                break;

            case "magical":
                totalDamage = (damage - (damage * (magicalResist/100)));
                currentHealth = currentHealth - totalDamage;
                Debug.Log("Taken " + totalDamage + " magical damage");
                pAnim.SetTrigger("isDamaged");
                HealthChecker();
                break;
        }
    }

    private void HitChecker()
    {
        hitValue = Random.Range(0, 100);
        enemyDodge = enemyAbilities.evasionChance;
    }

    //Combat Methods

    public void PunchAttack()
    {
        HitChecker();
        pAnim.SetTrigger("isPunching");
        //TurnController.TurnChange();
    }

    public void PunchDamage()
    {
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            enemyAbilities.TakeDamage(damage, "physical");
        }
    }

    public void KickAttack()
    {
        HitChecker();
        pAnim.SetTrigger("isKicking");
        //TurnController.TurnChange();
    }

    public void KickDamage()
    {
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            enemyAbilities.TakeDamage(damage + 2.5f, "physical");
            //enemyAbilities.currentHealth = enemyAbilities.currentHealth - damage * 2.5f * tMultiplier * attackBoost;
            //eAnim.SetTrigger("isDamaged");
            //enemyAbilities.HealthChecker();
        }
    }

    public void BlastDashAttack()
    {
        if (currentMP < 50)
        {
            Debug.Log("MP less than 50");
        }
        else
        {
            HitChecker();
            pAnim.SetTrigger("isBlastDash");
            currentMP -= 50;
        }
    }

    public void BlastDashDamage()
    {
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            enemyAbilities.TakeDamage(sDamage * 3, "magical");
            //enemyAbilities.currentHealth = enemyAbilities.currentHealth - sDamage * 3f * tMultiplier* attackBoost;
            //eAnim.SetTrigger("isDamaged");
            //enemyAbilities.HealthChecker();
        }
    }

    public void BlastBarrageAttack()
    {

        if (currentMP < 40)
        {
            Debug.Log("MP less than 40");
        }
        else
        {
            print("Barrage Away");
            pAnim.SetTrigger("isBarrage");
        }
    }

    public void SpawnBlast()
    {
        GameObject playerBlast = Instantiate(blast, new Vector3(2.841f, 3.857f, -1), Quaternion.identity);
        playerBlast.GetComponent<Rigidbody2D>().velocity = new Vector3(8, 0, 0);
        currentMP -= 20;
    }

    public void BlastBarrageDamage()
    {
        HitChecker();
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            enemyAbilities.TakeDamage(sDamage, "magical");

            //enemyAbilities.currentHealth = enemyAbilities.currentHealth - sDamage * 1f * tMultiplier * attackBoost;
            //eAnim.SetTrigger("isDamaged");
            //enemyAbilities.HealthChecker();
        }
    }

    public void PowerUp()
    {
        pAnim.SetTrigger("isPowerUp");
        MPBoost();
        HPBoost();
    }



    //TurnChanger is called in an animation event at the end of each attack animation
    private void TurnChanger()
    {
        turnManager.CycleTurn();
    }

    private void BlockUI()
    {
        turnManager.QuickHide();
        print("UI Blocked");
    }

    private void MPBoost()
    {
        if (currentMP != maxMP)
        {
            currentMP += 20;
        }
        else if (currentMP >= maxMP - 20)
        {
            currentMP = maxMP;
        }

    }

    private void HPBoost()
    {

        if (currentHealth >= maxHealth - (sDamage*2))
        {
            currentHealth = maxHealth;
        }
        else  if (currentHealth != maxHealth)
        {
            currentHealth += (sDamage * 2);
        }

    }


    private void RemoveSelfFromTimeline()
    {
        if (transform.root.gameObject.name == "PlayerCharacter")
        {
            turnManager.RemoveFromList("player1");
        }

        if (transform.root.gameObject.name == "PlayerSpawn2")
        {
            turnManager.RemoveFromList("player2");
        }

        if (transform.root.gameObject.name == "PlayerSpawn3")
        {
            turnManager.RemoveFromList("player3");
        }
    }

    public void HealthChecker()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            defeated = true;
            pAnim.SetBool("isDead", true);
            RemoveSelfFromTimeline();
        }
    }
}