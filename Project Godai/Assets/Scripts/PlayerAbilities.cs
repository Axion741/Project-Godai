using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilities : MonoBehaviour
{

    private Animator pAnim;
    private Animator eAnim;
    private EnemyAbilities enemyAbilities;
    private ResultsController resultsController;
    private TurnManager turnManager;
    private SpriteRenderer frontRender;
    private SpriteRenderer backRender;

    public PlayerStats playerStats;
    public GameObject enemySpawn1;
    public GameObject enemySpawn2;
    public GameObject enemySpawn3;
    public GameObject enemy;
    public GameObject blast;
    public GameObject auraFront;
    public GameObject auraBack;


    public float currentHealth;
    public float maxHealth;
    public float currentMP;
    public float maxMP;
    public static float currentPP;
    public static float maxPP;
    public float evasionChance;

    private float damage;
    private float sDamage;
    private float attackBoost = 1f;
    private float tMultiplier = 1;
    private float hitValue;
    private float enemyDodge;
    private int breakChance = 5;
    private float choice;
    private float min = 1;
    private float max = 100;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Choice = " + choice + ", BreakChance = " + breakChance);
        Debug.Log("currentPP = " + currentPP);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            pAnim.SetBool("isDead", true);
            resultsController.LoseFight();

        }
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
        playerStats = FindObjectOfType<PlayerStats>();
        resultsController = FindObjectOfType<ResultsController>();
        turnManager = FindObjectOfType<TurnManager>();
        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");
        enemy = enemySpawn1.transform.GetChild(0).gameObject;
        enemyAbilities = enemy.GetComponent<EnemyAbilities>();
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        GetStats();
        frontRender = auraFront.GetComponent<SpriteRenderer>();
        backRender = auraBack.GetComponent<SpriteRenderer>();
    }

    //Stat Control
    public void GetStats()
    {
        maxHealth = playerStats.maxHealth;
        currentHealth = maxHealth;
        maxMP = playerStats.maxMP;
        currentMP = maxMP;
        damage = playerStats.physicalDamage;
        sDamage = playerStats.magicDamage;
        maxPP = playerStats.maxPP;
        currentPP = 0;
        breakChance = PlayerPrefsManager.GetBreakChance();
        evasionChance = playerStats.evasionChance;
    }

    private void HitChecker()
    {
        hitValue = Random.Range(0, 100);
        enemyDodge = EnemyAbilities.evasionChance;
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
            enemyAbilities.currentHealth = enemyAbilities.currentHealth - damage * tMultiplier * attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyAbilities.HealthChecker();
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
            enemyAbilities.currentHealth = enemyAbilities.currentHealth - damage * 2.5f * tMultiplier * attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyAbilities.HealthChecker();
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
            enemyAbilities.currentHealth = enemyAbilities.currentHealth - sDamage * 3f * tMultiplier* attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyAbilities.HealthChecker();
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
            enemyAbilities.currentHealth = enemyAbilities.currentHealth - sDamage * 1f * tMultiplier * attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyAbilities.HealthChecker();
        }
    }

    public void PowerUp()
    {
        pAnim.SetTrigger("isPowerUp");
        MPBoost();
        LimitBreak();
        attackBoost = 1 + (currentPP / 10);
        //TurnController.TurnChange();
    }

    public void MeleeReset()
    {
        if (currentPP != 0)
        {
            currentPP -= 1;
        }
        else return;
    }

    public void EnergyReset()
    {
        if (currentPP >= 2)
        {
            currentPP -= 2;
        }else if (currentPP < 2)
        {
            currentPP = 0;
        }
    }

    //TurnChanger is called in an animation event at the end of each attack animation
    private void TurnChanger()
    {
        turnManager.CycleTurn();
    }

    private void BlockUI()
    {
        turnManager.QuickHide();
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

    private void LimitBreak()
    {
        if (currentPP != maxPP)
        {
            currentPP = currentPP + 1;
        }
        else if (currentPP == maxPP)
        {
            //Generate number between 1/100 to compare to breakChance
            choice = Random.Range(min, max);

            if (playerStats.breakPoint < 2)
            {
                
                if (choice <= breakChance)
                {
                    playerStats.breakPoint++;
                    PlayerPrefsManager.SetBreakPoint(playerStats.breakPoint);
                    breakChance = 5;
                    PlayerPrefsManager.SetBreakChance(breakChance);
                    playerStats.DeterminePP();
                    maxPP = playerStats.maxPP;
                    currentPP += 1;
                }
                else if (choice > breakChance)
                {
                    breakChance += 5;
                    PlayerPrefsManager.SetBreakChance(breakChance);
                }
            else{
                    breakChance = 0;
                }

            }
        }
    }

    public void Transformation0()
    {
        frontRender.color = new Color32(122, 243, 255, 255);
        backRender.color = new Color32(122, 243, 255, 255);
        tMultiplier = 1;
    }

    public void Transformation1()
    {
        frontRender.color = new Color32(178, 0, 0, 255);
        backRender.color = new Color32(178, 0, 0, 255);
        tMultiplier = 2;
    }

    public void Transformation2()
    {
        frontRender.color = new Color32(255, 255, 0, 255);
        backRender.color = new Color32(255, 255, 0, 255);
        tMultiplier = 4;
    }

}