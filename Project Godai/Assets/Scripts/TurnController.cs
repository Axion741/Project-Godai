using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour {

    public static TurnController instance;
    public static bool playerTurn;
    public static GameObject ControlBlocker;
    public static GameObject Enemy;


    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        playerTurn = true;
        ControlBlocker = GameObject.Find("Control Blocker");
        Enemy = GameObject.Find("EnemySpawn1");
        UIController();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public static void TurnChange()
    {
        if (playerTurn == true)
        {
            playerTurn = false;
            print("TCnowFalse");
            UIController();
            EnemyAttackTrigger();
            
        }
        else if(playerTurn == false)
        {
            playerTurn = true;
            print("TCnowTrue");
            UIController();
        }
    }

    public static void UIController()
    {
        if (playerTurn == true)
        {
            print("PlayerTurn");
            //Delay here
            //yield return new WaitForSeconds(2);
            ControlBlocker.SetActive(false);
        }
        else if (playerTurn == false)
        {
            print("EnemyTurn");
            ControlBlocker.SetActive(true);
        }
    }

    public static void EnemyAttackTrigger()
    {
        Enemy.GetComponentInChildren<EnemyAbilities>().EnemyAttackController();
    }

    public static void QuickHide()
    {
        ControlBlocker.SetActive(true);
    }
}
