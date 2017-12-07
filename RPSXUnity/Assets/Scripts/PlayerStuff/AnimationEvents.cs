using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class AnimationEvents : MonoBehaviour 
{
	public Player player;
	public float miniJumpMod;
	public float dairSpeed;
	public Vector2 dairAngle; 
	public AnimationClip dashStop; 
	public AttackMoveset am;
	bool dairing;
	public bool airDashCheck;
	public AirDash_RHiro airDash;
	Rigidbody2D rb;

	// Use this for initialization
	void Awake () 
	{
		player = GetComponent<Player> ();
		rb = GetComponent<Rigidbody2D> ();
		am = GetComponent<AttackMoveset> ();
	}

	void Update ()
	{
		if (dairing) 
		{
			rb.velocity = new Vector2 (dairSpeed * (dairAngle.x * player.directionModifier), dairSpeed * dairAngle.y); 
			rb.gravityScale = 0;
			rb.mass = 0;
		} 
	}
	
	public virtual void stopMomentum () 
	{
		rb.velocity = Vector3.zero;
		airDashCheck = false;
	}

	public virtual void dashSlow ()
	{
		slowToStop (rb.velocity, dashStop.length);
	}

	public virtual void unlockPlayer ()
	{
		player.actionable = true;
		player.canMove = true;
		am.jabCount = 0;
	}

	public virtual void turnOffActions ()
	{
		player.actionable = false;
	}

	public virtual void softUnlock ()
	{
		player.actionable = true;
	}

	public virtual void lockPlayer ()
	{
		player.actionable = false;
		player.canMove = false;
	}

	public virtual void doJump ()
	{
		player.jump (player.jumpSpeed);
	}

	public virtual void miniJump ()
	{
		player.jump (player.jumpSpeed * miniJumpMod);
	}

	public virtual void doProjectile ()
	{
		player.shoot ();
	}

	public virtual void turnOffGravity ()
	{
		player.affectedByGrav = false;
		rb.gravityScale = 0;
		rb.mass = 0;
	}

	public virtual void turnOnGravity ()
	{
		player.affectedByGrav = true;
		rb.gravityScale = player.normalGrav;
		rb.mass = 1;
	}

	public virtual void doDair ()
	{
		dairing = true; 
	}

	public virtual void endDair ()
	{
		dairing = false; 
	}

	public virtual void resetAirDashAttack ()
	{
		if (!airDashCheck) 
		{
			airDash.myPlayer = player.gameObject;
			airDash.owner = player.playerNum; 
			airDash.player = player; 
			airDash.state = player.currentState;
			airDash.hitOpponent.Clear ();
			airDashCheck = true;
		}
	}

	public virtual void endAirDash ()
	{
		GetComponent<State_RoughHiro> ().remainingDashTime = 0;
	}
		
	IEnumerator slowToStop (Vector3 speed, float time)
	{
		float currentTime = 0f;
		do
		{
			rb.velocity = Vector3.Lerp(speed, Vector3.zero, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} 
		while (currentTime <= time);
	}


}
