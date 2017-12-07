using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_RoughHiro : State_RoughHiro
{
	void Awake ()
	{
		p = GetComponent<Player> ();
		moveSpeed = 12;
		jumpSpeed = 20;
		normalGrav = 6;
		fastFallGrav = 8;
		shieldGrav = 1.5f;
		maxAirActions = 1;
		airSpeedModifier = .65f;
		shieldDiminishRate = 10;
		color = RPSX.basicColor;
		airDashSpeed = 25;
		maxDashTime = 12;
		attackDamage = 5;
		attackShieldDamage = 3;
		attackHitStun = 15;
		attackBounceStun = 15;
	}
}
