using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElementalStats : MonoBehaviour, IEnemyStats{

    private int strength = 3;
    public int Speed { get; set; }
    private int endurance = 3;
    private int spirit = 15;


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
        Speed = 6;


        EnemyLevel = Random.Range(5, 15);
        //Debug.Log("enemy level = " + enemyLevel);
        MaxHealth = (endurance + (EnemyLevel/2)) * 10;    //ReducedHPScaling for this enemy
        //Debug.Log("enemy HP = " + maxHealth);
        MaxMP = (spirit + EnemyLevel) * 10;
        //Debug.Log("enemy MP = " + maxMP);
        PhysicalDamage = strength;                        //NoPhyDmgScaling for this enemy
        //Debug.Log("enemy DMG = " + physicalDamage);
        MagicDamage = (spirit + EnemyLevel) * 2f;         //IncreasedMgDmgScaling for this enemy
        //Debug.Log("enemy mDMG = " + magicDamage);
        EvasionChance = (Speed + EnemyLevel) / 2;
        //Debug.Log("enemy EVA = " + evasionChance);
        ExperienceValue = EnemyLevel * 100;
    }

    private void SetNametag()
    {
        nametag = transform.Find("Body/NameText").gameObject;
        characterName = nametag.GetComponent<TextMesh>();

        characterName.text = "Fire Elemental - Lv." + EnemyLevel;
    }
}
