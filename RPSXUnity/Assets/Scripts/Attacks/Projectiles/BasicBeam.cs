using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeam : Projectile {


	void Awake () {

		fired = true;
		resetProjectile ();

	}
	// Use this for initialization
	void Start () {

		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		handleColor ();
		handleMovement ();
		handleDuration ();
	}

	public override void OnCollisionEnter2D (Collision2D coll)
	{
		base.OnCollisionEnter2D (coll);
	}
}
