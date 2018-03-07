﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStats : MonoBehaviour, IEnemyStats{

    private int strength = 7;
    public int Speed { get; set; }
    private int endurance = 10;
    private int spirit = 1;


    public int EnemyLevel { get; set; }
    public float MaxHealth { get; set; }
    public float MaxMP { get; set; }
    public float PhysicalDamage { get; set; }
    public float MagicDamage { get; set; }
    public float EvasionChance { get; set; }
    public float ExperienceValue { get; set; }

    //Nametag control
    private TextMesh characterName;
    private GameObject nametag;


    void Awake()
    {
        GenerateStats();
        SetNametag();
    }

    private void GenerateStats()
    {

        //SetSpeedHere
        Speed = 3;


        EnemyLevel = Random.Range(3, 11);
        Debug.Log("enemy level = " + EnemyLevel);
        MaxHealth = (endurance + EnemyLevel) * 10;
        //Debug.Log("enemy HP = " + maxHealth);
        MaxMP = (spirit + EnemyLevel) * 10;
        //Debug.Log("enemy MP = " + maxMP);
        PhysicalDamage = strength + EnemyLevel;
        //Debug.Log("enemy DMG = " + physicalDamage);
        MagicDamage = (spirit + EnemyLevel) * 1.5f;
        //Debug.Log("enemy mDMG = " + magicDamage);
        EvasionChance = (Speed + EnemyLevel) / 2;
        //Debug.Log("enemy EVA = " + EvasionChance);
        ExperienceValue = EnemyLevel * 150;
    }

    private void SetNametag()
    {
        nametag = transform.Find("Body/NameText").gameObject;
        characterName = nametag.GetComponent<TextMesh>();

        characterName.text = "Skeleton - Lv." + EnemyLevel;
    }
}
