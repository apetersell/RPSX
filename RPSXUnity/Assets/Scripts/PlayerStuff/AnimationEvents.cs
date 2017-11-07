using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class AnimationEvents : MonoBehaviour 
{
	public Player player;
	public float miniJumpMod;
	public AnimationClip dashStop; 
	Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		player = GetComponent<Player> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	public virtual void stopMomentum () 
	{
		rb.velocity = Vector3.zero;
	}

	public virtual void dashSlow ()
	{
		slowToStop (rb.velocity, dashStop.length);
	}

	public virtual void unlockPlayer ()
	{
		player.actionable = true;
		player.canMove = true;
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
