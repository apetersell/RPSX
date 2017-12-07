using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDash_RHiro : Melee
{
	public float knockBackMultiplier;

	// Update is called once per frame
	public override void Update ()
	{
		damage = myPlayer.GetComponent<State_RoughHiro> ().attackDamage;
		hitStun = myPlayer.GetComponent<State_RoughHiro> ().attackHitStun;
		shieldDamage = myPlayer.GetComponent<State_RoughHiro> ().attackShieldDamage;
		knockBackX = myPlayer.GetComponent<State_RoughHiro> ().trajectory.x * knockBackMultiplier;
		bounceStun = myPlayer.GetComponent<State_RoughHiro> ().attackBounceStun;
		if (knockBackX < 0) 
		{
			knockBackX *= -1;
		}
		knockBackY = myPlayer.GetComponent<State_RoughHiro> ().trajectory.y * knockBackMultiplier;
		if (knockBackY < 0) 
		{
			knockBackY *= -1;
		}
		base.Update ();
	}
}
