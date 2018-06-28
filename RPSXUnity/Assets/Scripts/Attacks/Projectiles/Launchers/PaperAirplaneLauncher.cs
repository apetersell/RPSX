using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAirplaneLauncher : ProjectileLauncher {

	public override void fireProjectile (int owner, int directionMod, string state, bool touchingGround)
	{
//		Player p = null;
//		if (owner == 1) 
//		{
//			p = GameObject.Find (RPSX.Player1Name).GetComponent<Player> ();
//		}
//		if (owner == 2) 
//		{
//			p = GameObject.Find (RPSX.Player2Name).GetComponent<Player> ();
//		}
//		float modX = (Input.GetAxis ("LeftStickX_P" + owner));
//		float modY = (Input.GetAxis ("LeftStickY_P" + owner)) * -1;
//		GameObject airplane = null;
//		if (modX == 0 && modY == 0) {
//			modX = directionMod;
//		}
//		if (modY < 0 && touchingGround == true) {
//			modX = directionMod;
//			modY = 0;
//		}
//		if (ProjectilePool.paperPool.Count == 0) {
//			airplane = Instantiate(Resources.Load("Prefabs/Projectiles/PaperAirplanePrefab")) as GameObject;
//		} else {
//			airplane = ProjectilePool.grabFromPool ("Paper");
//		}
//		airplane.GetComponent<Projectile> ().modPos = new Vector3 (modX, modY, 0).normalized;
//		airplane.transform.position = transform.position + airplane.GetComponent<Projectile> ().modPos;
//		airplane.GetComponent<Projectile> ().state = state;
//		airplane.GetComponent<Projectile> ().owner = owner;
//		airplane.GetComponent<Projectile> ().dir = direction;
//		p.startShotDelay (); 
	}
}
