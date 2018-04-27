using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {
    

    private float xpFill;
    private float xpFill2;
    private float xpFill3;
    private float barSpeed = 2;
    private float barStart1;
    private float barStart2;
    private float barStart3;
    private int player1BarRun;
    private int player2BarRun;
    private int player3BarRun;


    public GameObject barParent1;
    public GameObject barParent2;
    public GameObject barParent3;
    public Image expBar;
    public Image expBar2;
    public Image expBar3;

    private PlayerStats playerStats;
    private PlayerStats2 playerStats2;
    private PlayerStats3 playerStats3;



    // Use this for initialization
    void Start () {

        playerStats = FindObjectOfType<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        //EXPBarWin();
        //Debug.Log("AbExp = " + playerStats.experiencePoints);;
        //Debug.Log("AbThresh = " + playerStats.experienceThreshold);
        RunExpBars();
    }


    public void EXPBarStart(int character)
    {
        switch (character)
        {
            case 1:
                barParent1.SetActive(true);
                playerStats = FindObjectOfType<PlayerStats>();
                barStart1 = playerStats.experiencePoints / playerStats.experienceThreshold;
                break;

            case 2:
                barParent2.SetActive(true);
                playerStats2 = FindObjectOfType<PlayerStats2>();
                barStart2 = playerStats2.experiencePoints / playerStats2.experienceThreshold;
                break;

            case 3:
                barParent3.SetActive(true);
                playerStats3 = FindObjectOfType<PlayerStats3>();
                barStart3 = playerStats3.experiencePoints / playerStats3.experienceThreshold;
                break;
        }
    }

    public void EXPBarWin(int character)
    {
        switch (character)
        {
            case 1:
                expBar.fillAmount = barStart1;
                xpFill = playerStats.experiencePoints / playerStats.experienceThreshold;
                //Debug.Log("xpfv = " + xpFill);
                //expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, xpFill, Time.deltaTime * barSpeed);
                player1BarRun = 1;
                break;

            case 2:
                expBar2.fillAmount = barStart2;
                xpFill2 = playerStats2.experiencePoints / playerStats2.experienceThreshold;
                //Debug.Log("xpfv = " + xpFill);
                //expBar2.fillAmount = Mathf.Lerp(expBar2.fillAmount, xpFill2, Time.deltaTime * barSpeed);
                player2BarRun = 1;
                break;

            case 3:
                expBar3.fillAmount = barStart3;
                xpFill3 = playerStats3.experiencePoints / playerStats3.experienceThreshold;
                //Debug.Log("xpfv = " + xpFill);
                //expBar3.fillAmount = Mathf.Lerp(expBar3.fillAmount, xpFill3, Time.deltaTime * barSpeed);
                player3BarRun = 1;
                break;
        }


    }

    //if playerBarRun == 0, player not present. if == 1, animate exp bar
    private void RunExpBar1()
    {
        if(player1BarRun == 1)
        {
            if (expBar.fillAmount != 1)
            {
                expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, xpFill, Time.deltaTime * barSpeed);
            }
            if (expBar.fillAmount == 1)
            {
                expBar.fillAmount = 0;
                EXPBarWin(1);
            }
        }
    }

    private void RunExpBar2()
    {
        if (player2BarRun == 1)
        {
            if (expBar2.fillAmount != 1)
            {
            expBar2.fillAmount = Mathf.Lerp(expBar2.fillAmount, xpFill2, Time.deltaTime * barSpeed);
            }
            
            if (expBar2.fillAmount == 1)
            {
                expBar2.fillAmount = 0;
                EXPBarWin(2);
            }
        }
    }

    private void RunExpBar3()
    {
        if (player3BarRun == 1)
        {
            if (expBar3.fillAmount != 1)
            {
                expBar3.fillAmount = Mathf.Lerp(expBar3.fillAmount, xpFill3, Time.deltaTime * barSpeed);
            }

            if (expBar3.fillAmount == 1)
            {
                expBar3.fillAmount = 0;
                EXPBarWin(3);
            }
        }
    }

    private void RunExpBars()
    {
        RunExpBar1();
        RunExpBar2();
        RunExpBar3();
    }





}
