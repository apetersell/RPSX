using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoveset : MonoBehaviour {

	public string moveset; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void doAttack (float stickPosX, float stickPosY, bool grounded, int directionModifier, string state, int owner, Player p)
	{
		string playerInput = RPSX.input (stickPosX, stickPosY, directionModifier, grounded, false, false);
		GameObject attack = Instantiate(Resources.Load("Prefabs/MeleeAttacks/"+ moveset + "/" + playerInput)) as GameObject; 
		Melee m = attack.GetComponent<Melee> ();
		if (directionModifier == -1) {
			attack.transform.localScale = new Vector3 (
				attack.transform.localScale.x * -1,
				attack.transform.localScale.y,
				attack.transform.localScale.z);
			m.knockBackX = m.knockBackX * -1;
		}
		attack.transform.position = p.gameObject.transform.position;
		m.state = state;
		m.owner = owner;
		m.player = p;
		p.meleeAttack = attack;
		p.attackDuration = m.duration;
		m.modPos.x = m.modPos.x * directionModifier;


	}
}
