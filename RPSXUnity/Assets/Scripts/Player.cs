using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	SpriteRenderer sr;
	public RPSState rps; 

	public int playerNum;

	public float moveSpeed;
	public float jumpSpeed;
	public float normalGrav;
	public float fastFallGrav;
	public float gravityThreshold;
	public int maxJumps; 
	public int jumpsRemaining;



	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		rps = GetComponent<RPSState> ();
		stateChange ();
		
	}
	
	// Update is called once per frame
	void Update () {

		movement ();
		
	}
		
	void movement ()
	{
//		Left and right movement.
		if (Input.GetAxis ("LeftStickX_P" + playerNum) > 0) 
		{
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			sr.flipX = false;
		}

		if (Input.GetAxis ("LeftStickX_P" + playerNum) < 0) 
		{
			rb.velocity = new Vector2 ((moveSpeed * -1), rb.velocity.y);
			sr.flipX = true;
		}

		if (Input.GetAxis ("LeftStickX_P" + playerNum) == 0)
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

//		Jumping
		if (Input.GetButtonDown ("AButton_P" + playerNum)) 
		{
			if (jumpsRemaining != 0) 
			{
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
				jumpsRemaining = jumpsRemaining - 1;
			}
		}

		//FastFalling
		if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold) {
			rb.gravityScale = fastFallGrav;
		} else {
			rb.gravityScale = normalGrav;
		}

		//AirAction
		if (Input.GetButtonDown ("AButton_P" + playerNum) && (jumpsRemaining < maxJumps)) 
		{
			rps.airAction ();
		}
	}


	void OnCollisionEnter2D (Collision2D coll)
	{
		//Reset Jumps upon touching ground
		if (coll.gameObject.tag == "Floor") 
		{
			jumpsRemaining = maxJumps; 
		}
	}

	//Adjusting Stats with State Change
	void stateChange ()
	{
		moveSpeed = rps.moveSpeed;
		jumpSpeed = rps.jumpSpeed;
		normalGrav = rps.normalGrav;
		fastFallGrav = rps.fastFallGrav;
		maxJumps = rps.maxJumps;
		sr.color = rps.color;
	}
}
