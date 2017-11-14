using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jab_Basic : Melee {
	public int nextJab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {

		base.Update ();
		if (Input.GetButtonDown ("XButton_P" + owner)) 
		{
			if (nextJab <= 3) 
			{
				GameObject jab = Instantiate (Resources.Load ("Prefabs/MeleeAttacks/Test/Jab " + nextJab)) as GameObject; 
				Melee j = jab.GetComponent<Melee> ();
				if (player.directionModifier == -1) {
					jab.transform.localScale = new Vector3 (
						jab.transform.localScale.x * -1,
						jab.transform.localScale.y,
						jab.transform.localScale.z);
					j.knockBackX = j.knockBackX * -1;
				}
				jab.transform.position = player.gameObject.transform.position;
				j.state = state;
				j.owner = owner;
				j.player = player;
//				player.meleeAttack = jab;
//				player.attackDuration = j.duration;
				j.modPos.x = j.modPos.x * player.directionModifier;
				Destroy (this.gameObject);
			}

		}
		
	}
}
