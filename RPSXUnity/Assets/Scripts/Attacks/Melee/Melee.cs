using System.Collections;
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

	public virtual void Awake ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

	public virtual void Update ()
	{
		handleColor ();
		avoidCollidingWithSelf ();
		handlePosition ();
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
	{	GameObject player = GameObject.Find ("Player_" + owner); 
		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
		Vector2 bounceAway;
		string result = RPSX.determineWinner (state, p.currentState);
		if (result == "Loss") 
		{
			bounceAway = new Vector2 ((knockBackX * -2), knockBackY * - 2);
			rb.AddForce (bounceAway);  
		} 
		else 
		{
			base.hitShield (p);
			bounceAway = new Vector2 (knockBackX * -1, knockBackY * -1);
			rb.AddForce (bounceAway);  
		}
	}

	public void killAttack () 
	{
		Destroy (this.gameObject);
	}
}
