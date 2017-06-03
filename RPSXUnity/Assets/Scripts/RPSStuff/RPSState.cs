using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RPSState : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public float normalGrav;
	public float fastFallGrav;
	public float airSpeedModifier;
	public int maxAirActions;
	public Color color;
	public Player p;

	// Use this for initialization
	void Awake () {

		p = GetComponent<Player> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public abstract void airAction ();

}
