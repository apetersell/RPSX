using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperState : RPSState {

	void Awake () {

		p = GetComponent<Player> ();
		moveSpeed = 4;
		jumpSpeed = 20;
		normalGrav = 3;
		fastFallGrav = 5;
		maxAirActions = 3;
		airSpeedModifier = 2.5f;
		color = Color.blue;


	}

	// Update is called once per frame
	void Update () {

	}

	public override void airAction ()
	{
		if (p.airActionsRemaining >= 3) 
		{
			p.jump (jumpSpeed * .5f);
		}

		if (p.airActionsRemaining == 2) 
		{
			p.jump (jumpSpeed * .75f);
		}

		if (p.airActionsRemaining == 1)
		{
			p.jump (jumpSpeed);
		}


	}
}
