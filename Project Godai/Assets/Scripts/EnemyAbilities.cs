using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : MonoBehaviour {

    private Animator eAnim;
    private Animator pAnim;
    private GameObject pBlast;
    private ResultsController resultsController;
    private bool defeated = false;
    private string enemyType;
    private EnemyStatFactory enemyStatFactory;
    private IEnemyStats enemyStats;

    public TurnManager turnManager;
    public PlayerAbilities playerAbilities;
    public GameObject player;
    public GameObject blast;
   
    int max = 100;
    int min = 1;
    int choice;
    float hitValue;
    float playerDodge;
    
    public static float evasionChance;
    public float currentHealth;
    public float maxHealth;
    public float currentMP;
    public float maxMP;
    public float experienceValue;
    public int turnSpeed;

    private float damage;
    private float sDamage;
    private float attackBoost = 1f;


    // Use this for initialization
    void Start () {
       // GrabStats();
        player = GameObject.Find("PlayerCharacter");
        pAnim = player.GetComponent<Animator>();
        eAnim = GetComponent<Animator>();
        playerAbilities = GameObject.FindObjectOfType<PlayerAbilities>();
        resultsController = FindObjectOfType<ResultsController>();
        turnManager = FindObjectOfType<TurnManager>();
        //SetupStats();
    }
	
	// Update is called once per frame
	void Update () {

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

    private void HitChecker()
    {
        hitValue = Random.Range(0, 100);
        playerDodge = playerAbilities.evasionChance;       
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
        }

    }

    private void KickAttack()
    {
        HitChecker();
        eAnim.SetTrigger("isKicking");
        //TurnController.TurnChange();
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
            playerAbilities.currentHealth = playerAbilities.currentHealth - sDamage * 4f * attackBoost;
            pAnim.SetTrigger("isDamaged");
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
            playerAbilities.currentHealth = playerAbilities.currentHealth - sDamage * 1.5f * attackBoost;
            pAnim.SetTrigger("isDamaged");
        }
    }

    private void PowerUp()
    {
        eAnim.SetTrigger("isPowerUp");
        attackBoost = attackBoost + 0.1f;
        //TurnController.TurnChange();
    }

    public void ResetBoost()
    {
        attackBoost = 1;
    }

    public void EnemyAI()
    {
        //Generate a number and use to determine which attack to use.
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
                 resultsController.WinFight();
            }
            
        }
        else if (defeated == true)
        {
            return;
        }
    }

}
