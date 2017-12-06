using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXGuy : MonoBehaviour {

	public AudioClip newState;
	public AudioClip powerDown;
	public AudioClip smallHit;
	public AudioClip regularHit;
	public AudioClip bigHit;
	public AudioClip lossShield;
	public AudioClip winShield;
	public AudioClip regularShield; 
	public AudioClip shieldBreak;
	public AudioClip rockSound;
	public AudioClip paperSound;
	public AudioClip scissorsSound;
	AudioSource auds; 

	// Use this for initialization
	void Start () {

		auds = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
//			auds.PlayOneShot(winShield);

		}

			
	}

	public void playSFX(string sfx)
	{
		if (sfx == "newState") 
		{
			auds.PlayOneShot (newState);
		}

		if (sfx == "powerDown") 
		{
			auds.PlayOneShot (powerDown);
		}

		if (sfx == "smallHit") 
		{
			auds.PlayOneShot (smallHit);
		}
		if (sfx == "regularHit") 
		{
			auds.PlayOneShot (regularHit);
		}
		if (sfx == "bigHit") 
		{
			auds.PlayOneShot (bigHit);
		}

		if (sfx == "winShield") 
		{
			auds.PlayOneShot (winShield); 
		}

		if (sfx == "lossShield") 
		{
			auds.PlayOneShot (lossShield); 
		}

		if (sfx == "regularShield") 
		{
			auds.PlayOneShot (regularShield); 
		}

		if (sfx == "shieldBreak") 
		{
			auds.PlayOneShot (shieldBreak);
		}

		if (sfx == "rock") 
		{
			auds.PlayOneShot (rockSound); 
		}

		if (sfx == "paper") 
		{
			auds.PlayOneShot (paperSound); 
		}

		if (sfx == "scissors") 
		{
			auds.PlayOneShot (scissorsSound);
		}
	}
}
