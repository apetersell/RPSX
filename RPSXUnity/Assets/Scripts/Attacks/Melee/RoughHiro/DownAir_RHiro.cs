using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAir_RHiro : Melee {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public override void hitShield (Player p)
	{
		Debug.Log ("DAIR HIT SHEILD");
		AnimationEvents ae = GetComponentInParent<AnimationEvents> ();
		ae.turnOnGravity ();
		ae.stopMomentum ();
		ae.endDair ();
		base.hitShield (p);
	}
}
