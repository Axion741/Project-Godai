using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoundController : MonoBehaviour {

    public AudioClip[] attackSounds;

    private AudioSource audioSource;
    private float volume;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        //set volume to saved preference on start
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        volume = PlayerPrefsManager.GetMasterVolume();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FirstPunchSound()
    {
        audioSource.clip = attackSounds[0];
        audioSource.Play();
    }

    public void SecondPunchSound()
    {
        audioSource.clip = attackSounds[1];
        audioSource.Play();
    }

    public void KickSound()
    {
        audioSource.clip = attackSounds[2];
        audioSource.Play();
    }

    public void DashSound()
    {
        //audioSource.clip = attackSounds[3];
        //audioSource.Play();
        AudioSource.PlayClipAtPoint(attackSounds[3], transform.position, volume);
    }

    public void DodgeSound()
    {
        audioSource.clip = attackSounds[4];
        audioSource.Play();
    }

    public void ZapSound()
    {
        AudioSource.PlayClipAtPoint(attackSounds[5], transform.position);
    }

    public void BlastChargeSound()
    {
        audioSource.clip = attackSounds[6];
        audioSource.Play();
    }

    public void BlastFireSound()
    {
        audioSource.clip = attackSounds[7];
        audioSource.Play();
    }

    public void LargeBlastSound()
    {
        audioSource.clip = attackSounds[8];
        audioSource.Play();
    }

    public void PowerUpSound()
    {
        audioSource.clip = attackSounds[9];
        audioSource.Play();
    }

    public void BossPowerUpSound()
    {
        audioSource.clip = attackSounds[10];
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }


}
