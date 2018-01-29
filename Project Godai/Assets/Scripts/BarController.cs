using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {
    
    private float fillValue;
    public float xpFill;
    private float barSpeed = 4;

    [SerializeField]
    private Image playerHealthBar;

    [SerializeField]
    private Image playerMPBar;

    [SerializeField]
    private Image enemyHealthBar;

    [SerializeField]
    private Image enemyMPBar;

    [SerializeField]
    private Image powerBar1;

    [SerializeField]
    private Image powerBar2;

    [SerializeField]
    private Image powerBar3;

    public Image expBar;

    public GameObject powerBarLevel1;
    public GameObject powerBarLevel2;
    public GameObject powerBarLevel3;

    private int breakPoint;
    private PlayerAbilities playerAbilities;
    private PlayerStats playerStats;
    private EnemyAbilities enemyAbilities;


    // Use this for initialization
    void Start () {
        playerAbilities = FindObjectOfType<PlayerAbilities>();
        playerStats = FindObjectOfType<PlayerStats>();
        breakPoint = playerStats.breakPoint;
        enemyAbilities = FindObjectOfType<EnemyAbilities>();
	}
	
	// Update is called once per frame
	void Update () {

        PlayerHealthBar();
        PlayerMPBar();
        EnemyMPBar();
        EnemyHealthBar();
        PowerBarController();
        EXPBarWin();
        breakPoint = playerStats.breakPoint;
        Debug.Log("AbExp = " + playerStats.experiencePoints);;
        Debug.Log("AbThresh = " + playerStats.experienceThreshold);
    }

    private void PlayerHealthBar()
    {
        fillValue = PlayerAbilities.currentHealth /PlayerAbilities.maxHealth;
        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, fillValue, Time.deltaTime*barSpeed);
    }

    private void PlayerMPBar()
    {
        fillValue = PlayerAbilities.currentMP / PlayerAbilities.maxMP;
        playerMPBar.fillAmount = Mathf.Lerp(playerMPBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void EnemyHealthBar()
    {
        fillValue = enemyAbilities.currentHealth / enemyAbilities.maxHealth;
        enemyHealthBar.fillAmount = Mathf.Lerp(enemyHealthBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void EnemyMPBar()
    {
        fillValue = enemyAbilities.currentMP / enemyAbilities.maxMP;
        enemyMPBar.fillAmount = Mathf.Lerp(enemyMPBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void PowerBarController()
    {
        if (breakPoint == 0)
        {
            powerBarLevel1.SetActive(true);
            powerBarLevel2.SetActive(false);
            powerBarLevel3.SetActive(false);
            PowerBar1();
        }
        else if (breakPoint == 1)
        {
            powerBarLevel1.SetActive(false);
            powerBarLevel2.SetActive(true);
            powerBarLevel3.SetActive(false);
            PowerBar2();
        }
        else if (breakPoint == 2)
        {
            powerBarLevel1.SetActive(false);
            powerBarLevel2.SetActive(false);
            powerBarLevel3.SetActive(true);
            PowerBar3();
        }
    }

    private void PowerBar1()
    {
        fillValue = PlayerAbilities.currentPP / PlayerAbilities.maxPP;
        powerBar1.fillAmount = Mathf.Lerp(powerBar1.fillAmount, fillValue, Time.deltaTime * barSpeed);
        playerAbilities.Transformation0();
    }

    private void PowerBar2()
    {
        fillValue = PlayerAbilities.currentPP / PlayerAbilities.maxPP;
        powerBar2.fillAmount = Mathf.Lerp(powerBar2.fillAmount, fillValue, Time.deltaTime * barSpeed);
        if (fillValue <= 0.5)
        {
            powerBar2.color = new Color32(122, 243, 255, 255);
            playerAbilities.Transformation0();
        }
        else if (fillValue > 0.5)
        {
            powerBar2.color = new Color32(178, 0, 0, 255);
            playerAbilities.Transformation1();
        }
    }

    private void PowerBar3()
    {
        fillValue = PlayerAbilities.currentPP / PlayerAbilities.maxPP;
        powerBar3.fillAmount = Mathf.Lerp(powerBar3.fillAmount, fillValue, Time.deltaTime * barSpeed);
        if (fillValue <= 0.33333333)
        {
            powerBar3.color = new Color32(122, 243, 255, 255);
            playerAbilities.Transformation0();
        }
        else if (fillValue > 0.34 && fillValue <= 0.666666)
        {
            powerBar3.color = new Color32(178, 0, 0, 255);
            playerAbilities.Transformation1();
        }
        else if (fillValue > 0.67)
        {
            powerBar3.color = new Color32(255, 255, 0, 255);
            playerAbilities.Transformation2();
        }
    }

    public void EXPBarWin()
    {
        xpFill = playerStats.experiencePoints / playerStats.experienceThreshold;
        Debug.Log("xpfv = " + xpFill);
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, xpFill, Time.deltaTime * barSpeed);
    }





}
