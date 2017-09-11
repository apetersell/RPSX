using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXGuy : MonoBehaviour {

	public AudioClip newState;
	public AudioClip powerDown;
	AudioSource auds; 

	// Use this for initialization
	void Start () {

		auds = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
	}
}
