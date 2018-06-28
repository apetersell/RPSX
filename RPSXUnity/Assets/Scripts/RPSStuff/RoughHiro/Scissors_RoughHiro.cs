using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors_RoughHiro : State_RoughHiro {

	void Awake ()
	{
		p = GetComponent<Player> ();
		moveSpeed = 16;
		jumpSpeed = 20;
		normalGrav = 6;
		fastFallGrav = 8;
		shieldGrav = 4;
		maxAirActions = 2;
		airSpeedModifier = .75f;
		shieldDiminishRate = 30;
		color = RPSX.scissorsColor;
		airDashSpeed = 40;
		maxDashTime = 10;
		attackDamage = 8;
		attackShieldDamage = 5;
		attackHitStun = 25;
		attackBounceStun = 15;
	}
}
