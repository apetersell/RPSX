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
		moveSpeed = 3; 
		jumpSpeed = 25;
		normalGrav = 8;
		fastFallGrav = 20;
		maxAirActions = 1;
		airSpeedModifier = 1.75f;
		color = Color.green;


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
		} 
		else 
		{
			rb.mass = 1;
		}

		if (hangTimeRemaining == 0) 
		{
			hangTimeRemaining = maxHangTime;
			isHanging = false;
			p.affectedByGrav = true;
		}
	}
}
