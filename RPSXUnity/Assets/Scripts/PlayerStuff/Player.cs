using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	protected Rigidbody2D rb;
	protected SpriteRenderer sr;
	protected StateCooldowns sc;
	protected SignSelector ss;
	protected Color color;
	protected Color flashing;
	public bool shieldDebug;
	public bool stateDebug;
	public RPSState rps;

	public int playerNum;
	public float HP;

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
	public bool touchingWall= false;
	public bool stopRightMomentum = false;
	public bool stopLeftMomentum = false;
	public bool passThroughPlatforms;
	public bool fusionReady; 

	public GameObject shield;
	public Shield s;
	public Collider2D playerCollider;
	public float maxShieldDuration;
	public float currentShieldDuration;
	public bool shieldUp;
	public bool shieldBroken = false;
	public float shieldDiminishRate;
	public float shieldRefreshRate;

	public bool canShoot = true;
	public float shotDelay;
	public float currentShotDelay;
	public GameObject heldRock;

	private int rpsNum = 1;
	public float maxTimeinState;
	public float currentTimeinState;

	public float currentHitStun;
	public bool canMove;

	public SFXGuy sfx;


	// Use this for initialization
	public virtual void Awake ()
	{
		shield = GameObject.Find ("Shield_P" + playerNum);
		sfx = GameObject.Find ("SoundGuy").GetComponent<SFXGuy> ();
		maxShieldDuration = RPSX.maxShieldDuration;
		currentShieldDuration = RPSX.maxShieldDuration;
		playerCollider = GetComponent<Collider2D> ();
	}

	public virtual void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		rps = GetComponent<RPSState> ();
		sc = GetComponent <StateCooldowns> ();
		ss = GetComponentInChildren<SignSelector> ();
		s = shield.GetComponent<Shield> ();
		HP = RPSX.playerMaxHP;

		
	}
	
	// Update is called once per frame
	public virtual void Update () {

		if (actionable) 
		{
			actions ();
		}

		handleShotDelay ();
		chooseState ();
		applyStats ();
		handleHitStun ();
		if (stateDebug == false) 
		{
			stateTimer ();
		}
		handleShield ();
		handleColor ();
		movementSmoothing ();
		if (canMove) 
		{
			moving ();
		}
		rps = GetComponent<RPSState> ();

	}
		
	public virtual void actions ()
	{
		//Jumping
		if (Input.GetButtonDown ("AButton_P" + playerNum)) 
		{
			if (touchingGround) 
			{
				jump (jumpSpeed);
			}
		}
		airAction();
		shoot();
		normalAttacks ();
		changeRPS ();
		fastFalling ();
		if (shieldDebug == false) 
		{
			if (shieldBroken == false) 
			{
				putUpShield ();
			}
		} 
	}

	//Handles jumping
	public virtual void jump (float jumpNum) 
	{
		rb.velocity = new Vector2 (rb.velocity.x, jumpNum); 
	}

	//What happens when a player "double jumps"
	public virtual void airAction ()
	{
		if (Input.GetButtonDown ("AButton_P" + playerNum) && touchingGround == false) 
		{
			if (airActionsRemaining != 0) 
			{
				rps.airAction ();
				airActionsRemaining--;
			}
		}
	}

	//The player can put up shield with RT
	public virtual void putUpShield ()
	{
		if (shieldDebug == false) 
		{
			if (Input.GetAxis ("RTrigger_P" + playerNum) == 1) 
			{
				shield.SetActive (true);
				shieldUp = true;
			} 
			else 
			{
				shield.SetActive (false);
				shieldUp = false;
			}
		} 
		else 
		{
			shield.SetActive (true); 
			shieldUp = true;
		}
	}

	//Handdles projectile attack
	public virtual void shoot ()
	{
		if (Input.GetButtonDown ("BButton_P" + playerNum))
		{
			if (canShoot) 
			{
				GetComponent<ProjectileLauncher> ().fireProjectile (playerNum, directionModifier, currentState, touchingGround);
			}

		}
	}

	//Handles changing RPS State
	public virtual void changeRPS ()
	{
		if (Input.GetAxis ("LTrigger_P" + playerNum) == 1) 
		{
			if (selectedState != currentState && !sc.statesOnCoolDown.Contains(selectedState)) 
			{
				sc.putStateOnCooldown (currentState);
				if (selectedState == "Rock" && sc.rockOnCooldown == false) {
					currentState = "Rock";
					Destroy (gameObject.GetComponent<RPSState>()); 
					Destroy (gameObject.GetComponent<ProjectileLauncher> ());
					gameObject.AddComponent<RockLauncher> ();
					gameObject.AddComponent<RockState> ();
					ss.addToTimer (.5f);
					selectionEffect ("Rock");

				} else if (selectedState == "Paper" && sc.paperOnCooldown == false) {
					currentState = "Paper";
					Destroy (gameObject.GetComponent<RPSState>()); 
					Destroy (gameObject.GetComponent<ProjectileLauncher> ());
					gameObject.AddComponent<PaperAirplaneLauncher> ();
					gameObject.AddComponent<PaperState> ();
					ss.addToTimer (.5f);
					selectionEffect ("Paper");
				} else if (selectedState == "Scissors" && sc.scissorsOnCooldown == false) {
					currentState = "Scissors";
					Destroy (gameObject.GetComponent<RPSState>()); 
					Destroy (gameObject.GetComponent<ProjectileLauncher> ());
					gameObject.AddComponent<ScissorLauncher> ();
					gameObject.AddComponent<ScissorsState> ();
					ss.addToTimer (.5f);
					selectionEffect ("Scissors");
				}
				currentTimeinState = maxTimeinState;
				rb.gravityScale = rps.normalGrav;
				rb.mass = 1;
				affectedByGrav = true;
				sfx.playSFX ("newState");
				if (heldRock != null) 
				{
					ProjectilePool.addToPool (heldRock, "Rock");
				}
			}

		}
	}

	//Handles normal XButton attacks
	public virtual void normalAttacks ()
	{
		if (Input.GetButtonDown ("XButton_P" + playerNum))
		{
			//			string input = GetComponent<AttackMoveset> ().input (
			//				               Input.GetAxis ("LeftStickX_P" + playerNum),
			//				               Input.GetAxis ("LeftStickY_P" + playerNum),
			//				               touchingGround);
			//			Debug.Log (input);
//			if (meleeAttack == null) {
////				GetComponent<AttackMoveset> ().doAttack (
//					Input.GetAxis ("LeftStickX_P" + playerNum),
//					Input.GetAxis ("LeftStickY_P" + playerNum),
//					touchingGround,
//					directionModifier,
//					currentState,
//					playerNum,
//					this);
//			}
		}
	}

	//Player falls faster when holding down.
	public virtual void fastFalling ()
	{
		if (affectedByGrav) 
		{
			if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold) {
				rb.gravityScale = fastFallGrav;
				passThroughPlatforms = true;
			} else {
				rb.gravityScale = normalGrav;
				passThroughPlatforms = false;
			}
		}
	}
		
	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
		//Reset Jumps upon touching ground
		if (coll.gameObject.tag == "Floor") 
		{
			touchingGround = true;
		}

		if (coll.gameObject.tag == "Wall") 
		{
			touchingWall = true;
		}
	}
		

	public virtual void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Floor") 
		{
			touchingGround = false; 
		}

		if (coll.gameObject.tag == "Wall")  
		{
			touchingWall = false;
		} 
	}

	//Adjusting Stats with State Change
	public virtual void applyStats ()
	{
		moveSpeed = rps.moveSpeed;
		airSpeedModifier = rps.airSpeedModifier;
		jumpSpeed = rps.jumpSpeed;
		normalGrav = rps.normalGrav;
		fastFallGrav = rps.fastFallGrav;
		maxAirActions = rps.maxAirActions;
		shieldDiminishRate = rps.shieldDiminishRate;
		if (currentHitStun == 0) {
			color = rps.color;
		} else {
			color = RPSX.inHitStun;
		}
		shotDelay = rps.projectileFireRate;
		if (airActionsRemaining > maxAirActions) 
		{
			airActionsRemaining = maxAirActions;
		}
		if (currentShotDelay > shotDelay) 
		{
			currentShotDelay = shotDelay;
		}
	}

	public virtual void chooseState ()
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

	public virtual void stateTimer()
	{
		currentTimeinState = currentTimeinState - Time.deltaTime;
		if (currentTimeinState <= 0 && currentState != "Basic") 
		{
			sc.putStateOnCooldown (currentState);
			currentTimeinState = 0;
			backToBasic ();
		}
			
	}

	//Shield Stuff
	public virtual void handleShield ()
	{
		//Shield duration goes down when shield is up.  Shield regenarates when not in use.
		if (shieldDebug == false) {
			if (shieldUp) {
				currentShieldDuration = currentShieldDuration - shieldDiminishRate * Time.deltaTime;
			} else {
				currentShieldDuration = currentShieldDuration + shieldRefreshRate * Time.deltaTime;
			}

			//Makes sure the shield's duration can never be higher than it's max and cant go lower than 0.
			if (currentShieldDuration > maxShieldDuration) {
				currentShieldDuration = maxShieldDuration;
			}
			if (currentShieldDuration < 0) {
				currentShieldDuration = 0;
			}
		}

		//Shield "breaks" if it's duration goes down to zero.
		if (currentShieldDuration <= 0) 
		{
			shield.SetActive(false);
			shieldBroken = true;
		}

		//Shield can't be up if it's broken.
		if (shieldBroken) 
		{
			shieldUp = false;
		}

		//Shield is no longer broken when it gets back up to full duration
		if (currentShieldDuration >= maxShieldDuration) 
		{
			shieldBroken = false;
		}
	
	}

	// Reset back to Basic State
	public virtual void backToBasic ()
	{
		Destroy (gameObject.GetComponent<RPSState> ());
		Destroy (gameObject.GetComponent <ProjectileLauncher> ());
		currentState = "Basic";
		gameObject.AddComponent<BasicState>();
		gameObject.AddComponent<BasicBeamLauncher> ();
		rb.gravityScale = rps.normalGrav; 
		rb.mass = 1;
		affectedByGrav = true;
		sfx.playSFX ("powerDown");
		if (heldRock != null) 
		{
			ProjectilePool.addToPool (heldRock, "Rock");
		}
	}

	//Makes sure player is appropriate state color.  Flashes when state is close to over.
	public virtual void handleColor ()
	{
		flashing = Color.Lerp(color, RPSX.basicColor, Mathf.PingPong(Time.time*10, 1));
		if (currentTimeinState <= 3 && currentState != "Basic") {
			sr.color = flashing;
		} 
		else 
		{
			sr.color = color;
		}
	}

	//Function used for taking damage.
	public virtual void takeDamage (float damage, string sentState, float inflictedHitStun, string attackName)
	{
		if (sentState != "Enviornment") {
			string result = RPSX.determineWinner (currentState, sentState);
			float inflictedDamage = 0;
			if (result == "Win") {
				inflictedDamage = damage /2;
			}
			if (result == "Loss") {
				inflictedDamage = damage *2;
			}
			if (result == "Tie") {
				inflictedDamage = damage;
			}
			HP -= inflictedDamage;
			Debug.Log (result + ": " + attackName  + "hit " + this.name + " for " + inflictedDamage + " damage.");
		} 
		else 
		{
			HP = HP - damage;
		}
		currentHitStun = inflictedHitStun;

	
	}

	public virtual void takeShieldDamage (float damage, string sentState)
	{
		string result = RPSX.determineWinner (currentState, sentState);
		if (result == "Loss") 
		{
			currentShieldDuration = currentShieldDuration - (damage * 2);
		}
		if (result == "Tie") 
		{
			currentShieldDuration = currentShieldDuration - damage;
		}
	}

	public virtual void handleShotDelay ()
	{
		if (canShoot == false) 
		{
			currentShotDelay++; 
		}

		if (currentShotDelay >= shotDelay) 
		{
			canShoot = true;
		}
	}

	public virtual void startShotDelay ()
	{
		currentShotDelay = 0;
		canShoot = false;
	}

	public virtual void selectionEffect (string state)
	{
		GameObject effect = Instantiate(Resources.Load("Prefabs/Effects/SelectEffect")) as GameObject;
		effect.GetComponent<SelectionEffect> ().state = state;
		effect.GetComponent<SelectionEffect> ().playerSign = ss.gameObject;
	}

	public virtual void movementSmoothing ()
	{

		// Resets Air Actions when touching ground
		if (touchingGround) 
		{
			airActionsRemaining = maxAirActions;
		}

		// Makes sure players don't awkwardly cling to walls
		if (touchingWall == true && touchingGround == false) {
			if (directionModifier == 1) {
				stopRightMomentum = true;
			}

			if (directionModifier == -1) {
				stopLeftMomentum = true;
			}
		} else 
		{
			stopLeftMomentum = false;
			stopRightMomentum = false;
		}

		// Makes sure players can pass through platforms at the appropriate times.

		if (rb.velocity.y > 0 && touchingGround == false) 
		{
			passThroughPlatforms = true;
		}

		if (passThroughPlatforms) {
			if (playerNum == 1) {
				Physics2D.IgnoreLayerCollision (8, 11, true);
			}
			if (playerNum == 2) {
				Physics2D.IgnoreLayerCollision (9, 11, true);
			}
		} else {
			if (playerNum == 1) {
				Physics2D.IgnoreLayerCollision (8, 11, false);
			}
			if (playerNum == 2) {
				Physics2D.IgnoreLayerCollision (9, 11, false);
			}
		}
	}

	public virtual void handleHitStun ()
	{
		currentHitStun--;
		if (currentHitStun < 0) 
		{
			currentHitStun = 0;
		}
//		if (currentHitStun > 0) {
//			actionable = false; 
//		} else 
//		{
////			actionable = true;
//		}
	}

	public virtual void moving ()
	{
		if (canMove) {
			//Left and right movement.
			if ((Input.GetAxis ("LeftStickX_P" + playerNum) > 0) && stopRightMomentum == false) {
				sr.flipX = false;
				directionModifier = 1;
				if (touchingGround) {
					rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
				} else {
					rb.velocity = new Vector2 (moveSpeed * airSpeedModifier, rb.velocity.y);
				}
			}

			if ((Input.GetAxis ("LeftStickX_P" + playerNum) < 0) && stopLeftMomentum == false) {
				sr.flipX = true;
				directionModifier = -1;
				if (touchingGround) {
					rb.velocity = new Vector2 (moveSpeed * -1, rb.velocity.y);
				} else {
					rb.velocity = new Vector2 (((moveSpeed * -1) * airSpeedModifier), rb.velocity.y);
				}
			}

			if (Input.GetAxis ("LeftStickX_P" + playerNum) == 0) {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			}
		}

	}
		

}
