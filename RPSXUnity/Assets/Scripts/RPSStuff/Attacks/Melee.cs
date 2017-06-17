using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Melee : Attack {

	void Awake () {
		projectile = false;
	}

	public abstract void doMelee ();
	public abstract void doAirMelee ();
}
