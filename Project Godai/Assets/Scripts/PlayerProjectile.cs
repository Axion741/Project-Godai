using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public GameObject player;
    private PlayerAbilities playerAbilities;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerCharacter");
        playerAbilities = player.GetComponent<PlayerAbilities>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D impact)
    {
        Debug.Log("Collision");
        playerAbilities.BlastBarrageDamage();
        Destroy(gameObject);
    }
}
