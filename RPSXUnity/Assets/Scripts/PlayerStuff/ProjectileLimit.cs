using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLimit : MonoBehaviour {

	public List<GameObject> basicOnScreen = new List<GameObject>();
	public List<GameObject> rockOnScreen = new List<GameObject>();
	public List<GameObject> paperOnScreen = new List<GameObject>();
	public List<GameObject> scissorsOnScreen = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void addToList (GameObject projectile, string state)
	{
		if (state == "Basic") 
		{
			basicOnScreen.Add (projectile);
		}

		if (state == "Rock") 
		{
			rockOnScreen.Add (projectile);
		}

		if (state == "Paper") 
		{
			paperOnScreen.Add (projectile);
		}

		if (state == "Scissors") 
		{
			scissorsOnScreen.Add (projectile);
		}
	}

	public void removeFromList(GameObject projectile, string state)
	{
		if (state == "Basic") 
		{
			basicOnScreen.Remove (projectile);
		}

		if (state == "Rock") 
		{
			rockOnScreen.Remove (projectile);
		}

		if (state == "Paper") 
		{
			paperOnScreen.Remove (projectile);
		}

		if (state == "Scissors") 
		{
			scissorsOnScreen.Remove (projectile);
		}
	}
		
}
