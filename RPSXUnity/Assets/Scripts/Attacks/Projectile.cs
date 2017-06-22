using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : Attack {

	void Awake () {
		projectile = true;
	}

//	public void OnTriggerEnter2D (Collider2D coll)
//	{
//		Player opponent = coll.gameObject.GetComponent<Player> ();
//		Projectile proj = coll.gameObject.GetComponent<Projectile> ();
//		if (proj != null) 
//		{
//			string result = RPSX.determineWinner (state, proj.state);
//			if (result == "Win") 
//			{
//				Destroy (coll.gameObject);
//			}
//			if (result == "Loss") 
//			{
//				Destroy (this);
//			}
//			if (result == "Tie") 
//			{
//				Destroy (coll.gameObject);
//				Destroy (this);
//			}
//		}
//
//	}

	public abstract void fireProjectile ();
	public abstract void fireAirProjectile ();
}
