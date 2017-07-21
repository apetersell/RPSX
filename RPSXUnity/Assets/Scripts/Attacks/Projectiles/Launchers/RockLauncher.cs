using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : ProjectileLauncher {

	public bool holdingRock;
	public GameObject currentRock; 

	public override void fireProjectile (int owner, int directionMod, string state, bool touchingGround)
	{
		if (holdingRock && currentRock != null) 
		{
			Rigidbody2D rb = currentRock.GetComponent<Rigidbody2D> ();
			float throwDirX = Input.GetAxis ("LeftStickX_P" + owner) * RPSX.rockThrowSpeed;
			if (throwDirX > 0 && throwDirX < 0.8f) 
			{
				throwDirX = 0.8f;
			}
			if (throwDirX < 0 && throwDirX > -0.8f)
			{
				throwDirX = -0.8f;
			}
			float throwDirY = (Input.GetAxis ("LeftStickY_P" + owner) * -1) * RPSX.rockThrowSpeed;
			if (throwDirY < 0.6f) 
			{
				throwDirY = 0.6f;
			}
			Vector2 direction = new Vector2 (throwDirX, throwDirY);
			rb.AddForce (direction, ForceMode2D.Impulse);
			currentRock.GetComponent<RockThrow> ().beingHeld = false;
			currentRock.GetComponent<Rigidbody2D> ().velocity = direction;
			Player p = GameObject.Find ("Player_" + ownerNum).GetComponent<Player> ();
			p.startShotDelay ();
			currentRock = null;
			p.GetComponent<Player> ().heldRock = null;
				
		} 
		else 
		{
			GameObject p = GameObject.Find ("Player_" + ownerNum);   
			if (ProjectilePool.rockPool.Count == 0) { 
				currentRock = Instantiate(Resources.Load("Prefabs/Projectiles/RockThrowPrefab")) as GameObject; 
			} 
			else 
			{
				currentRock = ProjectilePool.grabFromPool ("Rock");  
			}
			currentRock.transform.position = transform.position + currentRock.GetComponent<Projectile> ().modPos;

			holdingRock = true; 
			if (currentRock != null) 
			{
				currentRock.GetComponent<Projectile> ().state = state;
				currentRock.GetComponent<Projectile> ().owner = owner;
				currentRock.GetComponent<RockThrow> ().beingHeld = true; 
				p.GetComponent<Player> ().heldRock = currentRock; 
			}

		}


	}
}
