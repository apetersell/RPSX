using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicState : RPSState {


	void Awake () {

		p = GetComponent<Player> ();
		moveSpeed = 5;
		jumpSpeed = 20;
		normalGrav = 6;
		fastFallGrav = 12;
		maxAirActions = 1;
		airSpeedModifier = 1.5f;
		color = Color.white;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void airAction ()
	{
		p.jump (jumpSpeed * .75f);
		Debug.Log ("Basic State Air Action is a Weak Double Jump");

	}
}
