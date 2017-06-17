﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownUI : MonoBehaviour {

	public int playerNum;
	public string signType; 
	public Image content;
	public float maxTime; 
	public float currentTime; 
	GameObject player;
	StateCooldowns sc;
	Player p;
	public Color color;
	public Color faded;
	public Color inUse;
	public Color dark;
	public float lerpSpeed;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player_" + playerNum);
		sc = player.GetComponent<StateCooldowns> ();
		p = player.GetComponent<Player> ();

		if (signType == "Rock") 
		{
			color = RPSX.rockColor;
			dark = RPSX.rockColorDark;
			faded = RPSX.rockColorFaded;
		}
		if (signType == "Paper") 
		{
			color = RPSX.paperColor;
			dark = RPSX.paperColorDark;
			faded = RPSX.paperColorFaded;
		}
		if (signType == "Scissors") 
		{
			color = RPSX.scissorsColor;
			dark = RPSX.scissorsColorDark;
			faded = RPSX.scissorsColorFaded;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		inUse = Color.Lerp(color, dark, Mathf.PingPong(Time.time*lerpSpeed, 1));

		maxTime = sc.maxCoolDownTime; 
		if (signType == "Rock") 
		{
			currentTime = sc.currentRockCoolDown;
		}
		if (signType == "Paper") 
		{
			currentTime = sc.currentPaperCoolDown;
		}
		if (signType == "Scissors") 
		{
			currentTime = sc.currentScissorsCoolDown;
		}

		if (signType == p.currentState) 
		{
			content.color = inUse;
		}

		if (currentTime < maxTime) 
		{
			content.color = faded;
		}

		if (currentTime >= maxTime && signType != p.currentState) 
		{
			content.color = color;
		}

		handleFill ();
		
	}

	private float map (float current, float max)
	{
		return current / max;
	}

	void handleFill ()
	{
		content.fillAmount = map (currentTime, maxTime);
	}
}
