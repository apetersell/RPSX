using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

	public RPS_State type;
	public TokenSpawner spawner;
	public int position;
	static float inactiveTime = 3f;
	float current;
	bool active = false;

	// Use this for initialization
	void Start () 
	{
		current = inactiveTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		current -= Time.deltaTime;
		if (current <= 0) 
		{
			active = true;
		}
		GetComponent<BoxCollider2D> ().enabled = active;
		if (active) {
			GetComponent<SpriteRenderer> ().color = Color.white;
		} else {
			GetComponent<SpriteRenderer> ().color = RPSX.basicColorFaded;
		}
	}

	public void collect ()
	{
		spawner.occupiedPositions.Remove (position);
		spawner.queueToken (type);
		Destroy (this.gameObject);
	}
}
