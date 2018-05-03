using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarController : MonoBehaviour {

    private float fillValue;
    private float barSpeed = 4;
    private bool attachedPlayer = false;
    private bool attachedEnemy = false;


    public Image healthBar;
    public Image magicBar;

    private PlayerAbilities playerAbilities;
    private EnemyAbilities enemyAbilities;

    // Use this for initialization
    void Start () {
        Setup();

	}
	
	// Update is called once per frame
	void Update () {
        if (attachedPlayer == true){
            RunPlayerBars();
        }
        else if (attachedEnemy == true)
        {
            RunEnemyBars();
        }
        
    }

    void Setup()
    {
        healthBar = transform.Find("Body/StatusBars/Background/HBMask/HealthBar").gameObject.GetComponent<Image>();
        magicBar = transform.Find("Body/StatusBars/Background/MBMask/MagicBar").gameObject.GetComponent<Image>();
        DetermineCharacter();
    }

    void DetermineCharacter()
    {
        if(gameObject.tag == "PlayerCharacter")
        {
            playerAbilities = gameObject.GetComponent<PlayerAbilities>();
            attachedPlayer = true;
        }
        else if(gameObject.tag == "EnemyCharacter")
        {
            enemyAbilities = gameObject.GetComponent<EnemyAbilities>();
            attachedEnemy = true;
        }
    }

    public void RunPlayerBars()
    {
        PlayerHealthBar();
        PlayerMPBar();
    }

    public void RunEnemyBars()
    {
        EnemyHealthBar();
        EnemyMPBar();
    }

    private void PlayerHealthBar()
    {
        fillValue = playerAbilities.currentHealth / playerAbilities.maxHealth;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void PlayerMPBar()
    {
        fillValue = playerAbilities.currentMP / playerAbilities.maxMP;
        magicBar.fillAmount = Mathf.Lerp(magicBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void EnemyHealthBar()
    {
        fillValue = enemyAbilities.currentHealth / enemyAbilities.maxHealth;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void EnemyMPBar()
    {
        fillValue = enemyAbilities.currentMP / enemyAbilities.maxMP;
        magicBar.fillAmount = Mathf.Lerp(magicBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }
}
