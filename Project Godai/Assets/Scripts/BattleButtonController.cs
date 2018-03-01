using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtonController : MonoBehaviour {

    public Text nameText;
    public GameObject battleMenuCanvas;
    private GameObject meleeButtonToggle;
    private GameObject magicButtonToggle;
    private GameObject characterNameBox;

    private GameObject player;
    private GameObject player2Spawn;
    private GameObject player3Spawn;

    private PlayerAbilities playerAbilities;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setup()
    {
        GetCharacters();
        battleMenuCanvas = GameObject.Find("BattleMenuCanvas");
        characterNameBox = battleMenuCanvas.transform.Find("CharacterName").gameObject;
        nameText = characterNameBox.GetComponent<Text>();
        meleeButtonToggle = battleMenuCanvas.transform.Find("MenuButtons/MeleeDropdownButton/MeleeButtons").gameObject;
        magicButtonToggle = battleMenuCanvas.transform.Find("MenuButtons/MagicDropdownButton/MagicButtons").gameObject;
        meleeButtonToggle.SetActive(false);
        magicButtonToggle.SetActive(false);
    }

    void GetCharacters()
    {
        player = GameObject.Find("PlayerCharacter");
        player2Spawn = GameObject.Find("PlayerSpawn2");
        player3Spawn = GameObject.Find("PlayerSpawn3");
    }

    public void ToggleMeleeOn()
    {
        meleeButtonToggle.SetActive(true);
        magicButtonToggle.SetActive(false);
    }

    public void ToggleMagicOn()
    {
        meleeButtonToggle.SetActive(false);
        magicButtonToggle.SetActive(true);
    }

    public void SetActiveCharacter(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                playerAbilities = player.GetComponent<PlayerAbilities>();
                nameText.text = "Grey";
                break;

            case 2:
                playerAbilities = player2Spawn.GetComponentInChildren<PlayerAbilities>();
                nameText.text = "Gold";
                break;

            case 3:
                playerAbilities = player3Spawn.GetComponentInChildren<PlayerAbilities>();
                nameText.text = "Blue";
                break;
        }
    }

    public void PunchAttackButton()
    {
        playerAbilities.PunchAttack();
    }

    public void KickAttackButton()
    {
        playerAbilities.KickAttack();
    }

    public void MagicBlastAttackButton()
    {
        playerAbilities.BlastBarrageAttack();
    }

    public void DashBlastAttackButton()
    {
        playerAbilities.BlastDashAttack();
    }

    public void PowerUpButton()
    {
        playerAbilities.PowerUp();
    }
}
