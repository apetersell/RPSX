using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorFrame : MonoBehaviour {

	public int playerNum;
	public Player p;
	public Vector2 rock;
	public Vector2 paper;
	public Vector2 scissors;


	// Use this for initialization
	void Start () {

		p = GameObject.Find ("Player_" + playerNum).GetComponent<Player> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (p.selectedState == "Rock") 
		{
			transform.localPosition = rock;
		}

		if (p.selectedState == "Paper") 
		{
			transform.localPosition = paper;
		}

		if (p.selectedState == "Scissors") 
		{
			transform.localPosition = scissors;
		}

		
	}
}
