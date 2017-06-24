using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileLauncher : MonoBehaviour {

	public Vector3 direction;
	public GameObject projectile;
	public int ownerNum;

	public void Awake ()
	{
		ownerNum = GetComponent<Player> ().playerNum;
	}

	public abstract void fireProjectile (int owner, int directionMod, string state, bool touchingGround);


}
