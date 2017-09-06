using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeath : MonoBehaviour {

	public Vector3 spawn1;
	public Vector3 spawn2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			Player p = coll.gameObject.GetComponent<Player> ();
			p.takeDamage (10, "Basic");
			if (p.playerNum == 1) 
			{
				coll.transform.position = spawn1;

			}
			if (p.playerNum == 2) 
			{
				coll.transform.position = spawn2;
			}
		}
	}
}
