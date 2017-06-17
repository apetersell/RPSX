using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : Attack {

	void Awake () {
		projectile = true;
	}

	public abstract void fireProjectile ();
	public abstract void fireAirProjectile ();
}
