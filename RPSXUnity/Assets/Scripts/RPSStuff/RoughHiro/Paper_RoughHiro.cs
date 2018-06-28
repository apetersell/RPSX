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
		maxAirActions = 1;
		airSpeedModifier = .5f;
		shieldDiminishRate = 10;
		color = RPSX.paperColor;
		airDashSpeed = 15;
		maxDashTime = 30;
		attackDamage = 2;
		attackShieldDamage = 2;
		attackHitStun = 15;
		attackBounceStun = 15;
	}
		
	public override void handleDash ()
	{
		GetComponent<Animator> ().SetBool ("AirDashing", airDashing);
		if (airDashing) 
		{
			p.actionable = false;
			float modX = (Input.GetAxis ("LeftStickX_P" + p.playerNum));
			float modY = (Input.GetAxis ("LeftStickY_P" + p.playerNum)) * -1;
			rb.velocity = new Vector2 (modX * airDashSpeed, modY * airDashSpeed); 
			float angle = Mathf.Atan2 (modY * p.directionModifier, modX * p.directionModifier) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			rb.gravityScale = 0;
			rb.mass = 0;
			remainingDashTime--;
		}
		if (remainingDashTime <= 0) 
		{
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
