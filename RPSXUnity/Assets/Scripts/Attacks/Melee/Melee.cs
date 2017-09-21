using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Attack {

	public float knockBackX;
	public float knockBackY; 
	public float hitStun; 
	public Vector2 modPos;


	public override void hitPlayer (Player p)
	{
		base.hitPlayer (damage, state, hitStun);
		Vector2 knockBackDir = new Vector2 (knockBackX, knockBackY);
		Rigidbody2D rb = p.gameObject.GetComponent<Rigidbody2D> ();
		rb.AddForce (knockBackDir);
	}

	public void killAttack () 
	{
		Destroy (this.gameObject);
	}
}
