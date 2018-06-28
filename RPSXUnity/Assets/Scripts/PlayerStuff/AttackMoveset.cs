using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoveset : MonoBehaviour {

	public GameObject hitboxes; 
	public Melee ForwardTilt;
	public Melee UpTilt;
	public Melee DownTilt;
	public Melee ForwardAir;
	public Melee BackAir;
	public Melee UpAir;
	public Melee DownAir;
	public int jabCount;

//	public string moveset; 

	void Awake ()
	{
		ForwardTilt = hitboxes.GetComponentInChildren<Melee>();
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

		if (name == "ForwardTilt") 
		{
			returnAttack = ForwardTilt; 
		}
		if (name == "UpTilt") 
		{
			returnAttack = UpTilt; 
		}
		if (name == "DownTilt") 
		{
			returnAttack = DownTilt; 
		}
//		if (name == "NeutralAir") 
//		{
//			returnAttack = 
//		}
		if (name == "ForwardAir") 
		{
			returnAttack = ForwardAir;
		}
		if (name == "BackAir") 
		{
			returnAttack = BackAir;
		}
		if (name == "UpAir") 
		{
			returnAttack = UpAir;
		}
		if (name == "DownAir") 
		{
			returnAttack = DownAir;
		}
//		if (name == "DashAttack") 
//		{
//			returnAttack = attacks [11];
//		}
			
		return returnAttack;
	}
}
