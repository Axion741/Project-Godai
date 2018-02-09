using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetToggler : MonoBehaviour {

    private BattleController battleController;
    private GameObject targetRect;
    private string targetName;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame

    public void TargetTogglerSetup()
    {
        targetName = transform.root.gameObject.name;
        targetRect = transform.Find("TargetRect").gameObject;
        battleController = FindObjectOfType<BattleController>();
    }

    void OnMouseDown()
    {
        TriggerTargetChange();
    }

    void TriggerTargetChange()
    {
        battleController.TargetSwapper(targetName);
    }

    public void ToggleOn()
    {
        targetRect.SetActive(true);
    }

    public void ToggleOff()
    {
        targetRect.SetActive(false);
    }
}
