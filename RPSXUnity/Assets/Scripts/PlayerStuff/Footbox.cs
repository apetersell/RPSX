using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footbox : MonoBehaviour {

	public Player p;

	void Awake () 
	{
		p = GetComponentInParent<Player> ();
	}
	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
		//Reset Jumps upon touching ground
		if (coll.gameObject.tag == "Floor") 
		{
			p.touchingGround = true; 
			p.bounceStun = 0;
			p.canAirShield = 1;
		}
	}


	public virtual void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Floor") 
		{
			p.touchingGround = false; 
		}
	}
}