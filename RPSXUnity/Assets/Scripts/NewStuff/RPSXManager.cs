using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPSXManager : MonoBehaviour {

	public float maxHP;
	public static float p1HP;
	public static float p2HP;

	// Use this for initialization
	void Start () 
	{
		p1HP = maxHP;
		p2HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Start_P1") || Input.GetButtonDown ("Start_P2")) 
		{
			SceneManager.LoadScene ("Simple");
		}
	}
}
