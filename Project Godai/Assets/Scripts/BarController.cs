using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {
    

    public float xpFill;
    private float barSpeed = 4;
    private float barStart1;
    private float barStart2;
    private float barStart3;

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
    }


    public void EXPBarStart(int character)
    {
        switch (character)
        {
            case 1:
                playerStats = FindObjectOfType<PlayerStats>();
                barStart1 = playerStats.experiencePoints / playerStats.experienceThreshold;
                break;

            case 2:
                playerStats2 = FindObjectOfType<PlayerStats2>();
                barStart2 = playerStats2.experiencePoints / playerStats2.experienceThreshold;
                break;

            case 3:
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
                expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, xpFill, Time.deltaTime * barSpeed);
                break;

            case 2:
                expBar2.fillAmount = barStart2;
                xpFill = playerStats2.experiencePoints / playerStats2.experienceThreshold;
                //Debug.Log("xpfv = " + xpFill);
                expBar2.fillAmount = Mathf.Lerp(expBar2.fillAmount, xpFill, Time.deltaTime * barSpeed);
                break;

            case 3:
                expBar3.fillAmount = barStart3;
                xpFill = playerStats3.experiencePoints / playerStats3.experienceThreshold;
                //Debug.Log("xpfv = " + xpFill);
                expBar3.fillAmount = Mathf.Lerp(expBar3.fillAmount, xpFill, Time.deltaTime * barSpeed);
                break;
        }


    }





}
