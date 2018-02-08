using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {
    

    public float xpFill;
    private float barSpeed = 4;





    public Image expBar;





    private PlayerStats playerStats;



    // Use this for initialization
    void Start () {

        playerStats = FindObjectOfType<PlayerStats>();

	}
	
	// Update is called once per frame
	void Update () {
        EXPBarWin();
        Debug.Log("AbExp = " + playerStats.experiencePoints);;
        Debug.Log("AbThresh = " + playerStats.experienceThreshold);
    }


   

    public void EXPBarWin()
    {
        xpFill = playerStats.experiencePoints / playerStats.experienceThreshold;
        Debug.Log("xpfv = " + xpFill);
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, xpFill, Time.deltaTime * barSpeed);
    }





}
