using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockState : RPSState {

	Rigidbody2D rb;
	public int maxHangTime = 60;
	public int hangTimeRemaining;
	public bool isHanging;


	void Awake () {

		rb = GetComponent<Rigidbody2D> ();
		p = GetComponent<Player> ();
		hangTimeRemaining = maxHangTime;
		moveSpeed = 12; 
		jumpSpeed = 25;
		normalGrav = 10;
		fastFallGrav = 20;
		maxAirActions = 1;
		airSpeedModifier = .5f;
		shieldDiminishRate = 5.5f;
		shieldSize = 1.25f;
		color = RPSX.rockColor;


	}

	// Update is called once per frame
	void Update () {

		hangHandler ();
		
	}

	public override void airAction ()
	{
		//Rock Air Action is an Air Hang
		rb.velocity = Vector2.zero;
		isHanging = true;
	}

	void hangHandler ()
	{
		if (isHanging) {
			p.affectedByGrav = false;
			rb.gravityScale = 0;
			rb.mass = 0;
			hangTimeRemaining--;
			moveSpeed = 6f;
		} 
		else 
		{
			rb.mass = 1;
		}

		if (hangTimeRemaining == 0) 
		{
			hangTimeRemaining = maxHangTime;
			isHanging = false;
			moveSpeed = 6;
			p.affectedByGrav = true;
		}

		if (Input.GetButtonUp ("AButton_P" + p.playerNum)) 
		{
			hangTimeRemaining = maxHangTime;
			isHanging = false;
			moveSpeed = 12;
			p.affectedByGrav = true;
		}
	}
}
