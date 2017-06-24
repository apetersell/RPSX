﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour {

	public static Queue<GameObject> basicPool = new Queue<GameObject> ();
	public static Queue<GameObject> rockPool = new Queue<GameObject> ();
	public static Queue<GameObject> paperPool = new Queue<GameObject> ();
	public static Queue<GameObject> scissorsPool = new Queue<GameObject> ();
	public static List <GameObject> basicOnScreenP1 = new List<GameObject>();
	public static List <GameObject> rockOnScreenP1 = new List <GameObject>();
	public static List <GameObject> paperOnScreenP1 = new List <GameObject>();
	public static List <GameObject> scissorsOnScreenP1 = new List <GameObject>();
	public static List <GameObject> basicOnScreenP2 = new List<GameObject>();
	public static List <GameObject> rockOnScreenP2 = new List <GameObject>();
	public static List <GameObject> paperOnScreenP2 = new List <GameObject>();
	public static List <GameObject> scissorsOnScreenP2 = new List <GameObject>();

	public static GameObject grabFromPool (string type)
	{
		GameObject beam = null;
		if (type == "Basic") 
		{
			beam = basicPool.Dequeue ();
		}

		if (type == "Rock") 
		{
			beam = rockPool.Dequeue ();
		}

		if (type == "Paper") 
		{
			beam = paperPool.Dequeue ();
		}

		if (type == "Scissors") 
		{
			beam = scissorsPool.Dequeue ();
		}
		beam.SetActive (true);
		beam.GetComponent<Projectile> ().resetProjectile ();
		return beam;
	}

	public static void addToPool (GameObject projectile, string type)
	{
		if (type == "Basic") 
		{
			projectile.SetActive (false);
			basicPool.Enqueue (projectile);
		}

		if (type == "Rock") 
		{
			projectile.SetActive (false);
			rockPool.Enqueue (projectile);
		}

		if (type == "Paper") 
		{
			projectile.SetActive (false);
			paperPool.Enqueue (projectile);
		}

		if (type == "Scissors") 
		{
			projectile.SetActive (false);
			scissorsPool.Enqueue (projectile);
		}
	}
}
