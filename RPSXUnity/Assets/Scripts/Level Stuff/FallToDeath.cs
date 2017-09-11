using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeath : MonoBehaviour {

	public Vector3 spawn1;
	public Vector3 spawn2;
	public float fallThreshold;
	GameObject player1;
	GameObject player2;
	public float timerMax;
	public float fallDamage;
	public bool player1Dead = false; 
	public bool player2Dead = false; 
	public float player1ResetTimer;
	public float player2ResetTimer;

	// Use this for initialization
	void Start () {

		player1 = GameObject.Find ("Player_1");
		player2 = GameObject.Find ("Player_2");
		spawn1 = player1.transform.position;
		spawn2 = player2.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		handleRespawn ();
		if (player1.transform.position.y < fallThreshold && player1Dead == false) 
		{
			fallToDeath (player1);
		}
		if (player2.transform.position.y < fallThreshold && player2Dead == false) 
		{
			fallToDeath (player2);
		}

		
	}

	void fallToDeath (GameObject player)
	{
		Player p = player.GetComponent<Player> ();
		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
		p.actionable = false;
		rb.velocity = Vector2.zero;
		rb.isKinematic = true; 
		if (p.playerNum == 1) 
		{
			player1Dead = true;
		}
		if (p.playerNum == 2) 
		{
			player2Dead = true;
		}
	}

	void handleRespawn()
	{
		if (player1Dead == true) 
		{
			player1ResetTimer--;
		}
		if (player1ResetTimer <= 0) 
		{
			player1ResetTimer = timerMax; 
			player1Dead = false;
			respawnPlayer (player1);
		}
		if (player2Dead == true) 
		{
			player2ResetTimer--;
		}
		if (player2ResetTimer <= 0) 
		{
			player2ResetTimer = timerMax; 
			player2Dead = false;
			respawnPlayer (player2);
		}
	}

	void respawnPlayer (GameObject player)
	{
		Player p = player.GetComponent<Player> ();
		player.GetComponent<Rigidbody2D> ().isKinematic = false; 
		p.takeDamage (fallDamage, "Enviornment");
		p.actionable = true;
		if (p.playerNum == 1) 
		{
			player.transform.position = spawn1;
		}
		if (p.playerNum == 2) 
		{
			player.transform.position = spawn2;
		}

	}

//	void OnTriggerEnter2D (Collider2D coll)
//	{
//		if (coll.gameObject.tag == "Player") 
//		{
//			Player p = coll.gameObject.GetComponent<Player> ();
//			p.takeDamage (10, "Basic");
//			if (p.playerNum == 1) 
//			{
//				coll.transform.position = spawn1;
//
//			}
//			if (p.playerNum == 2) 
//			{
//				coll.transform.position = spawn2;
//			}
//		}
//	}
}
