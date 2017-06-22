using System.Collections;
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
			Destroy (this.gameObject);
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
		if (coll.gameObject.tag == "Projectile") 
		{
			Projectile enemeyProj = coll.gameObject.GetComponent<Projectile> ();
			string result = RPSX.determineWinner (state, enemeyProj.state);
			{
				if (result == "Win") {
					Destroy (coll.gameObject);
				} else if (result == "Loss") {
					Destroy (this.gameObject);
				} else {
					Destroy (this.gameObject);
					Destroy (coll.gameObject);
				}
			}
		}
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
			Destroy (this.gameObject);
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
		Destroy (this.gameObject);
	}
}
