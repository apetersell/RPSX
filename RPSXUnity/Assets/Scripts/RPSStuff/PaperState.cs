using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperState : RPSState {

	void Awake () {

		p = GetComponent<Player> ();
		moveSpeed = 3;
		jumpSpeed = 20;
		normalGrav = 3;
		fastFallGrav = 5;
		maxAirActions = 5;
		shieldSize = 1;
		shieldDiminishRate = 20;
		airSpeedModifier = 2.5f;
		color = RPSX.paperColor;


	}

	// Update is called once per frame
	void Update () {

	}

	public override void airAction ()
	{
			p.jump (jumpSpeed * .75f);
	}
}
