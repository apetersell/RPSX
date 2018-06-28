using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : Projectile {

//	public bool beingHeld;
//	public CircleCollider2D circleCollider;
//	public GameObject player;
//	public float maxDamage;
//
//
//	void Awake () {
//
//		resetProjectile ();
//	}
//	// Use this for initialization
//	void Start () {
//
//		sr = GetComponent<SpriteRenderer> ();
//		rb = GetComponent<Rigidbody2D> ();
//		circleCollider = GetComponent <CircleCollider2D> ();
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//		damage = (rb.velocity.x + rb.velocity.y) / 2; 
//		if (damage < 0) 
//		{
//			damage = damage * -1;
//		}
//
//		if (damage > maxDamage) 
//		{
//			damage = maxDamage;
//		}
//		if (owner == 1) 
//		{
//			player = GameObject.Find (RPSX.Player1Name);
//		}
//		if (owner == 2) 
//		{
//			player = GameObject.Find (RPSX.Player2Name);
//		}
//		handleColor ();
//		if (beingHeld == false) 
//		{
//			handleDuration ();
//		}
//		handleMovement ();
//		handleSingleHits ();
//	}
//
//	public override void OnCollisionEnter2D (Collision2D coll)
//	{
//		base.OnCollisionEnter2D (coll);
//	}
//
//	public override void handleMovement()
//	{
//		Physics2D.IgnoreLayerCollision (11, 14, true);
//		if (beingHeld) 
//		{
//			transform.position = new Vector2 (player.transform.position.x, (player.transform.position.y + modPos.y));
//			circleCollider.enabled = false;
//		} 
//		else 
//		{
//			circleCollider.enabled = true;
//		}
//	}
//	public override void reflectProjectile(int sentOwner)
//	{
//		Vector2 direction = rb.velocity * ((RPSX.rockThrowSpeed/2)*-1);
//		rb.AddForce (direction, ForceMode2D.Impulse);
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
//		}; 
//		base.reflectProjectile (owner);
//	}
}
