using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLauncher : ProjectileLauncher {

	public override void fireProjectile (int owner, int directionMod, string state, bool touchingGround)
	{
//		float modX = (Input.GetAxis ("LeftStickX_P" + owner));
//		float modY = (Input.GetAxis ("LeftStickY_P" + owner)) * -1;
//		GameObject beam = null;
//		if (modX == 0 && modY == 0) {
//			modX = directionMod;
//		}
//		if (modY < 0 && touchingGround == true) {
//			modX = directionMod;
//			modY = 0;
//		}
//		direction = new Vector3 (modX, modY, 0).normalized;
//		StartCoroutine (delayShot (owner, modX, modY, state));
//		

	}

//	IEnumerator delayShot (int owner, float modX, float modY, string state)
//	{
//		shootScissor (owner, modX, modY, state);
//		yield return new WaitForSeconds (0.1f);
//		shootScissor (owner, modX, modY, state);
//		yield return new WaitForSeconds (0.1f);
//		shootScissor (owner, modX, modY, state);
//	}
//
//
//	public void shootScissor (int owner, float modX, float modY, string state)
//	{
//		GameObject p = GameObject.Find ("Player_" + ownerNum);
//		GameObject scissor = null;
//		if (ProjectilePool.scissorsPool.Count == 0) {
//			scissor = Instantiate(Resources.Load("Prefabs/Projectiles/ScissorShotPrefab")) as GameObject;
//		} else {
//			scissor = ProjectilePool.grabFromPool ("Scissors");
//		}
//		scissor.GetComponent<Projectile> ().modPos = new Vector3 (modX, modY, 0).normalized;
//		scissor.transform.position = transform.position + scissor.GetComponent<Projectile> ().modPos;
//		scissor.GetComponent<Projectile> ().state = state;
//		scissor.GetComponent<Projectile> ().owner = owner;
//		scissor.GetComponent<Projectile> ().dir = direction;
//	}

}