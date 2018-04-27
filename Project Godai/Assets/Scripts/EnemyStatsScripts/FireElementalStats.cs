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

    //Level Determination
    private SpawnController spawnController;
    private string rootName;
    private int minLevel = 5;
    private int maxLevel = 15; //This should be the absolute maximum. Random.range excluding max value is already taken into account.


    void Awake()
    {
        spawnController = FindObjectOfType<SpawnController>();
        GenerateStats();
        SetNametag();
    }

    private void GenerateStats()
    {

        //SetSpeedHere
        Speed = 6;

        DetermineLevel();

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

    //Determine Level based on spawn order. If level defined as 0, randomize.
    private void DetermineLevel()
    {
        rootName = transform.root.gameObject.name;

        switch (rootName)
        {
            case "EnemySpawn1":
                if (spawnController.enemylvl1 <= 0)
                {
                    EnemyLevel = Random.Range(minLevel, maxLevel + 1);
                }
                else EnemyLevel = spawnController.enemylvl1;
                break;

            case "EnemySpawn2":
                if (spawnController.enemylvl2 <= 0)
                {
                    EnemyLevel = Random.Range(minLevel, maxLevel + 1);
                }
                else EnemyLevel = spawnController.enemylvl2;
                break;

            case "EnemySpawn3":
                if (spawnController.enemylvl3 <= 0)
                {
                    EnemyLevel = Random.Range(minLevel, maxLevel + 1);
                }
                else EnemyLevel = spawnController.enemylvl3;
                break;
        }
    }
}
