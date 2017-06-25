using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : Projectile {

	public bool beingHeld;
	public CircleCollider2D cc;
	public GameObject player;


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
			rb.velocity = new Vector2 (dir.x * XSpeed, dir.y * YSpeed);
		}

	}
}
