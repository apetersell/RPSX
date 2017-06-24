﻿using System.Collections;
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
		Vector3 moveDirection = new Vector3 (dir.x, dir.y, 0); 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		handleColor ();
		handleMovement ();
		handleDuration ();
	}

	public override void OnCollisionEnter2D (Collision2D coll)
	{
		base.OnCollisionEnter2D (coll);
	}
}
