using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStats : MonoBehaviour, IEnemyStats{

    private EnemyAbilities enemyAbilities;

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

    //Resistances (express as a percentage eg. 3.5% resist = 3.5f)
    //Modified by level! Check Level Range to ensure reasonable effects!
    public float PhysicalResist { get; set; }
    public float MagicalResist { get; set; }

    //Nametag control
    private TextMesh characterName;
    private GameObject nametag;

    //Level Determination
    private SpawnController spawnController;
    private string rootName;
    private int minLevel = 3;
    private int maxLevel = 10;
    //This should be the absolute maximum. Random.range excluding max value is already taken into account.


    void Awake()
    {
        spawnController = FindObjectOfType<SpawnController>();
        GenerateStats();
        SetNametag();
        AISetup();
    }

    private void GenerateStats()
    {
        //SetSpeedHere
        Speed = 3;

        DetermineLevel();

        //Debug.Log("enemy level = " + EnemyLevel);
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

        PhysicalResist = 1 * EnemyLevel;
        MagicalResist = 0 * EnemyLevel;


    }

    private void SetNametag()
    {
        nametag = transform.Find("Body/NameText").gameObject;
        characterName = nametag.GetComponent<TextMesh>();

        characterName.text = "Skeleton - Lv." + EnemyLevel;
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

    private void AISetup()
    {
        enemyAbilities = GetComponent<EnemyAbilities>();
        //All values should be between 1 and 100 to cause attack. 
        //Values of 0 will prevent attack from happening.
        //Always build values ascending from top to bottom.
        //Min should = Max of previous attack.
        enemyAbilities.kickMin = 1;
        enemyAbilities.kickMax = 40;
        enemyAbilities.punchMin = 40;
        enemyAbilities.punchMax = 90;
        enemyAbilities.powerUpMin = 0;
        enemyAbilities.powerUpMax = 0;
        enemyAbilities.barrageMin = 0;
        enemyAbilities.barrageMax = 0;
        enemyAbilities.dashMin = 90;
        enemyAbilities.dashMax = 100;
    }


}
