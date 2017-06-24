﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : Attack 
{
	public bool fired = false;
	public float XSpeed;
	public float YSpeed;
	public Vector2 dir;
	public float maxLifeSpan;
	public float currentLifeSpan;
	public Vector3 modPos;
	public Rigidbody2D rb;

	public void handleDuration ()
	{
		currentLifeSpan--;
		if (currentLifeSpan <= 0) 
		{
			ProjectilePool.addToPool (this.gameObject, state);
		}
	}

	public void handleMovement ()
	{
		rb.velocity = new Vector2 (dir.x * XSpeed, dir.y * YSpeed);
	}

	public void resetProjectile ()
	{
		currentLifeSpan = maxLifeSpan;
	}

	public override void OnCollisionEnter2D (Collision2D coll)
	{
		base.OnCollisionEnter2D (coll);
	}

	public override void hitShield (Player p)
	{
		string result = RPSX.determineWinner (state, p.currentState);
		if (result == "Loss") 
		{
			reflectProjectile (owner);
		} 
		else 
		{
			base.hitShield (p);
			ProjectilePool.addToPool (this.gameObject, state);
		}
	}

	void reflectProjectile (int sentOwner)
	{
		if (sentOwner == 1) 
		{
			owner = 2;
		}

		if (sentOwner == 2) 
		{
			owner = 1;
		}
		resetProjectile ();
		XSpeed = XSpeed * -2;
		YSpeed = YSpeed * -2;
		if (sr.flipX == true) 
		{
			sr.flipX = false;
		} 
		else 
		{
			sr.flipX = true;
		}
	}

	public override void hitPlayer (Player p)
	{
		base.hitPlayer (p);
		ProjectilePool.addToPool (this.gameObject, state);
	}
}
