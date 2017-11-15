using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour {

	public static Queue<GameObject> basicPool = new Queue<GameObject> ();
	public static Queue<GameObject> rockPool = new Queue<GameObject> ();
	public static Queue<GameObject> paperPool = new Queue<GameObject> ();
	public static Queue<GameObject> scissorsPool = new Queue<GameObject> ();

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
		beam.GetComponent<Projectile> ().reflected = false;
		beam.GetComponent<Projectile> ().hitOpponent.Clear ();
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

	public static void clearPool (string sent)
	{
		if (sent == "Basic") 
		{
			basicPool.Clear ();
		}
		if (sent == "Rock") 
		{
			rockPool.Clear ();
		}
		if (sent == "Paper") 
		{
			paperPool.Clear ();
		}
		if (sent == "Scissors") 
		{
			scissorsPool.Clear ();
		}
		if (sent == "All") 
		{
			basicPool.Clear ();
			rockPool.Clear ();
			paperPool.Clear ();
			scissorsPool.Clear ();
		}
	}
}
