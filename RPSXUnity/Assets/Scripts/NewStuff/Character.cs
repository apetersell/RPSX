﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Character : MonoBehaviour {

	//Debug stuff
	public bool debugOn;

	//Player index (used for input reference);
	public int playerNum;

	//Determines if the player is listening for inputs or not.
	public bool actionable;

	//References to other components
	Rigidbody2D rb;
	Animator anim;
	Transform footOrigin;
	Transform frontOrigin; 
	Transform backOrigin; 

	//Movement Stats
	public float groundSpeed;
	public float airSpeed;
	public float jumpSpeed; 
	public int maxAirJumps;
	public int currentAirJumps;
	public float activeGrav;
	public float normalGrav;
	public float fastFallGrav;
	public float fallAcceleration; 

	//Jump Stuff
	public float footRaycastDistance;
	public float frontRaycastDistance;
	public float backRaycastDistance;

	//Attack Stuff

	//RPS Stuff
	public RPS_State currentState; 

	//Getting Hit
	public float hitStun;
	public float weight;
	public float hitStunMultiplier = 0.1f;
	public float DIMultiplier = 0.1f;

	//MovementSmoothing
	public int directionModifier;
	public static float gravityThreshold = 0.5f;
	public static float leftRightThreshold = 0.5f;
	public bool passThroughPlatforms; 

	//MeterStuff
	public static float meterMax = 10;
	public float meterCurrent;
	public static float meterDegradeRate = 0.1f;
	public static float meterChargeRate = 1;
	public Image superMeter;

	//State Color
	Color stateColor;

	//Animation bools
	bool crouching;
	bool running;
	bool walking;


	// Use this for initialization
	void Start () 
	{
		GetReferences ();
		currentState = RPS_State.Basic;
	}
	
	// Update is called once per frame
	void Update () 
	{
		colorHandle ();
		movementSmoothing ();
		handleHitStun ();
		handleMeter ();
		if (actionable) 
		{
			actions ();
		}
		handleAnimations ();
		if (debugOn) 
		{
			DebugStuff ();
		}
		if (hitStun > 0) 
		{
			directionalInfluence ();
		}
	}

	public void GetReferences()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		superMeter = GameObject.Find ("Fill_P" + playerNum).GetComponent<Image> ();
		footOrigin = transform.GetChild (0);
		frontOrigin = transform.GetChild (1); 
		backOrigin = transform.GetChild (2); 
	}

	public void actions ()
	{
		movement ();
		handleJumps ();
		handleCrouching ();
		gravControl ();
		handleAttacks ();
		changeState ();
	}

	public void movement()
	{
		float moveSpeed = 0;
		if (grounded ()) {
			moveSpeed = groundSpeed;
		} else {
			moveSpeed = airSpeed;
		}
		float stickInput = (Input.GetAxis ("LeftStickX_P" + playerNum));
		float absSI = Mathf.Abs (stickInput); 
		if (stickInput > leftRightThreshold) 
		{
			rb.velocity = new Vector2 (moveSpeed * absSI, rb.velocity.y);
			if (directionModifier != 1) 
			{
				flipCharacter (1);
			}
		}
		if (stickInput < -leftRightThreshold) 
		{
			rb.velocity = new Vector2 (-moveSpeed * absSI, rb.velocity.y);
			if (directionModifier != -1) 
			{
				flipCharacter (-1);
			}
		}
		if (stickInput == 0) 
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

		if (absSI >= 0.75) {
			running = true;
			walking = false;
		}
		if (absSI < 0.75 && absSI != 0) {
			walking = true;
			running = false;
		}
		if (absSI == 0) {
			walking = false;
			running = false;
		}
	}
		
	void handleJumps()
	{
		//Resets double jumps
		if (grounded ()) 
		{
			currentAirJumps = maxAirJumps;
		}

		if (Input.GetButtonDown ("AButton_P" + playerNum)) 
		{
			if (grounded ()) {
				anim.SetTrigger ("Jump");
			} else {
				if (currentAirJumps != 0) {
					currentAirJumps--;
					jump (jumpSpeed);
				}
			}
		}
	}

	void handleAttacks()
	{
		if (Input.GetButtonDown ("XButton_P" + playerNum)) 
		{
			string playerInput = RPSX.input 
				(Input.GetAxis ("LeftStickX_P" + playerNum),
					Input.GetAxis ("LeftStickY_P" + playerNum),
					directionModifier,
					grounded(),
					running,
					crouching); 
			Attack attack = GetComponent<AttackMoveset> ().getAttack (playerInput);
			float KBIX = Input.GetAxis ("LeftStickX_P" + playerNum);
			float KBIY = -Input.GetAxis ("LeftStickY_P" + playerNum);
			if (playerInput == "BackAir") 
			{
				attack.directionMod = directionModifier * -1;
			} else {
				attack.directionMod = directionModifier;
			}
			attack.owner = this;
			attack.state = currentState;
			attack.playersHit.Clear ();
			attack.KBIFactorX = KBIX;
			attack.KBIFactorY = KBIY;
			doAttack (playerInput);
		}
	}

	void changeState ()
	{
		if (Input.GetButtonDown ("DPadUp_P" + playerNum)) 
		{
			currentState = RPS_State.Paper;
		}
		if (Input.GetButtonDown ("DPadLeft_P" + playerNum)) 
		{
			currentState = RPS_State.Rock;
		}
		if (Input.GetButtonDown ("DPadRight_P" + playerNum)) 
		{
			currentState = RPS_State.Scissors;
		}
		if (Input.GetButtonDown ("DPadDown_P" + playerNum)) 
		{
			currentState = RPS_State.Basic;
		}
	}

	public virtual void doAttack (string sent)
	{
		anim.SetTrigger (sent);
	}

	public virtual void doSpecial (string sent)
	{

	}
	public virtual void defend ()
	{

	}

	public virtual void shoot ()
	{
	}
		
	public void jump(float sent)
	{
		rb.velocity = new Vector2 (rb.velocity.x, sent); 
	}

	public void handleMeter()
	{
		if (meterCurrent <= 0) 
		{
			meterCurrent = 0;
			if (currentState != RPS_State.Basic) 
			{
				currentState = RPS_State.Basic;
			}
		}
		if (currentState != RPS_State.Basic) 
		{
			meterCurrent -= Time.deltaTime;
		}
		superMeter.fillAmount = meterCurrent / meterMax;
	}

	public void handleCrouching ()
	{
		if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold && grounded()) 
		{
			crouching = true;
		} else {
			crouching = false;
		}
	}

	public virtual void gravControl ()
	{
		rb.gravityScale = activeGrav;
		if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold) 
		{
			if (activeGrav <= fastFallGrav) {
				activeGrav += fallAcceleration;
			} else {
				activeGrav = fastFallGrav;
			}
		} else {
			activeGrav = normalGrav;
		}
	}

	public virtual void movementSmoothing ()
	{
		if (rb.velocity.y > 0 && !grounded ()) {
			passThroughPlatforms = true;
		} else {
			if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold) {
				passThroughPlatforms = true;
			} else {
				passThroughPlatforms = false;
			}
		}

		if (passThroughPlatforms) {
			if (playerNum == 1) {
				Physics2D.IgnoreLayerCollision (11, 8, true);
			}
			if (playerNum == 2) {
				Physics2D.IgnoreLayerCollision (11, 9, true);
			}
		} else {
			if (playerNum == 1) {
				Physics2D.IgnoreLayerCollision (11, 8, false);
			}
			if (playerNum == 2) {
				Physics2D.IgnoreLayerCollision (11, 9, false);
			}
		}
	}

	public void takeHit (Vector3 knockbackAngle, float knockback )
	{
		rb.velocity = knockbackAngle;
		hitStun = knockback * hitStunMultiplier;
	}

	void handleHitStun ()
	{
		if (hitStun > 0) 
		{
			actionable = false;
			hitStun -= Time.deltaTime;
		}
		if (hitStun <= 0) 
		{
			actionable = true;
		}
	}

	void directionalInfluence ()
	{
		float DIX = Input.GetAxis ("LeftStickX_P" + playerNum) * DIMultiplier;
		float DIY = -Input.GetAxis ("LeftStickY_P" + playerNum) * DIMultiplier;
		Vector2 DI = new Vector3 (DIX, DIY);
		rb.velocity += DI; 
	}

	public bool grounded ()
	{
		RaycastHit2D below = Physics2D.Raycast (footOrigin.transform.position, Vector2.down, footRaycastDistance);
		if (below.collider != null) {
			return below.collider.gameObject.tag == "Floor";
		} else {
			return false;
		}
	}

	public GameObject touchingWFront()
	{
		Vector2 lookDir = new Vector2 (directionModifier, 0);
		RaycastHit2D front = Physics2D.Raycast (frontOrigin.transform.position, lookDir, frontRaycastDistance);
		if (front.collider != null) {
			return front.collider.gameObject;
		} else {
			return null;
		}
	}

	public GameObject touchingBack()
	{
		Vector2 lookDir = new Vector2 (-directionModifier, 0);
		RaycastHit2D back = Physics2D.Raycast (backOrigin.transform.position, lookDir, backRaycastDistance);
		if (back.collider != null) {
			return back.collider.gameObject;
		} else {
			return null;
		}
	}

	void flipCharacter (int dm)
	{
		if (grounded ()) 
		{
			Vector3 flip = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			transform.localScale = flip;
			directionModifier = dm;
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Token") 
		{
			Token token = coll.gameObject.GetComponent<Token> ();
			meterCurrent = meterMax;
			currentState = token.type;
			token.collect ();
		}
	}

	public virtual void handleAnimations ()
	{
		anim.SetBool ("Actionable", actionable);
		anim.SetBool ("Grounded", grounded());
		//anim.SetBool ("Shielding", shieldUp);
		anim.SetBool ("Running", running);
		anim.SetBool ("Walking", walking);
		anim.SetBool ("Crouching", crouching);
		//anim.SetFloat ("Hitstun", currentHitStun);
		anim.SetFloat ("HorizontalMovement", Mathf.Abs(rb.velocity.x));
		anim.SetFloat ("VerticalMovement", rb.velocity.y);
	}

	void DebugStuff()
	{
		Vector3 footEndPoint = new Vector3 (footOrigin.position.x, footOrigin.position.y - footRaycastDistance, footOrigin.position.z);
		Debug.DrawLine (footOrigin.transform.position, footEndPoint , Color.green);

		Vector3 frontEndPoint = new Vector3 (frontOrigin.position.x + frontRaycastDistance * directionModifier, frontOrigin.position.y, frontOrigin.position.z);
		Debug.DrawLine (frontOrigin.transform.position, frontEndPoint , Color.red);

		Vector3 backEndPoint = new Vector3 (backOrigin.position.x - backRaycastDistance * directionModifier, backOrigin.position.y, backOrigin.position.z);
		Debug.DrawLine (backOrigin.transform.position, backEndPoint , Color.blue);
	}

	void colorHandle ()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		if (hitStun > 0) {
			sr.color = Color.magenta;
		} else {
			sr.color = stateColor;
		}
		switch (currentState) 
		{
		case RPS_State.Basic:
			stateColor = RPSX.basicColor;
			break;
		case RPS_State.Rock:
			stateColor = RPSX.rockColor;
			break;
		case RPS_State.Paper:
			stateColor = RPSX.paperColor;
			break;
		case RPS_State.Scissors:
			stateColor = RPSX.scissorsColor;
			break;
		}
		superMeter.color = stateColor;
	}
}
