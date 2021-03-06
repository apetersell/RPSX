﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinDecider : MonoBehaviour {

	public string p1Win;
	public string p2Win;
	public string tie;
	public string winText;
	public bool itsOver;
	Player player1;
	Player player2;
	public static WinDecider wd;


	// Use this for initialization
	void Start () {
		if (itsOver == false) {
			findPlayers ();
		}
		if (wd == null) {
			wd = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		findPlayers ();
		if (player1 != null && player2 != null) {
			if (player1.HP > player2.HP) {
				winText = p1Win;
			} else if (player2.HP > player1.HP) {
				winText = p2Win;
			} else {
				winText = tie;
			}
		

			if ((player1.HP <= 0 && itsOver == false) || (player2.HP <= 0 && itsOver == false)) {
				itsOver = true;
				changeScene (1);
			}
		}

		if (Input.GetButtonDown ("Start_P1") || Input.GetButtonDown ("Start_P2")) 
		{
			itsOver = false;
			changeScene (2);
		}
	}

	void changeScene(int sent)
	{
		if (sent == 1) 
		{
			SceneManager.LoadScene ("Win Screen");
		}

		if (sent == 2) 
		{
			SceneManager.LoadScene ("TestScene");
		}
		//ProjectilePool.clearPool ("All");
	}

	void findPlayers ()
	{
		if (itsOver == false) 
		{
			player1 = GameObject.Find (RPSX.Player1Name).GetComponent<Player> ();
			player2 = GameObject.Find (RPSX.Player2Name).GetComponent<Player> ();
		}
	}
		
}
