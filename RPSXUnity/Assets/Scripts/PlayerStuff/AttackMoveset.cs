﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoveset : MonoBehaviour {

	public GameObject hitboxes; 
	public Attack ForwardTilt;
	public Attack UpTilt;
	public Attack DownTilt;
	public Attack ForwardAir;
	public Attack BackAir;
	public Attack UpAir;
	public Attack DownAir;
	public int jabCount;

//	public string moveset; 

	void Awake ()
	{
		ForwardTilt = hitboxes.transform.GetChild (0).gameObject.GetComponent<Attack> ();
		UpTilt = hitboxes.transform.GetChild (1).gameObject.GetComponent<Attack> ();
		DownTilt = hitboxes.transform.GetChild (2).gameObject.GetComponent<Attack> ();
		ForwardAir = hitboxes.transform.GetChild (3).gameObject.GetComponent<Attack> ();
		BackAir = hitboxes.transform.GetChild (4).gameObject.GetComponent<Attack> ();
		DownAir = hitboxes.transform.GetChild (5).gameObject.GetComponent<Attack> ();
		UpAir = hitboxes.transform.GetChild (6).gameObject.GetComponent<Attack> ();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public Attack getAttack (string name)
	{
		Attack returnAttack = null; 

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
