using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : MonoBehaviour {

    private Animator eAnim;
    private Animator pAnim;
    private GameObject pBlast;
    private ResultsController resultsController;
    private bool defeated = false;

    public PlayerStats playerStats;
    public GameObject player;
    public GameObject blast;
   
    int max = 100;
    int min = 1;
    int choice;
    float hitValue;
    float playerDodge;
    
    public static float evasionChance = 10f;
    public float currentHealth;
    public float maxHealth = 100;
    public float currentMP;
    public float maxMP = 100;

    public float experienceValue;

    public float damage = 10;
    private float attackBoost = 1f;


    // Use this for initialization
    void Start () {
        pAnim = player.GetComponent<Animator>();
        eAnim = GetComponent<Animator>();
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        resultsController = FindObjectOfType<ResultsController>();
        currentHealth = maxHealth;
        currentMP = maxMP;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void HitChecker()
    {
        hitValue = Random.Range(0, 100);
        playerDodge = playerStats.evasionChance;       
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
        PlayerAbilities.currentHealth = PlayerAbilities.currentHealth - damage * attackBoost;
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
            PlayerAbilities.currentHealth = PlayerAbilities.currentHealth - damage * 2.5f * attackBoost;
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
            PlayerAbilities.currentHealth = PlayerAbilities.currentHealth - damage * 4f * attackBoost;
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
            PlayerAbilities.currentHealth = PlayerAbilities.currentHealth - damage * 1.5f * attackBoost;
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

    public void EnemyAttackController()
    {
        if(TurnController.playerTurn == true)
        {
            Debug.Log("Not Enemy Turn");
        }else if (TurnController.playerTurn == false)
        {
            EnemyAI();
        }
    }

    private void TurnChanger()
    {
        Debug.Log("ETurnChanger Triggered");
        TurnController.TurnChange();
        
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
