using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStats : MonoBehaviour, IEnemyStats{

    private EnemyAbilities enemyAbilities;

    private int strength = 1;
    public int Speed { get; set; }
    private int endurance = 10;
    private int spirit = 20;

    public int EnemyLevel { get; set; }
    public float MaxHealth { get; set; }
    public float MaxMP { get; set; }
    public float PhysicalDamage { get; set; }
    public float MagicDamage { get; set; }
    public float EvasionChance { get; set; }
    public float ExperienceValue { get; set; }

    //Resistances (set in generateStats)
    //Modified by level! Check Level Range to ensure reasonable effects!
    public float PhysicalResist { get; set; }
    public float MagicalResist { get; set; }


    //Nametag control
    private TextMesh characterName;
    private GameObject nametag;

    //Level Determination
    private SpawnController spawnController;
    private string rootName;
    private int minLevel = 10;
    private int maxLevel = 20; 
    //This should be the absolute maximum. Random.range excluding max value is already taken into account.


    void Awake()
    {
        enemyAbilities = GetComponent<EnemyAbilities>();
        spawnController = FindObjectOfType<SpawnController>();
        GenerateStats();
        SetNametag();
        AISetup();
    }

    private void GenerateStats()
    {

        //SetSpeedHere
        Speed = 1;

        DetermineLevel();

        //Debug.Log("enemy level = " + enemyLevel);
        MaxHealth = (endurance + EnemyLevel) * 10;
        //Debug.Log("enemy HP = " + maxHealth);
        MaxMP = (spirit + EnemyLevel) * 10;
        //Debug.Log("enemy MP = " + maxMP);
        PhysicalDamage = strength + EnemyLevel;
        //Debug.Log("enemy DMG = " + physicalDamage);
        MagicDamage = (spirit + EnemyLevel) * 1.5f;
        //Debug.Log("enemy mDMG = " + magicDamage);
        EvasionChance = (Speed + EnemyLevel) / 2;
        //Debug.Log("enemy EVA = " + evasionChance);
        ExperienceValue = EnemyLevel * 100;

        //SET RESISTANCES HERE
        //(express as a percentage eg. 3.5 % resist = 3.5f)
        PhysicalResist = 100f * EnemyLevel;
        MagicalResist = 0f * EnemyLevel;



    }

    private void SetNametag()
    {
        nametag = transform.Find("Body/NameText").gameObject;
        characterName = nametag.GetComponent<TextMesh>();

        characterName.text = "Ghost - Lv." + EnemyLevel;
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
                    EnemyLevel = Random.Range(minLevel, maxLevel+1);
                }
                else EnemyLevel = spawnController.enemylvl1;
                break;

            case "EnemySpawn2":
                if (spawnController.enemylvl2 <= 0)
                {
                    EnemyLevel = Random.Range(minLevel, maxLevel+1);
                }
                else EnemyLevel = spawnController.enemylvl2;
                break;

            case "EnemySpawn3":
                if (spawnController.enemylvl3 <= 0)
                {
                    EnemyLevel = Random.Range(minLevel, maxLevel+1);
                }
                else EnemyLevel = spawnController.enemylvl3;
                break;
        }
    }

    private void AISetup()
    {

        //All values should be between 1 and 100 to cause attack. 
        //Values of 0 will prevent attack from happening.
        //Always build values ascending from top to bottom.
        //Min should = Max of previous attack.
        enemyAbilities.kickMin = 0;
        enemyAbilities.kickMax = 0;
        enemyAbilities.punchMin = 0;
        enemyAbilities.punchMax = 0;
        enemyAbilities.powerUpMin = 0;
        enemyAbilities.powerUpMax = 20;
        enemyAbilities.barrageMin = 20;
        enemyAbilities.barrageMax = 80;
        enemyAbilities.dashMin = 80;
        enemyAbilities.dashMax = 100;
    }


}
