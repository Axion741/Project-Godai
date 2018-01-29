using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStats : MonoBehaviour {


    public int enemyLevel;
    private int strength = 5;
    private int speed = 5;
    private int endurance = 5;
    private int spirit = 5;


    public float maxHealth;
    public float maxMP;

    public float physicalDamage;
    public float magicDamage;
    public float evasionChance;

    public float experienceValue;
    

    // Use this for initialization
    void Start () {
        GenerateStats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GenerateStats()
    {
        enemyLevel = Random.Range(1, 6);
        //Debug.Log("enemy level = " + enemyLevel);
        maxHealth = (endurance + enemyLevel) * 10;
        //Debug.Log("enemy HP = " + maxHealth);
        maxMP = (spirit + enemyLevel) * 10;
        //Debug.Log("enemy MP = " + maxMP);
        physicalDamage = strength + enemyLevel;
        //Debug.Log("enemy DMG = " + physicalDamage);
        magicDamage = (spirit + enemyLevel) * 1.5f;
        //Debug.Log("enemy mDMG = " + magicDamage);
        evasionChance = (speed + enemyLevel) / 2;
        //Debug.Log("enemy EVA = " + evasionChance);
    }
}
