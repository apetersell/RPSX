using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


	//MovementSmooting
	public int directionModifier;
	public static float gravityThreshold = 0.5f;
	public static float leftRightThreshold = 0.5f;
	public bool passThroughPlatforms; 

	//Animation bools
	bool crouching;
	bool running;
	bool walking;


	// Use this for initialization
	void Start () 
	{
		GetReferences ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		movementSmoothing ();
		if (actionable) 
		{
			actions ();
		}
		handleAnimations ();
		if (debugOn) 
		{
			DebugStuff ();
		}
	}

	public void GetReferences()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
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
			//			Melee m = GetComponent<AttackMoveset> ().getAttack (playerInput);
			//			if (playerInput == "BackAir") {
			//				m.directionMod = directionModifier * -1;
			//			} else {
			//				m.directionMod = directionModifier;
			////			}
			//			m.myPlayer = this.gameObject;
			//			m.owner = playerNum;
			//			m.player = this;
			//			m.state = currentState;
			//			m.hitOpponent.Clear ();
			doAttack (playerInput);
		}
	}

	public virtual void doAttack (string sent)
	{
		Debug.Log (sent);
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
		Debug.Log ("FIRE!");
	}
		
	public void jump(float sent)
	{
		rb.velocity = new Vector2 (rb.velocity.x, sent); 
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
}
