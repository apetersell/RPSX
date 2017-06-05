using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	SpriteRenderer sr;
	StateCooldowns sc;
	SignSelector ss;
	public RPSState rps; 

	public int playerNum;

	public string selectedState;
	public string currentState;
	public float moveSpeed;
	public float airSpeedModifier;
	public float jumpSpeed;
	public float normalGrav;
	public float fastFallGrav;
	public float gravityThreshold;
	public int directionModifier;
	public int maxAirActions;
	public int airActionsRemaining;
	public bool touchingGround;
	public bool actionable = true;
	public bool affectedByGrav = true;

	private int rpsNum = 1;

	public float maxTimeinState;
	public float currentTimeinState;


	// Use this for initialization
	void Awake ()
	{
		airActionsRemaining = maxAirActions;
	}

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		rps = GetComponent<RPSState> ();
		sc = GetComponent <StateCooldowns> ();
		ss = GetComponentInChildren<SignSelector> ();
		airActionsRemaining = maxAirActions;

		
	}
	
	// Update is called once per frame
	void Update () {

		if (actionable) 
		{
			actions ();
		}

		chooseState ();
		applyStats ();
		stateTimer ();
		rps = GetComponent<RPSState> ();

	}
		
	void actions ()
	{
//		Left and right movement.
		if (Input.GetAxis ("LeftStickX_P" + playerNum) > 0) 
		{
			sr.flipX = false;
			directionModifier = 1;
			if (touchingGround) {
				rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2 (moveSpeed * airSpeedModifier, rb.velocity.y);
			}
		}

		if (Input.GetAxis ("LeftStickX_P" + playerNum) < 0) 
		{
			sr.flipX = true;
			directionModifier = -1;
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

		//Jumping
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
			if (airActionsRemaining != 0) 
			{
				rps.airAction ();
				airActionsRemaining--;
			}
		}

		//Change RPS
		if (Input.GetButtonDown ("YButton_P" + playerNum)) 
		{
			if (selectedState != currentState && !sc.statesOnCoolDown.Contains(selectedState)) 
			{
				sc.putStateOnCooldown (currentState);
				if (selectedState == "Rock" && sc.rockOnCooldown == false) {
					currentState = "Rock";
					Destroy (gameObject.GetComponent<RPSState> ()); 
					gameObject.AddComponent<RockState> ();
					ss.addToTimer (.5f);

				} else if (selectedState == "Paper" && sc.paperOnCooldown == false) {
					currentState = "Paper";
					Destroy (gameObject.GetComponent<RPSState> ());
					gameObject.AddComponent<PaperState> ();
					ss.addToTimer (.5f);
				} else if (selectedState == "Scissors" && sc.scissorsOnCooldown == false) {
					currentState = "Scissors";
					Destroy (gameObject.GetComponent<RPSState> ());
					gameObject.AddComponent<ScissorsState> ();
					ss.addToTimer (.5f);
				}
				currentTimeinState = maxTimeinState;
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
		if (airActionsRemaining > maxAirActions) 
		{
			airActionsRemaining = maxAirActions;
		}
	}

	void chooseState ()
	{
		if (rpsNum > 3) {
			rpsNum = 1;
		}

		if (rpsNum < 1) {
			rpsNum = 3;
		}

		if (Input.GetButtonDown ("RBumper_P" + playerNum)) {
			rpsNum++;
			ss.addToTimer (3f);
		}

		if (Input.GetButtonDown ("LBumper_P" + playerNum)) {
			rpsNum--;
			ss.addToTimer (3f);
		}
			
		if (rpsNum == 1) {
			selectedState = "Rock";
		}

		if (rpsNum == 2) {
			selectedState = "Paper";
		}

		if (rpsNum == 3) {
			selectedState = "Scissors";
		}
	}

	void stateTimer()
	{
		currentTimeinState = currentTimeinState - Time.deltaTime;
		if (currentTimeinState <= 0 && currentState != "Basic") 
		{
			sc.putStateOnCooldown (currentState);
			currentTimeinState = 0;
			backToBasic ();
		}
			
	}

	public void backToBasic ()
	{
		Destroy (gameObject.GetComponent<RPSState> ());
		currentState = "Basic";
		gameObject.AddComponent<BasicState>();
	}

}
