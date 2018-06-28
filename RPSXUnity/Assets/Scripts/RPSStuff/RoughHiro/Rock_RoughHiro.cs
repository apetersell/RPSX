using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_RoughHiro : State_RoughHiro 
{
	void Awake ()
	{
		p = GetComponent<Player> ();
		moveSpeed = 10;
		jumpSpeed = 30;
		normalGrav = 10;
		fastFallGrav = 12;
		shieldGrav = .5f;
		maxAirActions = 2;
		airSpeedModifier = 1.25f;
		shieldDiminishRate = 5;
		color = RPSX.rockColor;
		airDashSpeed = 20;
		maxDashTime = 15;
		attackDamage = 12;
		attackShieldDamage = 12;
		attackHitStun = 15;
		attackBounceStun = 15;
	}

	public override void handleDash ()
	{
		GetComponent<Animator> ().SetBool ("AirDashing", airDashing);
		if (airDashing) 
		{
			p.passThroughPlatforms = true;
			if (p.airActionsRemaining == 1) {
				p.actionable = false;
				float modX = .5f * p.directionModifier;
				float modY = .8f;
				rb.velocity = new Vector2 (modX * airDashSpeed, modY * airDashSpeed); 
				float angle = Mathf.Atan2 (modY * p.directionModifier, modX * p.directionModifier) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
				rb.gravityScale = 0;
				rb.mass = 0;
				attackDamage = 5;
				remainingDashTime--;
			} else 
			{
				p.actionable = false;
				float modX = 0 * p.airActionsRemaining;
				float modY = -1;
				rb.velocity = new Vector2 (modX * (airDashSpeed * 2), modY * (airDashSpeed *2)); 
				float angle = Mathf.Atan2(modY * p.directionModifier, modX * p.directionModifier) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				rb.gravityScale = 0;
				rb.mass = 0;
				attackDamage = 7;
				remainingDashTime--;
			}
		}
			
		if (remainingDashTime <= 0) 
		{
			p.passThroughPlatforms = false;
			GetComponent<AnimationEvents> ().stopMomentum ();
			GetComponent<AnimationEvents> ().airDashCheck = false;
			transform.rotation = Quaternion.identity;
			airDashing = false;
			remainingDashTime = maxDashTime;
			rb.gravityScale = normalGrav;
			rb.mass = 1;
			p.actionable = true;
		}
	}
}
