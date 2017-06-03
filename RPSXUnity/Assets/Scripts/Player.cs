using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	SpriteRenderer sr;
	public RPSState rps; 

	public int playerNum;

	public float moveSpeed;
	public float airSpeedModifier;
	public float jumpSpeed;
	public float normalGrav;
	public float fastFallGrav;
	public float gravityThreshold;
	public int maxAirActions;
	public int airActionsRemaining;
	public bool touchingGround;
	public bool actionable = true;
	public bool affectedByGrav = true;



	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		rps = GetComponent<RPSState> ();
		applyStats ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (actionable) 
		{
			actions ();
		}

	}
		
	void actions ()
	{
//		Left and right movement.
		if (Input.GetAxis ("LeftStickX_P" + playerNum) > 0) 
		{
			sr.flipX = false;
			if (touchingGround) {
				rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2 (moveSpeed * airSpeedModifier, rb.velocity.y);
			}
		}

		if (Input.GetAxis ("LeftStickX_P" + playerNum) < 0) 
		{
			sr.flipX = true;
			if (touchingGround) {
				rb.velocity = new Vector2 (moveSpeed * -1, rb.velocity.y);
			} else {
				rb.velocity = new Vector2 (moveSpeed * -1 * airSpeedModifier, rb.velocity.y);
			}
		}

		if (Input.GetAxis ("LeftStickX_P" + playerNum) == 0)
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

//		Jumping
		if (Input.GetButtonDown ("AButton_P" + playerNum)) 
		{
			if (touchingGround) 
			{
				jump (jumpSpeed);
			}
		}

		//FastFalling
		if (affectedByGrav) 
		{
			if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold) {
				rb.gravityScale = fastFallGrav;
			} else {
				rb.gravityScale = normalGrav;
			}
		}

		//AirAction
		if (Input.GetButtonDown ("AButton_P" + playerNum) && touchingGround == false) 
		{
			if (airActionsRemaining >= maxAirActions) 
			{
				rps.airAction ();
				airActionsRemaining--;
			}
		}
	}


	public void jump (float jumpNum) 
	{
		rb.velocity = new Vector2 (rb.velocity.x, jumpNum); 
	}
		

	void OnCollisionEnter2D (Collision2D coll)
	{
		//Reset Jumps upon touching ground
		if (coll.gameObject.tag == "Floor") 
		{
			touchingGround = true;
			airActionsRemaining = maxAirActions;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Floor") 
		{
			touchingGround = false;
		}
	}

	//Adjusting Stats with State Change
	void applyStats ()
	{
		moveSpeed = rps.moveSpeed;
		airSpeedModifier = rps.airSpeedModifier;
		jumpSpeed = rps.jumpSpeed;
		normalGrav = rps.normalGrav;
		fastFallGrav = rps.fastFallGrav;
		maxAirActions = rps.maxAirActions;
		sr.color = rps.color;
	}
}
