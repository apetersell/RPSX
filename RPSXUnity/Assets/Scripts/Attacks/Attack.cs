using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {

	public string state; //Rock, paper, scissors, or basic.
	public int owner; //The player that performed the attack.
	public float damage; //How much damag the attack does to players.
	public float shieldDamage; //How much damage the attack does to shields.
	public Color stateColor;  //The color of the attack (changes based on state).
	public SpriteRenderer sr;

	// Makes sure the attack is colored correctly based on it's state.
	public void handleColor ()
	{
		if (state == "Basic") 
		{
			stateColor = RPSX.basicColor;
		}

		if (state == "Rock") 
		{
			stateColor = RPSX.rockColor;
		}

		if (state == "Paper") 
		{
			stateColor = RPSX.paperColor;
		}

		if (state == "Scissors") 
		{
			stateColor = RPSX.scissorsColor;
		}
		sr.color = stateColor;
	}

	//Handles Collisions with other objects.
	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
		//Handles collisions with players.
		if (coll.gameObject.tag == "Player") 
		{
			Player p = coll.gameObject.GetComponent<Player> ();
			if (p.playerNum != owner) {
				hitPlayer (p);
			} 
			//Ignores collision if colliding with player who performed that attack (so you can't hit yourself).
			if (p.playerNum == owner) 
			{
				Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			}
		}
		//Handles collisions with shields.
		if (coll.gameObject.tag == "Shield")
		{
			Shield s = coll.gameObject.GetComponent<Shield>();
			Player p = GameObject.Find ("Player_" + s.owner).GetComponent<Player>(); 
			if (p.playerNum != owner)
			{
				hitShield (p);
			}
		}
	}

	public virtual void hitPlayer (Player p)
	{
		p.takeDamage (damage, state);
	}

	public virtual void hitShield (Player p)
	{
		p.takeShieldDamage (damage, state);
	}

	public virtual void hitProjectile (GameObject enemyProj)
	{
		string result = RPSX.determineWinner (state, enemyProj.GetComponent<Projectile> ().state);
		if (result == "Win") 
		{
			Destroy (enemyProj.gameObject);
		}
	}
		




}
