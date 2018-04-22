using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats2 : MonoBehaviour, IPlayerStats {

    private int baseStrength = 10;
    private int baseSpeed = 10;
    private int baseEndurance = 10;
    private int baseSpirit = 10;
    public int playerLevel = 1;

    public int currentStrength;
    public int currentSpeed;
    public int currentEndurance;
    public int currentSpirit;

    public int modStrength;
    public int modSpeed;
    public int modEndurance;
    public int modSpirit;

    public float MaxHealth { get; set; }
    public float MaxMP { get; set; }

    public float PhysicalDamage { get; set; }
    public float MagicDamage { get; set; }
    public float EvasionChance { get; set; }

    public float experiencePoints;
    public float experienceThreshold;
    public int statPoints;

    // Use this for initialization
    void Start () {
               
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void PlayerStatsSetup()
    {
        currentStrength = baseStrength + modStrength;
        currentSpeed = baseSpeed + modSpeed;
        currentEndurance = baseEndurance + modEndurance;
        currentSpirit = baseSpirit + modSpirit;
        MaxHealth = currentEndurance * 10;
        MaxMP = currentSpirit * 10;
        PhysicalDamage = currentStrength;
        MagicDamage = currentSpirit * 1.5f;
        EvasionChance = currentSpeed / 2;
    }
}
