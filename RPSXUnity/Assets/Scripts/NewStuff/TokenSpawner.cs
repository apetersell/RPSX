using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour {

	public struct TokenInfo
	{
		public RPS_State type; 
		public float time;
	}
	public int numberofTokenPositions;
	public List<Transform> tokenPositions = new List<Transform> ();
	public List<int> occupiedPositions = new List<int> ();
	public Queue<TokenInfo> waiting = new Queue<TokenInfo> ();
	public float minSpawnTime;
	public float maxSpawnTime;
	public float currentSpawnTimer;
	public RPS_State currentType;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < numberofTokenPositions; i++) 
		{
			Transform t = GameObject.Find ("TokenPos_" + i).transform;
			tokenPositions.Add (t);
		}
		queueToken (RPS_State.Rock);
		queueToken (RPS_State.Paper);
		queueToken (RPS_State.Scissors);
		currentType = RPS_State.Basic;

	}
	
	// Update is called once per frame
	void Update () 
	{
		currentSpawnTimer -= Time.deltaTime;
		if (currentSpawnTimer <= 0 && currentType != RPS_State.Basic) 
		{
			spawnToken (currentType);
		}
			
		if (currentType == RPS_State.Basic && waiting.Count > 0) 
		{
			TokenInfo ti = waiting.Dequeue();
			currentType = ti.type;
			currentSpawnTimer = ti.time;
		}
	}

	void spawnToken (RPS_State type)
	{
		int rando = Random.Range (0, tokenPositions.Count);
		if (!occupiedPositions.Contains (rando)) {
			Transform t = tokenPositions [rando];
			string tokenType = null;
			switch (type) {
			case RPS_State.Rock:
				tokenType = "Rock";
				break;
			case RPS_State.Paper:
				tokenType = "Paper";
				break;
			case RPS_State.Scissors:
				tokenType = "Scissors";
				break;
			}
			GameObject newToken = Instantiate (Resources.Load ("Prefabs/Tokens/Token_" + tokenType)) as GameObject;
			newToken.transform.position = t.position;
			newToken.GetComponent<Token> ().spawner = this;
			newToken.GetComponent<Token> ().position = rando;
			occupiedPositions.Add (rando);
			currentType = RPS_State.Basic;
		} else {
			spawnToken (type);
		}
	}

	public void queueToken (RPS_State type)
	{
		TokenInfo newToken;
		float time = Random.Range (minSpawnTime, maxSpawnTime);
		newToken.time = time;
		newToken.type = type;
		waiting.Enqueue (newToken);
	}
}
