using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicState : RPSState {

	// Use this for initialization
	void Start () {

		moveSpeed = 5;
		jumpSpeed = 30;
		normalGrav = 6;
		fastFallGrav = 12;
		maxJumps = 1;
		color = Color.white;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void airAction ()
	{
		Debug.Log ("Basic State Air Action Does Nothing");
	}
}
