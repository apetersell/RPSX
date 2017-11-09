using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoveset : MonoBehaviour {

	public GameObject hitboxes; 
	public List <Melee> attacks = new List<Melee>();
	public int jabCount;

//	public string moveset; 

	void Awake ()
	{
		hitboxes = this.gameObject.transform.GetChild (6).gameObject;
		for (int i = 0; i < hitboxes.transform.childCount; i++) 
		{
			GameObject hitbox = hitboxes.gameObject.transform.GetChild (i).gameObject;
			attacks.Add (hitbox.GetComponent<Melee> ());
			hitbox.SetActive (false);
		}

	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public Melee getAttack (string name)
	{
		Melee returnAttack = null;
		if (name == "Jab") 
		{
			if (jabCount == 0) 
			{
				returnAttack = attacks[0];
			}
			if (jabCount == 1) 
			{
				returnAttack = attacks [1];
			}
			if (jabCount == 2) 
			{
				returnAttack = attacks [2];
			}
			jabCount++;
		}
		if (name == "ForwardTilt") 
		{
			returnAttack = attacks [3];
		}
		if (name == "UpTilt") 
		{
			returnAttack = attacks [4];
		}
		if (name == "DownTilt") 
		{
			returnAttack = attacks [5];
		}
		if (name == "NeutralAir") 
		{
			returnAttack = attacks [6];
		}
		if (name == "ForwardAir") 
		{
			returnAttack = attacks [7];
		}
		if (name == "BackAir") 
		{
			returnAttack = attacks [8];
		}
		if (name == "UpAir") 
		{
			returnAttack = attacks [9];
		}
		if (name == "DownAir") 
		{
			returnAttack = attacks [10]; 
		}
		if (name == "DashAttack") 
		{
			returnAttack = attacks [11];
		}
			
		return returnAttack;
	}

//	public void doAttack (float stickPosX, float stickPosY, bool grounded, int directionModifier, string state, int owner, Player p)
//	{
//		string playerInput = RPSX.input (stickPosX, stickPosY, directionModifier, grounded, false, false);
//		GameObject attack = Instantiate(Resources.Load("Prefabs/MeleeAttacks/"+ moveset + "/" + playerInput)) as GameObject; 
//		Melee m = attack.GetComponent<Melee> ();
//		if (directionModifier == -1) {
//			attack.transform.localScale = new Vector3 (
//				attack.transform.localScale.x * -1,
//				attack.transform.localScale.y,
//				attack.transform.localScale.z);
//			m.knockBackX = m.knockBackX * -1;
//		}
//		attack.transform.position = p.gameObject.transform.position;
//		m.state = state;
//		m.owner = owner;
//		m.player = p;
//		p.meleeAttack = attack;
//		p.attackDuration = m.duration;
//		m.modPos.x = m.modPos.x * directionModifier;
//
//
//	}
}
