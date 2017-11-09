using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryHitbox : Melee 
{
	Melee mainHitbox;

	void Start ()
	{
		mainHitbox = transform.parent.gameObject.GetComponent<Melee> ();
	}
	void Update ()
	{
		state = mainHitbox.state;
		directionMod = mainHitbox.directionMod;
		owner = mainHitbox.owner;
		hitOpponent = mainHitbox.hitOpponent;
	}
}
