using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateCooldowns : MonoBehaviour {

	public int playerNum;
	public float maxCoolDownTime;
	public float currentRockCoolDown;
	public float currentPaperCoolDown;
	public float currentScissorsCoolDown;
	float rockTimeLeft;
	float paperTimeLeft;
	float scissorTimeLeft;
	public bool rockOnCooldown;
	public bool paperOnCooldown;
	public bool scissorsOnCooldown;
	public List <string> statesOnCoolDown;
	GameObject rockSign;
	GameObject paperSign;
	GameObject scissorsSign;
	public Text rockTime;
	public Text paperTime;
	public Text scissorsTime;
	string nada = "";

	// Use this for initialization
	void Start () {

		rockTime = GameObject.Find ("RockTimer_P" + playerNum).GetComponent<Text> ();
		paperTime = GameObject.Find ("PaperTimer_P" + playerNum).GetComponent<Text> ();
		scissorsTime = GameObject.Find ("ScissorsTimer_P" + playerNum).GetComponent<Text> ();
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
			currentScissorsCoolDown = maxCoolDownTime;
		}

		rockTimeLeft = Mathf.RoundToInt (maxCoolDownTime - currentRockCoolDown);
		paperTimeLeft = Mathf.RoundToInt (maxCoolDownTime - currentPaperCoolDown);
		scissorTimeLeft = Mathf.RoundToInt (maxCoolDownTime - currentScissorsCoolDown);
	}

	public void putStateOnCooldown (string rps)
	{

		if (rps != "Basic") 
		{
			statesOnCoolDown.Add (rps);
		}
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
			rockTime.text = rockTimeLeft.ToString ();
		}

		if (currentRockCoolDown >= maxCoolDownTime) 
		{
			rockOnCooldown = false;
			statesOnCoolDown.Remove ("Rock");
			rockTime.text = nada;
		}
			
		if (paperOnCooldown) 
		{
			currentPaperCoolDown = currentPaperCoolDown + Time.deltaTime;
			paperTime.text = paperTimeLeft.ToString ();
		}

		if (currentPaperCoolDown >= maxCoolDownTime) 
		{
			paperOnCooldown = false;
			statesOnCoolDown.Remove ("Paper");
			paperTime.text = nada;
		}	

		if (scissorsOnCooldown) 
		{
			currentScissorsCoolDown = currentScissorsCoolDown + Time.deltaTime;
			scissorsTime.text = scissorTimeLeft.ToString ();
		}

		if (currentScissorsCoolDown >= maxCoolDownTime) 
		{
			scissorsOnCooldown = false;
			statesOnCoolDown.Remove ("Scissors");
			scissorsTime.text = nada;
		}
	}


}
