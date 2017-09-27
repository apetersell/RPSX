﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Attack {

	public float knockBackX;
	public float knockBackY; 
	public float reflectKnockBackX;
	public float reflectKnockBackY;
	public float duration;
	public Player player;
	public Vector3 modPos;
	public bool grounded;
	public bool multiHit;
	Player hitOpponent;
	int reflectKBmodifier;

	public virtual void Awake ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

	public virtual void Update ()
	{
		handleColor ();
		avoidCollidingWithSelf ();
		handlePosition ();
		handleSingleHits ();
		reflectKBmodifier = player.directionModifier * -1;
	}

	public virtual void handlePosition ()
	{
		transform.position = player.transform.position + modPos;
	}

	public override void hitPlayer (Player p)
	{
		base.hitPlayer (p);
		Vector2 knockBackDir = new Vector2 (knockBackX, knockBackY);
		Rigidbody2D rb = p.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = Vector3.zero;
		rb.AddForce (knockBackDir);
	}

	public override void hitShield (Player p)
	{	
		GameObject player = GameObject.Find ("Player_" + owner); 
		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
		Vector2 bounceAway;
		string result = RPSX.determineWinner (state, p.currentState);
		if (result == "Loss") 
		{
			bounceAway = new Vector2 (reflectKnockBackX * 2 * reflectKBmodifier, reflectKnockBackY * 2);
			rb.velocity = Vector3.zero; 
			rb.AddForce (bounceAway);   
		} 
		else 
		{
			base.hitShield (p);
			bounceAway = new Vector2 (reflectKnockBackX * reflectKBmodifier, reflectKnockBackY);
			rb.velocity = Vector3.zero;
			rb.AddForce (bounceAway);  
		}
		Rigidbody2D rbs = GameObject.Find ("Shield_P" + RPSX.opponentNum (owner)).GetComponent<Rigidbody2D> ();
		rbs.velocity = Vector3.zero;
	}

	public void killAttack () 
	{
		Destroy (this.gameObject);
	}

	public virtual void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			Player playerHit = coll.gameObject.GetComponent<Player> ();
			if (playerHit.playerNum != owner) 
			{
				hitPlayer (playerHit);
				hitOpponent = playerHit;
			}
		}
		if (coll.gameObject.tag == "Shield") 
		{
			Shield s = coll.gameObject.GetComponent<Shield> ();
			Player p = GameObject.Find ("Player_" + s.owner).GetComponent<Player>(); 
			if (s.owner != owner) 
			{
				hitShield (p);
				Debug.Log (this.gameObject.name + " hit " + s.gameObject.name);
			}
		}
	}

	void handleSingleHits ()
	{
		if (multiHit == false && hitOpponent != null) 
		{
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), hitOpponent.gameObject.GetComponent<Collider2D>());
		}
	}
}
