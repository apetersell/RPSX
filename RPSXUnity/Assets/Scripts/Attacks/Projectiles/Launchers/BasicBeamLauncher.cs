using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeamLauncher : ProjectileLauncher {

	public override void fireProjectile (int owner, int directionMod, string state, bool touchingGround)
	{
		Player p = null;
		if (owner == 1) 
		{
			p = GameObject.Find (RPSX.Player1Name).GetComponent<Player> ();
		}
		if (owner == 2) 
		{
			p = GameObject.Find (RPSX.Player2Name).GetComponent<Player> ();
		}
		float modX = (Input.GetAxis ("LeftStickX_P" + owner));
		float modY = (Input.GetAxis ("LeftStickY_P" + owner)) * -1;
		GameObject beam = null;
		if (modX == 0 && modY == 0) {
			modX = directionMod;
		}
		if (modY < 0 && touchingGround == true) {
			modX = directionMod;
			modY = 0;
		}
		direction = new Vector3 (modX, modY, 0).normalized;
		if (ProjectilePool.basicPool.Count == 0) {
			beam = Instantiate(Resources.Load("Prefabs/Projectiles/BasicBeamPrefab")) as GameObject;
		} else {
			beam = ProjectilePool.grabFromPool ("Basic");
		}
		beam.GetComponent<Projectile> ().modPos = new Vector3 (modX, modY, 0).normalized;
		beam.transform.position = transform.position + beam.GetComponent<Projectile> ().modPos;
		beam.GetComponent<Projectile> ().state = state;
		beam.GetComponent<Projectile> ().owner = owner;
		beam.GetComponent<Projectile> ().dir = direction;
		p.startShotDelay ();
			
	}
}
