using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsState : RPSState {

	Rigidbody2D rb;
	float airDashSpeed = 45;
	public float maxDashTime = 5;
	public float remainingDashTime;
	public bool airDashing = false;


	void Awake () {

		rb = GetComponent<Rigidbody2D> ();
		p = GetComponent<Player> ();
		moveSpeed = 7; 
		jumpSpeed = 25;
		normalGrav = 8;
		fastFallGrav = 16;
		maxAirActions = 2;
		shieldSize = 1.75f;
		shieldDiminishRate = 11; 
		airSpeedModifier = .75f;
		projectileFireRate = 30;
		color = RPSX.scissorsColor;

		remainingDashTime = maxDashTime;


	}

	// Update is called once per frame
	void Update () {
		airDashHanlde ();


	}

	public override void airAction ()
	{
		airDashing = true;
	}

	void airDashHanlde()
	{
		if (airDashing) 
		{
			p.actionable = false;
			rb.velocity = new Vector2 (airDashSpeed * p.directionModifier, 0); 
			rb.gravityScale = 0;
			rb.mass = 0;
			remainingDashTime--;
		}

		if (remainingDashTime <= 0) 
		{
			airDashing = false;
			remainingDashTime = maxDashTime;
			rb.gravityScale = normalGrav;
			rb.mass = 1;
			p.actionable = true;
		}
	}
		
}

