using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper_RoughHiro : State_RoughHiro 
{
	void Awake ()
	{
		p = GetComponent<Player> ();
		moveSpeed = 6;
		jumpSpeed = 30;
		normalGrav = 4;
		fastFallGrav = 9;
		shieldGrav = .5f;
		maxAirActions = 3;
		airSpeedModifier = .5f;
		shieldDiminishRate = 10;
		color = RPSX.paperColor;
		airDashSpeed = 15;
		maxDashTime = 15;
		attackDamage = 2;
		attackShieldDamage = 2;
		attackHitStun = 15;
		attackBounceStun = 15;
	}

	public override void airAction ()
	{
		float modX = (Input.GetAxis ("LeftStickX_P" + p.playerNum));
		float modY = (Input.GetAxis ("LeftStickY_P" + p.playerNum)) * -1;
		if (modX == 0 && modY == 0) 
		{
			modX = p.directionModifier;
		}
		trajectory = new Vector2 (modX, modY).normalized;
		if (Mathf.Sign (trajectory.x) != Mathf.Sign (p.directionModifier)) 
		{
			if (Mathf.Sign (trajectory.x) < 0) 
			{
				p.flipCharacter (-1);
			}
			if (Mathf.Sign (trajectory.x) > 0) 
			{
				p.flipCharacter (1);
			}
		}
		airDashing = true;
	}
}
