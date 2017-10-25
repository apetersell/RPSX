using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class RoughHiro :Player {

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
		base.Awake ();
	}
	
	// Add animation handler
	public override void Update () 
	{
		handleAnimations ();
		base.Update ();
	}

	public override void applyStats ()
	{
		moveSpeed = rps.moveSpeed;
		airSpeedModifier = rps.airSpeedModifier;
		jumpSpeed = rps.jumpSpeed;
		normalGrav = rps.normalGrav;
		fastFallGrav = rps.fastFallGrav;
		maxAirActions = rps.maxAirActions;
		shieldDiminishRate = rps.shieldDiminishRate;
		if (currentHitStun == 0) 
		{
			foreach (GameObject mesh in meshSkeleton) 
			{
				SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
				smi.color = rps.color;
			}
		} else {
			foreach (GameObject mesh in meshSkeleton) 
			{
				SpriteMeshInstance smi = mesh.GetComponent<SpriteMeshInstance> ();
				smi.color = RPSX.inHitStun;
			}
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
		
	public virtual void handleAnimations ()
	{
		anim.SetBool ("Grounded", touchingGround);
		anim.SetBool ("Shielding", shieldUp);
		anim.SetFloat ("HitStun", currentHitStun);
		anim.SetFloat ("HoriozntaltMovement", rb.velocity.x);
		anim.SetFloat ("VerticalMovement", rb.velocity.y);
	}
}
