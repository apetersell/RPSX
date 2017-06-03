using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCooldowns : MonoBehaviour {

	public int playerNum;
	public float maxCoolDownTime;
	public float currentRockCoolDown;
	public float currentPaperCoolDown;
	public float currentScissorsCoolDown;
	public bool rockOnCooldown;
	public bool paperOnCooldown;
	public bool scissorsOnCooldown;
	GameObject rockSign;
	GameObject paperSign;
	GameObject scissorsSign;

	// Use this for initialization
	void Start () {

		rockSign = GameObject.Find ("RockSign P_" + playerNum);
		paperSign = GameObject.Find ("PaperSign P_" + playerNum);
		scissorsSign = GameObject.Find ("ScissorsSign P_" + playerNum);
		
	}
	
	// Update is called once per frame
	void Update () {
		handleCooldowns ();
		
	}

	public void putStateOnCooldown (string rps)
	{
		if (rps == "Rock") 
		{
			rockOnCooldown = true;
		}

		if (rps == "Paper") 
		{
			paperOnCooldown = true;
		}

		if (rps == "Scissors") 
		{
			scissorsOnCooldown = true;
		}
	}

	void handleCooldowns()
	{
		if (rockOnCooldown) 
		{
			currentRockCoolDown = currentRockCoolDown + Time.deltaTime;
		}

		if (currentRockCoolDown >= maxCoolDownTime) 
		{
			rockOnCooldown = false;
			currentRockCoolDown = 0;
		}
			
		if (paperOnCooldown) 
		{
			currentPaperCoolDown = currentPaperCoolDown + Time.deltaTime;
		}

		if (currentPaperCoolDown >= maxCoolDownTime) 
		{
			paperOnCooldown = false;
			currentPaperCoolDown = 0;
		}	

		if (scissorsOnCooldown) 
		{
			currentScissorsCoolDown = currentScissorsCoolDown + Time.deltaTime;
		}

		if (currentScissorsCoolDown >= maxCoolDownTime) 
		{
			scissorsOnCooldown = false;
			currentScissorsCoolDown = 0;
		}
	}


}
