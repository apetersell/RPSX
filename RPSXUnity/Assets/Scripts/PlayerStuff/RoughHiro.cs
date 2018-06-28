using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class RoughHiro : Player {

//	public List<GameObject> meshSkeleton = new List<GameObject> ();
//	public Animator anim;
//	bool running;
//	bool walking;
//	bool crouching;
//	public string movesetName;
//	public override void Awake ()
//	{
//		//Get a reference to the animator
//		anim = GetComponent<Animator>();
//		//Gets a reference to every mesh that makes up Rough Hiro;
//		GameObject meshes = transform.GetChild (0).gameObject;
//		for (int i = 0; i < meshes.transform.childCount; i++) 
//		{
//			GameObject currentMesh = meshes.transform.GetChild (i).gameObject;
//			meshSkeleton.Add (currentMesh);
//		}
//		shield = GameObject.Find ("Shield_P" + playerNum);
//		sfx = GameObject.Find ("SoundGuy").GetComponent<SFXGuy> ();
//		shieldUI = GameObject.Find("ShieldUI_P" + playerNum);
//		maxShieldDuration = RPSX.maxShieldDuration;
//		currentShieldDuration = RPSX.maxShieldDuration;
//		ps = GameObject.Find ("Particles_P" + playerNum).GetComponent<ParticleSystem> ();
//	}
//	
//	// Add animation handler
//	public override void Update () 
//	{
//		if (Input.GetAxis ("RTrigger_P" + playerNum) == 1)
//		{
//			if (!ss.visible) 
//			{
//				shieldUI.SetActive (true);
//			} else {
//				shieldUI.SetActive (false);
//			}
//		} 
//		else 
//		{
//			if (shieldUI != null) {
//				shieldUI.SetActive (false);
//			}
//		}
//
//		bounceStun--;
//		if (bounceStun <= 0) {
//			bounceStun = 0;
//		}
//		if (actionable) 
//		{
//			actions ();
//		}
//
//		handleShotDelay ();
//		chooseState ();
//		applyStats ();
//		handleHitStun ();
//		if (stateDebug == false) 
//		{
//			stateTimer ();
//		}
//		handleShield ();
//		handleColor ();
//		movementSmoothing ();
//		handleAnimations ();
//		if (currentHitStun <= 0) 
//		{
//			if (crouching == false) 
//			{
//				if (shieldUp == false) 
//				{
//					moving ();
//				}
//			}
//		}
//		rps = GetComponent<RPSState> ();
//	}
//
//	public override void moving ()
//	{
//		if (bounceStun == 0) 
//		{
//			float stickInput = (Input.GetAxis ("LeftStickX_P" + playerNum));
//			float absSI = Mathf.Abs (stickInput); 
//			if (canMove) {
//				//Left and right movement.
//				if (stickInput > 0 && stopRightMomentum == false) {
//					if (touchingGround) {
//						if (directionModifier != 1) {
//							flipCharacter (1);
//						} 
//						rb.velocity = new Vector2 (moveSpeed * absSI, rb.velocity.y);
//					} else {
//						rb.velocity = new Vector2 ((moveSpeed * airSpeedModifier) * absSI, rb.velocity.y);
//					}
//				}
//
//				if (stickInput < 0 && stopLeftMomentum == false) 
//				{ 
//					if (touchingGround) {
//						if (directionModifier != -1) {
//							flipCharacter (-1);
//							directionModifier = -1;
//						}
//						rb.velocity = new Vector2 ((moveSpeed * -1) * absSI, rb.velocity.y);
//					} else {
//							rb.velocity = new Vector2 (((moveSpeed * -1) * airSpeedModifier) * absSI, rb.velocity.y);
//					}
//				}
//			}
//
//			if (absSI >= 0.75) {
//				running = true;
//				walking = false;
//			}
//			if (absSI < 0.75 && absSI != 0) {
//				walking = true;
//				running = false;
//			}
//			if (absSI == 0) {
//				walking = false;
//				running = false;
//			}
//		}
//
//	}
//
//	public override void actions ()
//	{
//		//Jumping
//		if (Input.GetButtonDown ("AButton_P" + playerNum)) 
//		{
//			if (touchingGround) 
//			{
//				anim.SetTrigger ("Jump");
//			}
//		}
//		if (Input.GetButtonDown ("BButton_P" + playerNum)) 
//		{
//			anim.SetTrigger ("Projectile");
//		}
//		airAction();
//		normalAttacks ();
//		changeRPS ();
//		fastFalling ();
//		if (shieldDebug == false) 
//		{
//			if (shieldBroken == false) 
//			{
//				putUpShield ();
//			}
//		} 
//	}
//
//	public override void jump (float jumpNum)
//	{
//		base.jump (jumpNum);
//	}
//
//	public override void shoot ()
//	{
//		GetComponent<ProjectileLauncher> ().fireProjectile (playerNum, directionModifier, currentState, touchingGround);
//	}
//
//	public override void handleColor()
//	{
//		flashing = Color.Lerp(color, RPSX.basicColor, Mathf.PingPong(Time.time*10, 1));
//
//
//		if (currentHitStun != 0) {
//			foreach (GameObject mesh in meshSkeleton) {
//				SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
//				smi.color = RPSX.inHitStun;
//			}
//		} else if (bounceStun != 0) {
//			foreach (GameObject mesh in meshSkeleton) {
//				SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
//				smi.color = RPSX.inBounceStun;
//			}
//		}
//		else
//		{
//			if (currentTimeinState <= 3 && currentState != "Basic") 
//			{
//				foreach (GameObject mesh in meshSkeleton) 
//				{
//					SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
//					smi.color = flashing;
//				}
//			} 
//			else 
//			{
//				foreach (GameObject mesh in meshSkeleton) 
//				{
//					SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
//					smi.color = rps.color;
//				}
//			}
//		}
//	}
//
//	public override void normalAttacks ()
//	{
//		if (Input.GetButtonDown ("XButton_P" + playerNum))
//		{
//			string playerInput = RPSX.input (
//				Input.GetAxis("LeftStickX_P" + playerNum),
//				Input.GetAxis("LeftStickY_P" + playerNum),
//				directionModifier,
//				touchingGround,
//				running,
//				crouching);
//			Melee m = GetComponent<AttackMoveset> ().getAttack (playerInput);
//			if (playerInput == "BackAir") {
//				m.directionMod = directionModifier * -1;
//			} else {
//				m.directionMod = directionModifier;
//			}
//			m.myPlayer = this.gameObject;
//			m.owner = playerNum;
//			m.player = this;
//			m.state = currentState;
//			m.hitOpponent.Clear ();
//			anim.SetTrigger (playerInput);
//		}
//	}
//
//	public override void handleShield ()
//	{
//		if (shieldUp) {
//			float stickInput = (Input.GetAxis ("LeftStickX_P" + playerNum));
//			float absSI = Mathf.Abs (stickInput); 
//			if (stickInput > 0 && stopRightMomentum == false) {
//				if (directionModifier != 1) {
//					flipCharacter (1); 
//				}
//			} 
//			if (stickInput < 0 && stopLeftMomentum == false) { 
//				if (touchingGround) {
//					if (directionModifier != -1) {
//						flipCharacter (-1);
//					}
//				}
//			}
//		}
//		base.handleShield ();
//	}
//
//
//	public override void handleHitStun ()
//	{
//		base.handleHitStun ();
//	}
//		
//	public virtual void handleAnimations ()
//	{
//		if (Input.GetAxis ("LeftStickY_P" + playerNum) > gravityThreshold && touchingGround) 
//		{
//			crouching = true;
//		} else {
//			crouching = false;
//		}
//		anim.SetBool ("Actionable", actionable);
//		anim.SetBool ("Grounded", touchingGround);
//		anim.SetBool ("Shielding", shieldUp);
//		anim.SetBool ("Running", running);
//		anim.SetBool ("Walking", walking);
//		anim.SetBool ("Crouching", crouching);
//		anim.SetFloat ("Hitstun", currentHitStun);
//		anim.SetFloat ("HorizontalMovement", Mathf.Abs(rb.velocity.x));
//		anim.SetFloat ("VerticalMovement", rb.velocity.y);
//	}
}
