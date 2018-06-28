using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RPSXManager : MonoBehaviour {

	public static float p1HP;
	public static float p2HP;
	public float displayP1;
	public float displayP2;
	public Image p1HPMeter;
	public Image p2HPMeter;

	// Use this for initialization
	void Start () 
	{
		p1HP = RPSX.playerMaxHP;
		p2HP = RPSX.playerMaxHP;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Start_P1") || Input.GetButtonDown ("Start_P2")) 
		{
			SceneManager.LoadScene ("Simple");
		}

		displayP1 = p1HP;
		displayP2 = p2HP;

		handleMeterFill ();
	}

	void handleMeterFill ()
	{
		p1HPMeter.fillAmount = p1HP / RPSX.playerMaxHP;
		p2HPMeter.fillAmount = p2HP / RPSX.playerMaxHP;
	}

	public static void takeDamage (int sent, float damage)
	{
		if (sent == 1) 
		{
			p1HP -= damage;
		}

		if (sent == 2) {
			p2HP -= damage;
		}
	}
}
