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
	public List <string> statesOnCoolDown;
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
		if (currentRockCoolDown > maxCoolDownTime) 
		{
			currentRockCoolDown = maxCoolDownTime;
		}
		if (currentPaperCoolDown > maxCoolDownTime) 
		{
			currentPaperCoolDown = maxCoolDownTime;
		}
		if (currentScissorsCoolDown > maxCoolDownTime) 
		{
			currentRockCoolDown = maxCoolDownTime;
		}
	}

	public void putStateOnCooldown (string rps)
	{

		statesOnCoolDown.Add (rps);
		if (rps == "Rock") 
		{
			rockOnCooldown = true;
			currentRockCoolDown = 0;
		}

		if (rps == "Paper") 
		{
			paperOnCooldown = true;
			currentPaperCoolDown = 0;
		}

		if (rps == "Scissors") 
		{
			scissorsOnCooldown = true;
			currentScissorsCoolDown = 0;
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
			statesOnCoolDown.Remove ("Rock");
		}
			
		if (paperOnCooldown) 
		{
			currentPaperCoolDown = currentPaperCoolDown + Time.deltaTime;
		}

		if (currentPaperCoolDown >= maxCoolDownTime) 
		{
			paperOnCooldown = false;
			statesOnCoolDown.Remove ("Paper");
		}	

		if (scissorsOnCooldown) 
		{
			currentScissorsCoolDown = currentScissorsCoolDown + Time.deltaTime;
		}

		if (currentScissorsCoolDown >= maxCoolDownTime) 
		{
			scissorsOnCooldown = false;
			statesOnCoolDown.Remove ("Scissors");
		}
	}


}
