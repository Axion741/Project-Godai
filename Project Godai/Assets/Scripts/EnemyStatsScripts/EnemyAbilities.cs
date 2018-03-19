using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : MonoBehaviour {

    private Animator eAnim;
    public Animator pAnim;
    private GameObject pBlast;

    public bool defeated = false;
    private string enemyType;
    private EnemyStatFactory enemyStatFactory;
    private IEnemyStats enemyStats;
    public BattleController battleController;

    public TurnManager turnManager;
    public PlayerAbilities playerAbilities;
    public GameObject player;
    private GameObject player2Spawn;
    private GameObject player3Spawn;
    public GameObject blast;
   
    int max = 100;
    int min = 1;
    int choice;
    float hitValue;
    float playerDodge;
    
    public float evasionChance;
    public float currentHealth;
    public float maxHealth;
    public float currentMP;
    public float maxMP;
    public float experienceValue;
    public int turnSpeed;
    public int targetChoice;

    private float damage;
    private float sDamage;
    private float attackBoost = 1f;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Setup()
    {
        eAnim = GetComponent<Animator>();
        SetupTargets();
        battleController = FindObjectOfType<BattleController>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void GrabStats()
    {
        enemyType = this.gameObject.name.ToString();
        print(enemyType);
        enemyStatFactory = FindObjectOfType<EnemyStatFactory>();
        enemyStats = enemyStatFactory.Create(enemyType, gameObject);
        print("enemyStats = " + enemyStats);
    }

    public void SetupStats()
    {
        maxHealth = enemyStats.MaxHealth;
        print("maxHP = " + maxHealth);
        currentHealth = maxHealth;
        print("currentHP = " + currentHealth);
        maxMP = enemyStats.MaxMP;
        print("maxMP = " + maxMP);
        currentMP = maxMP;
        print("currentMP = " + currentMP);
        damage = enemyStats.PhysicalDamage;
        sDamage = enemyStats.MagicDamage;
        evasionChance = enemyStats.EvasionChance;
        experienceValue = enemyStats.ExperienceValue;
        turnSpeed = enemyStats.Speed;
        print("turnspeed = " + turnSpeed);
    }

    public void SetupTargets()
    {
        player = GameObject.Find("PlayerCharacter");
        player2Spawn = GameObject.Find("PlayerSpawn2");
        player3Spawn = GameObject.Find("PlayerSpawn3");
    }

    public void RunTurn()
    {
        SwitchTargets();
        if(playerAbilities.defeated != true)
        {
            EnemyAI();
        }
        else
        {
            RunTurn();
        }
    }

    public void SwitchTargets()
    {
        targetChoice = Random.Range(1, battleController.playerCount + 1);

        switch (targetChoice)
        {
            case 1: 
                pAnim = player.GetComponent<Animator>();
                playerAbilities = player.GetComponent<PlayerAbilities>();
                playerDodge = playerAbilities.evasionChance;
                //if (playerAbilities.defeated == true)
                //{
                //    SwitchTargets();
                //}
                break;

            case 2:
                pAnim = player2Spawn.GetComponentInChildren<Animator>();
                playerAbilities = player2Spawn.GetComponentInChildren<PlayerAbilities>();
                playerDodge = playerAbilities.evasionChance;
                //if (playerAbilities.defeated == true)
                //{
                //    SwitchTargets();
                //}
                break;

            case 3:
                pAnim = player3Spawn.GetComponentInChildren<Animator>();
                playerAbilities = player3Spawn.GetComponentInChildren<PlayerAbilities>();
                playerDodge = playerAbilities.evasionChance;
                //if (playerAbilities.defeated == true)
                //{
                //    SwitchTargets();
                //}
                break;
        }
    }

    private void HitChecker()
    {
        hitValue = Random.Range(0, 100);      
    }

    private void PunchAttack()
    {
        HitChecker();
        eAnim.SetTrigger("isPunching");
        //TurnController.TurnChange();
    }

    public void PunchDamage()
    {
        if (hitValue <= playerDodge)
        {
            pAnim.SetTrigger("isDodging");
        }
        else if (hitValue > playerDodge)
        {
            playerAbilities.currentHealth = playerAbilities.currentHealth - damage * attackBoost;
            pAnim.SetTrigger("isDamaged");
            playerAbilities.HealthChecker();
        }

    }

    private void KickAttack()
    {
        HitChecker();
        eAnim.SetTrigger("isKicking");
    }

    public void KickDamage()
    {
        if (hitValue <= playerDodge)
        {
            pAnim.SetTrigger("isDodging");
        }
        else if (hitValue > playerDodge)
        {
            playerAbilities.currentHealth = playerAbilities.currentHealth - damage * 2.5f * attackBoost;
            pAnim.SetTrigger("isDamaged");
            playerAbilities.HealthChecker();
        }
    }

    public void BlastDashAttack()
    {
        if (currentMP < 50)
        {
            Debug.Log("Too little MP");
            EnemyAI();
        }
        else
        {
            HitChecker();
            eAnim.SetTrigger("isBlastDash");
            currentMP -= 50;
        }
    }

    public void BlastDashDamage()
    {
        if (hitValue <= playerDodge)
        {
            pAnim.SetTrigger("isDodging");
        }
        else if (hitValue > playerDodge)
        {
            playerAbilities.currentHealth = playerAbilities.currentHealth - sDamage * 3f * attackBoost;
            pAnim.SetTrigger("isDamaged");
            playerAbilities.HealthChecker();
        }
    }

    public void BlastBarrageAttack()
    {
        if (currentMP < 40)
        {
            Debug.Log("Too little MP");
            EnemyAI();
        }
        else
        {
            eAnim.SetTrigger("isBarrage");
        }
    }

    public void SpawnBlast()
    {
        GameObject enemyBlast = Instantiate(blast, new Vector3(7.08f, 3.857f, -1), Quaternion.Euler(0,180,0));
        enemyBlast.GetComponent<Rigidbody2D>().velocity = new Vector3(-8, 0, 0);
        currentMP -= 20;
    }

    public void BlastBarrageDamage()
    {
        HitChecker();
        if (hitValue <= playerDodge)
        {
            pAnim.SetTrigger("isDodging");
        }
        else if (hitValue > playerDodge)
        {
            playerAbilities.currentHealth = playerAbilities.currentHealth - sDamage * 1f * attackBoost;
            pAnim.SetTrigger("isDamaged");
            playerAbilities.HealthChecker();
        }
    }

    private void PowerUp()
    {
        if(currentMP != maxMP)
        {
            eAnim.SetTrigger("isPowerUp");
            MPBoost();
        }
        else
        {
            EnemyAI();
        }

    }

    public void ResetBoost()
    {
        attackBoost = 1;
    }

    public void EnemyAI()
    {
        //Generate a number and use to determine which attack to use.
        //SwitchTargets();

        choice = Random.Range(min, max);
        if (choice <= 20)
        {
            KickAttack();
        }
        else if (choice > 20 && choice <= 50)
        {
            PunchAttack();
        }
        else if (choice > 50 && choice <= 70)
        {
            PowerUp();
        }
        else if (choice > 70 && choice <= 90)
        {
            BlastBarrageAttack();
        }
        else if (choice > 90 && choice <= 100)
        {
            BlastDashAttack();
        }
    }

    //TurnChanger is called in an animation event at the end of each attack animation
    private void TurnChanger()
    {
        Debug.Log("ETurnChanger Triggered");
        turnManager.CycleTurn();
        
    }

    public void HealthChecker()
    {
        if (defeated == false)
        {
            
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else if (currentHealth <= 0)
            {
                defeated = true;
                eAnim.SetBool("isDead", true);
                RemoveSelfFromTimeline();
                battleController.AutoTargetSwap();
            }
            
        }
        else if (defeated == true)
        {
            return;
        }
    }

    private void RemoveSelfFromTimeline()
    {
        if(transform.root.gameObject.name == "EnemySpawn1")
        {
            turnManager.RemoveFromList("enemy1");
        }

        if (transform.root.gameObject.name == "EnemySpawn2")
        {
            turnManager.RemoveFromList("enemy2");
        }

        if (transform.root.gameObject.name == "EnemySpawn3")
        {
            turnManager.RemoveFromList("enemy3");
        }
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


}
