using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : Projectile {

	public bool beingHeld;
	public CircleCollider2D cc;
	public GameObject player;
	public float maxDamage;


	void Awake () {

		resetProjectile ();
	}
	// Use this for initialization
	void Start () {

		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		cc = GetComponent <CircleCollider2D> ();

	}

	// Update is called once per frame
	void Update () {
		damage = (rb.velocity.x + rb.velocity.y) / 2; 
		if (damage < 0) 
		{
			damage = damage * -1;
		}

		if (damage > maxDamage) 
		{
			damage = maxDamage;
		}
		player = GameObject.Find ("Player_" + owner);
		handleColor ();
		handleDuration ();
		handleMovement ();
	}

	public override void OnCollisionEnter2D (Collision2D coll)
	{
		base.OnCollisionEnter2D (coll);
	}

	public override void handleMovement()
	{
		if (beingHeld) 
		{
			transform.position = new Vector2 (player.transform.position.x, (player.transform.position.y + modPos.y));
			cc.enabled = false;
		} 
		else 
		{
			cc.enabled = true;
		}

	}
}
