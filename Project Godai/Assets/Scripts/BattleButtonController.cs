using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButtonController : MonoBehaviour {

    public GameObject battleMenuCanvas;
    private GameObject meleeButtonToggle;
    private GameObject magicButtonToggle;

	// Use this for initialization
	void Start () {
        Setup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Setup()
    {
        battleMenuCanvas = GameObject.Find("BattleMenuCanvas");
        meleeButtonToggle = battleMenuCanvas.transform.Find("MenuButtons/MeleeDropdownButton/MeleeButtons").gameObject;
        magicButtonToggle = battleMenuCanvas.transform.Find("MenuButtons/MagicDropdownButton/MagicButtons").gameObject;
        meleeButtonToggle.SetActive(false);
        magicButtonToggle.SetActive(false);
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
}
