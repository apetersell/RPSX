using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicState : RPSState {

	private Color lightGreen;
	private Color lightBlue;
	private Color lightRed;




	void Awake () {

		p = GetComponent<Player> ();
		moveSpeed = 7;
		jumpSpeed = 20;
		normalGrav = 6;
		fastFallGrav = 12;
		maxAirActions = 1;
		airSpeedModifier = 1.5f;
		shieldDiminishRate = 10;
		shieldSize = 1;
		color = RPSX.basicColor;


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void airAction ()
	{
		p.jump (jumpSpeed * .75f);
	}
}
