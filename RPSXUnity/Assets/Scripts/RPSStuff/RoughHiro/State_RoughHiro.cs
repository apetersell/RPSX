using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_RoughHiro : RPSState {

	protected Rigidbody2D rb;
	protected float airDashSpeed;
	public float maxDashTime;
	public float attackDamage;
	public float attackShieldDamage;
	public float attackHitStun;
	public float attackBounceStun;
	public float remainingDashTime;
	public bool airDashing = false;
	public Vector2 trajectory;

	// Use this for initialization
	public virtual void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	public virtual void Update () 
	{
		handleDash ();
	}

	public override void airAction ()
	{
		float modX = (Input.GetAxis ("LeftStickX_P" + p.playerNum));
		float modY = (Input.GetAxis ("LeftStickY_P" + p.playerNum)) * -1;
		if (modY <= 0) 
		{
			modY = 0;
		}
		if (modX == 0 && modY == 0) 
		{
			modX = p.directionModifier;
		}
		trajectory = new Vector2 (modX, modY).normalized;
		if (Mathf.Sign (trajectory.x) != Mathf.Sign (p.directionModifier)) 
		{
			if (Mathf.Sign (trajectory.x) < 0) 
			{
				p.flipCharacter (-1);
			}
			if (Mathf.Sign (trajectory.x) > 0) 
			{
				p.flipCharacter (1);
			}
		}
		airDashing = true;
	}

	public virtual void handleDash ()
	{
		GetComponent<Animator> ().SetBool ("AirDashing", airDashing);
		if (airDashing) 
		{
			p.actionable = false;
			rb.velocity = new Vector2 (trajectory.x * airDashSpeed, trajectory.y * airDashSpeed); 
			float angle = Mathf.Atan2(trajectory.y * p.directionModifier, trajectory.x * p.directionModifier) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			rb.gravityScale = 0;
			rb.mass = 0;
			remainingDashTime--;
		}

		if (remainingDashTime <= 0) 
		{
			GetComponent<AnimationEvents> ().stopMomentum ();
			GetComponent<AnimationEvents> ().airDashCheck = false;
			transform.rotation = Quaternion.identity;
			airDashing = false;
			remainingDashTime = maxDashTime;
			rb.gravityScale = normalGrav;
			rb.mass = 1;
			p.actionable = true;
		}
	}

}
