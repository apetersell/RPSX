using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {

	public string state;
	public int owner;
	public float damage;
	public float shieldDamage;
	public Color stateColor; 
	public SpriteRenderer sr;

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

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			Player p = coll.gameObject.GetComponent<Player> ();
			if (p.playerNum != owner) {
				hitPlayer (p);
			} 
			else 
			{
				Physics2D.IgnoreCollision (coll.gameObject.GetComponent<BoxCollider2D> (), GetComponent<BoxCollider2D> ());
			}
		}
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
		




}
