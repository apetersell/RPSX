﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : ProjectileLauncher {

	public bool holdingRock;
	public GameObject currentRock; 
	public ProjectileLimit pl;

	public override void fireProjectile (int owner, int directionMod, string state, bool touchingGround)
	{
		if (holdingRock && currentRock != null) 
		{
			holdingRock = false;
			float modX = (Input.GetAxis ("LeftStickX_P" + owner));
			float modY = (Input.GetAxis ("LeftStickY_P" + owner)) * -1;
			if (modX == 0 && modY == 0) 
			{
				modX = directionMod;
			}
			if (modY < 0 && touchingGround == true) {
				modX = directionMod;
				modY = 0;
			}
			direction = new Vector3 (modX, modY, 0).normalized;
			currentRock.GetComponent<RockThrow> ().beingHeld = false;
			currentRock.GetComponent<Projectile> ().dir = direction;
			currentRock = null;
				
		} 
		else 
		{
			GameObject p = GameObject.Find ("Player_" + ownerNum);   
			pl = p.GetComponent<ProjectileLimit> ();
			if (pl.rockOnScreen.Count < RPSX.rockProjectileLimit) 
			{
				if (ProjectilePool.rockPool.Count == 0) { 
					currentRock = Instantiate (projectile) as GameObject;  
				} 
				else 
				{
					currentRock = ProjectilePool.grabFromPool ("Rock");  
				}
				currentRock.transform.position = transform.position + currentRock.GetComponent<Projectile> ().modPos;
			}
			holdingRock = true; 
			if (currentRock != null) 
			{
				currentRock.GetComponent<Projectile> ().state = state;
				currentRock.GetComponent<Projectile> ().owner = owner;
				currentRock.GetComponent<RockThrow> ().beingHeld = true; 
				pl.addToList (currentRock.gameObject, state); 
			}

		}


	}
}