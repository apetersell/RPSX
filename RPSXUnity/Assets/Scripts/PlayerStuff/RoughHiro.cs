using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class RoughHiro : Player {

	public List<GameObject> meshSkeleton = new List<GameObject> ();
	public Animator anim;


	public override void Awake ()
	{
		//Get a reference to the animator
		anim = GetComponent<Animator>();

		//Gets a reference to every mesh that makes up Rough Hiro;
		GameObject meshes = transform.GetChild (0).gameObject;
		for (int i = 0; i < meshes.transform.childCount; i++) 
		{
			GameObject currentMesh = meshes.transform.GetChild (i).gameObject;
			meshSkeleton.Add (currentMesh);
		}
		shield = GameObject.Find ("Shield_" + gameObject.name);
		sfx = GameObject.Find ("SoundGuy").GetComponent<SFXGuy> ();
		maxShieldDuration = RPSX.maxShieldDuration;
		currentShieldDuration = RPSX.maxShieldDuration;
		playerCollider = GetComponent<Collider2D> ();
	}
	
	// Add animation handler
	public override void Update () 
	{

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
		handleAttackDuration ();
		handleAnimations ();
		if (meleeAttack == null || meleeAttack.GetComponent<Melee> ().grounded == false) 
		{
			if (currentHitStun <= 0) 
			{
				moving ();
			}
		}
		rps = GetComponent<RPSState> ();
	}

	public override void moving ()
	{
		//Left and right movement.
		if ((Input.GetAxis ("LeftStickX_P" + playerNum) > 0) && stopRightMomentum == false) 
		{
			if (directionModifier != 1) 
			{
				flipCharacter ();
				directionModifier = 1;
			}
			if (touchingGround) {
				rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			} 
			else 
			{
				rb.velocity = new Vector2 (moveSpeed * airSpeedModifier, rb.velocity.y);
			}
		}

		if ((Input.GetAxis ("LeftStickX_P" + playerNum) < 0) && stopLeftMomentum == false) 
		{
			if (directionModifier != -1) 
			{
				flipCharacter ();
				directionModifier = -1;
			}
			if (touchingGround) {
				rb.velocity = new Vector2 (moveSpeed * -1, rb.velocity.y);
			} 
			else 
			{
				rb.velocity = new Vector2 (((moveSpeed * -1) * airSpeedModifier), rb.velocity.y);
			}
		}

		if (Input.GetAxis ("LeftStickX_P" + playerNum) == 0)
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

	}

	public override void jump (float jumpNum)
	{
		anim.SetTrigger ("Jump");
		base.jump (jumpNum);
	}

	public override void handleColor()
	{
		flashing = Color.Lerp(color, RPSX.basicColor, Mathf.PingPong(Time.time*10, 1));

		if (currentTimeinState <= 3 && currentState != "Basic") {
			if (currentHitStun == 0) 
			{
				foreach (GameObject mesh in meshSkeleton) 
				{
					SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
					smi.color = flashing;
				}
			} 
		} 
		else 
		{
			foreach (GameObject mesh in meshSkeleton) 
			{
				SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
				smi.color = rps.color;
			}
		}
	}
		
		
	public virtual void handleAnimations ()
	{
		anim.SetBool ("Grounded", touchingGround);
		anim.SetBool ("Shielding", shieldUp);
		anim.SetFloat ("HitStun", currentHitStun);
		anim.SetFloat ("HorizontalMovement", Mathf.Abs(rb.velocity.x));
		anim.SetFloat ("VerticalMovement", rb.velocity.y);
	}

	public virtual void flipCharacter ()
	{
		Vector3 flip = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		transform.localScale = flip;
	}
}
