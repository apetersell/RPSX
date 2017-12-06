using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {

	public string state; //Rock, paper, scissors, or basic.
	public int owner; //The player that performed the attack.
	public float damage; //How much damag the attack does to players.
	public float shieldDamage; //How much damage the attack does to shields.
	public float hitStun; //How long (in frames) the other player is stunned after getting hit by the attack.
	public GameObject myPlayer;
	public Color stateColor;  //The color of the attack (changes based on state).
	public SpriteRenderer sr;
	public bool multiHit;
	public List<Player> hitOpponent = new List<Player> (); 

	public void avoidCollidingWithSelf ()
	{
		if (owner == 1) 
		{
			myPlayer = GameObject.Find (RPSX.Player1Name); 
		}
		if (owner == 2) 
		{
			myPlayer = GameObject.Find (RPSX.Player2Name); 
		}
		Collider2D[] playerColliders = myPlayer.GetComponentsInChildren<Collider2D> ();
		for (int i = 0; i < playerColliders.Length; i++) 
		{
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), playerColliders [i]);
		}
	}

	// Makes sure the attack is colored correctly based on it's state.
	public virtual void handleColor ()
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
			Player playerHit = coll.gameObject.GetComponentInParent<Player> ();
			if (playerHit.playerNum != owner && !hitOpponent.Contains(playerHit)) 
			{
				hitPlayer (playerHit);
				hitOpponent.Add (playerHit);
			}
		}
		//Handles collisions with shields.
		if (coll.gameObject.tag == "Shield")
		{
			Shield s = coll.gameObject.GetComponent<Shield>();
			Player p = s.p;
			if (p.playerNum != owner)
			{
				hitShield (p);
			}
		}
	}

	public virtual void hitPlayer (Player p)
	{
		p.takeDamage (damage, state, hitStun, this.name);
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
		
	public virtual void handleSingleHits ()
	{
		if (multiHit == false) 
		{
			if (hitOpponent.Count > 0) 
			{
				foreach (Player p in hitOpponent) 
				{
					GameObject player = p.gameObject;
					Physics2D.IgnoreCollision (GetComponent<Collider2D> (), p.GetComponent<Collider2D> ());
				}
			}
		}
	}	




}
