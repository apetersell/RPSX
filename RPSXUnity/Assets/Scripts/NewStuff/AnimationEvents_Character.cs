using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents_Character : MonoBehaviour {

	public Character character; 
	//public AnimationClip dashStop; 
	public AttackMoveset am;
	Rigidbody2D rb;

	// Use this for initialization
	void Awake () 
	{
		character = GetComponent<Character> ();
		rb = GetComponent<Rigidbody2D> ();
		am = GetComponent<AttackMoveset> ();
	}

	void Update ()
	{
		
	}

	public virtual void stopMomentum () 
	{
		rb.velocity = Vector3.zero;
	}

//	public virtual void dashSlow ()
//	{
//		slowToStop (rb.velocity, dashStop.length);
//	}

	public virtual void unlockPlayer ()
	{
		character.actionable = true;
		//character.canMove = true;
	}

	public virtual void turnOffActions ()
	{
		character.actionable = false;
	}

	public virtual void softUnlock ()
	{
		character.actionable = true;
	}

	public virtual void lockPlayer ()
	{
		character.actionable = false;
		//character.canMove = false;
	}

	public virtual void doJump ()
	{
		character.jump (character.jumpSpeed);
	}

//	public virtual void miniJump ()
//	{
//		character.jump (character.jumpSpeed * miniJumpMod);
//	}

	public virtual void doProjectile ()
	{
		character.shoot ();
	}

//	public virtual void turnOffGravity ()
//	{
//		character.affectedByGrav = false;
//		rb.gravityScale = 0;
//		rb.mass = 0;
//	}

//	public virtual void turnOnGravity ()
//	{
//		character.affectedByGrav = true;
//		rb.gravityScale = character.normalGrav;
//		rb.mass = 1;
//	}


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
