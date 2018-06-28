using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeam : Projectile {


//	void Awake () {
//
//		resetProjectile ();
//
//	}
//	// Use this for initialization
//	void Start () {
//
//		sr = GetComponent<SpriteRenderer> ();
//		rb = GetComponent<Rigidbody2D> ();
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		Vector3 moveDirection = new Vector3 (dir.x, dir.y, 0); 
//		if (moveDirection != Vector3.zero) 
//		{
//			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
//			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//		}
//
//		handleColor ();
//		handleMovement ();
//		handleDuration ();
//		handleSingleHits ();
//		avoidCollidingWithSelf ();
//	}
//
//	public override void OnCollisionEnter2D (Collision2D coll)
//	{
//		base.OnCollisionEnter2D (coll);
//	}
//	//Makes sure the projectile moves.
//	public override void handleMovement ()
//	{
//		rb.velocity = new Vector2 (dir.x * XSpeed, dir.y * YSpeed);
//	}
//
//	public override void reflectProjectile (int sentOwner)
//	{
//		XSpeed = XSpeed * -2; // Doubles it's speed.
//		YSpeed = YSpeed * -2;
//		if (sr.flipX == true) //Changes the direction it is facing.
//		{
//			sr.flipX = false;
//		} 
//		else 
//		{
//			sr.flipX = true;
//		}
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
//			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), playerColliders [i], false);
//		}
//		base.reflectProjectile (owner);
//	}
}
