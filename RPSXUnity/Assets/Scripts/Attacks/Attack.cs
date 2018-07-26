using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour 
{

	public RPS_State state; //Rock, paper, scissors, or basic.
	public Character owner; //The player that performed the attack.
	public float damage; //How much damage the attack does to players.
	public float baseKnockback; //How much knockback the damage does.
	public Vector3 knockbackAngle; //At what angle does the attack send the player.
	public List<Character> playersHit = new List<Character>();
	public float directionMod;
	public float KBIFactorX; 
	public float KBIFactorY;

//	public void avoidCollidingWithSelf ()
//	{
//		if (owner == 1) 
//		{
//			myPlayer = GameObject.Find (RPSX.Player1Name); 
//		}
//		if (owner == 2) 
//		{
//			myPlayer = GameObject.Find (RPSX.Player2Name); 
//		}
//		Collider2D[] playerColliders = myPlayer.GetComponentsInChildren<Collider2D> ();
//		for (int i = 0; i < playerColliders.Length; i++) 
//		{
//			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), playerColliders [i]);
//		}
//	}

	// Makes sure the attack is colored correctly based on it's state.
//	public virtual void handleColor ()
//	{
//		if (state == "Basic") 
//		{
//			stateColor = RPSX.basicColor;
//		}
//
//		if (state == "Rock") 
//		{
//			stateColor = RPSX.rockColor;
//		}
//
//		if (state == "Paper") 
//		{
//			stateColor = RPSX.paperColor;
//		}
//
//		if (state == "Scissors") 
//		{
//			stateColor = RPSX.scissorsColor;
//		}
//		sr.color = stateColor;
//	}
//
	//Handles Collisions with other objects.
	public virtual void OnTriggerEnter2D (Collider2D coll)
	{
		//Handles collisions with players.
		if (coll.gameObject.tag == "Player") 
		{
			Character playerHit = coll.gameObject.GetComponent<Character> ();
			if (playerHit != owner && !playersHit.Contains(playerHit))  
			{
				hitPlayer (playerHit);
				playersHit.Add (playerHit);
			}
		}
//		//Handles collisions with shields.
//		if (coll.gameObject.tag == "Shield")
//		{
//			Shield s = coll.gameObject.GetComponent<Shield>();
//			Player p = s.p;
//			if (p.playerNum != owner)
//			{
//				hitShield (p);
//			}
//		}
	}
//
	public virtual void hitPlayer (Character c)
	{
		float effectiveDamage = 0;
		float effectiveKB = baseKnockback - c.weight;
		Vector3 effectiveKBA = Vector3.zero;
		RPS_Result result = RPSX.determineWinner (state, c.currentState);
		switch (result) 
		{
		case RPS_Result.Tie:
			effectiveKB = baseKnockback - c.weight;
			effectiveDamage = damage;
			break;
		case RPS_Result.Win:
			effectiveKB = (baseKnockback * 2) - c.weight;
			effectiveDamage = damage * 2;
			break;
		case RPS_Result.Loss:
			effectiveKB = (baseKnockback/2) - c.weight;
			effectiveDamage = damage / 2;
			break;
		}
		effectiveKBA = new Vector3 ((knockbackAngle.x * directionMod) + KBIFactorX, knockbackAngle.y + KBIFactorY, knockbackAngle.z);
		Vector3 finalKB = effectiveKBA * effectiveKB;
		RPSXManager.takeDamage (c.playerNum, effectiveDamage);
		c.takeHit (finalKB, effectiveKB);
	}
//
//	public virtual void hitShield (Player p)
//	{
//		p.takeShieldDamage (damage, state);
//	}
//
//	public virtual void hitProjectile (GameObject enemyProj)
//	{
//		string result = RPSX.determineWinner (state, enemyProj.GetComponent<Projectile> ().state);
//		if (result == "Win") 
//		{
//			Destroy (enemyProj.gameObject);
//		}
//	}
//		
//	public virtual void handleSingleHits ()
//	{
//		if (multiHit == false) 
//		{
//			if (hitOpponent.Count > 0) 
//			{
//				foreach (Player p in hitOpponent) 
//				{
//					GameObject player = p.gameObject;
//					Physics2D.IgnoreCollision (GetComponent<Collider2D> (), p.GetComponent<Collider2D> ());
//				}
//			}
//		}
//	}	
}
