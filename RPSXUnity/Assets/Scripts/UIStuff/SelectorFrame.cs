using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorFrame : MonoBehaviour {

	public int playerNum;
	public string searchFor;
	public Player p;
	public Vector2 rock;
	public Vector2 paper;
	public Vector2 scissors;


	// Use this for initialization
	void Start () {

		if (playerNum == 1) 
		{
			p = GameObject.Find (RPSX.Player1Name).GetComponent<Player> ();
		}
		if (playerNum == 2) 
		{
			p = GameObject.Find (RPSX.Player2Name).GetComponent<Player> ();
		}
		
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
