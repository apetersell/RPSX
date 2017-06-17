using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {

	public Player p;
	public string state;
	public int owner;
	public float damage;
	public float lifeSpan;
	public bool projectile;

	// Use this for initialization
	void Awake () {

		p = GetComponent<Player> ();

	}
}
