using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : Attack 
{
	public float XSpeed; // How fast the projectile moves horizontally.
	public float YSpeed; // How fast the projectiel moves vertically.
	public Vector2 dir;  // What direction does it move in.
	public float maxLifeSpan; // The maximum amount of time the projectile will last on screen (in frames).
	public float currentLifeSpan; // How much time left the projectile has until it dies (in frames).
	public bool reflected; // Determines if the projectile has been reflected or not.
	public Vector3 modPos; // Where it appears in relation to the player who fired it.
	public Rigidbody2D rb;

//	//Kills the projectile if it is on screen for too long.
//	public void handleDuration ()
//	{
//		currentLifeSpan--;
//		if (currentLifeSpan <= 0) 
//		{
//			killProjectile ();
//		}
//	}
//
//	//Makes sure the projectile moves.
//	public abstract void handleMovement ();
//
//	//Resets the projectile's lifespan back to max.
//	public void resetProjectile ()
//	{
//		currentLifeSpan = maxLifeSpan;
//	}
//
//	//Makes sure we have ths ame collision interactions as other attacks.
//	public override void OnCollisionEnter2D (Collision2D coll)
//	{
//		if (coll.gameObject.tag == "Projectile") 
//		{
//			Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
//		}
//		base.OnCollisionEnter2D (coll);
//	}
//
//	// If the projectile hits an enemy shield, and the enemy shild beats it in RPS, the projectile will be reflected.
//	public override void hitShield (Player p)
//	{
//		string result = RPSX.determineWinner (state, p.currentState);
//		if (result == "Loss") 
//		{
//			reflectProjectile (owner);
//			GameObject.Find ("SoundGuy").GetComponent<SFXGuy> ().playSFX ("winShield");
//		} 
//		else 
//		{
//			base.hitShield (p);
//			killProjectile ();
//		}
//	}
//
//	public override void handleColor ()
//	{
//		if (reflected) {
//			stateColor = RPSX.inBounceStun;
//		} else {
//			if (state == "Basic") {
//				stateColor = RPSX.basicColor;
//			}
//
//			if (state == "Rock") {
//				stateColor = RPSX.rockColor;
//			}
//
//			if (state == "Paper") {
//				stateColor = RPSX.paperColor;
//			}
//
//			if (state == "Scissors") {
//				stateColor = RPSX.scissorsColor;
//			}
//		}
//		sr.color = stateColor;
//	}
//	// Handles reflection properties.
//	public virtual void reflectProjectile (int sentOwner)
//	{
//		reflected = true; //Tells the projectile that it has been reflected.
//		owner = RPSX.opponentNum(owner); // Changes the owner to the opponent.
//		resetProjectile (); // Resets the projectiles lifespan.
//	}
//
//	// Hanldes what happens when a projectile is killed.
//	void killProjectile ()
//	{
//		if (reflected) //If the projectile has already been reflected, we just straight up destroy it.
//		{
//			Destroy (this.gameObject);
//			ProjectilePool.clearPool (state);
//		} 
//		else //Otherwise, we add it to a pool so that we're not constantly destroying and remaking projectiles.
//		{
//			ProjectilePool.addToPool (this.gameObject, state);
//			GameObject player = GameObject.Find ("Player_" + owner); 
//		}
//	}
//
//	//Hanldes the colliions interaction between players and projectiles (same as in Attack Script).
//	public override void hitPlayer (Player p)
//	{
//		killProjectile ();
//		base.hitPlayer (p);
//	}
}
