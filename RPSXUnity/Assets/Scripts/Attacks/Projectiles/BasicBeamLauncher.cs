using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeamLauncher : ProjectileLauncher {

	public override void fireProjectile (int owner, int directionMod, string state, bool touchingGround)
	{
		direction = new Vector3 (directionMod, 0, 0);
		GameObject beam = Instantiate (projectile) as GameObject;
		beam.GetComponent<Projectile> ().modPos = new Vector3 (directionMod, 0, 0);
		beam.transform.position = transform.position + beam.GetComponent<Projectile>().modPos;
		beam.GetComponent<Projectile> ().state = state;
		beam.GetComponent<Projectile> ().owner = owner;
		beam.GetComponent<Projectile> ().dir = direction;
		if (directionMod == 1) {
			beam.GetComponent<SpriteRenderer> ().flipX = false;
		} else 
		{
			beam.GetComponent<SpriteRenderer> ().flipX = true;
		}
	}
}
