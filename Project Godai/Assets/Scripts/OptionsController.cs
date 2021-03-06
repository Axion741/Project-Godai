﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume (volumeSlider.value);
	}

    public void SaveAndExit ()
    {
        PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
        levelManager.LoadStart("01a_Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 1f;
    }
}
