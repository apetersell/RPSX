using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RPSState : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public float normalGrav;
	public float fastFallGrav;
	public int maxJumps;
	public Color color;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public abstract void airAction ();

}
