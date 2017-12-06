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
	bool rockBursted = true;
	bool paperBursted = true;
	bool scissorsBursted = true;

	Player p;
	SFXGuy sfx;

	// Use this for initialization
	void Start () {

		p = GetComponent<Player> ();
		rockTime = GameObject.Find ("RockTimer_P" + playerNum).GetComponent<Text> ();
		paperTime = GameObject.Find ("PaperTimer_P" + playerNum).GetComponent<Text> ();
		scissorsTime = GameObject.Find ("ScissorsTimer_P" + playerNum).GetComponent<Text> ();
		rockSign = GameObject.Find ("RockSign P_" + playerNum);
		paperSign = GameObject.Find ("PaperSign P_" + playerNum);
		scissorsSign = GameObject.Find ("ScissorsSign P_" + playerNum);
		sfx = GameObject.Find ("SoundGuy").GetComponent<SFXGuy> ();
		
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
			rockBursted = false;
		}

		if (rps == "Paper") 
		{
			paperOnCooldown = true;
			currentPaperCoolDown = 0;
			paperBursted = false;
		}

		if (rps == "Scissors") 
		{
			scissorsOnCooldown = true;
			currentScissorsCoolDown = 0;
			scissorsBursted = false;
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
			recharge ("Rock");
			rechargeEffect ("Rock");
		}
			
		if (paperOnCooldown) 
		{
			currentPaperCoolDown = currentPaperCoolDown + Time.deltaTime;
			paperTime.text = paperTimeLeft.ToString ();
		}

		if (currentPaperCoolDown >= maxCoolDownTime) 
		{
			recharge ("Paper");
			rechargeEffect ("Paper");
		}	

		if (scissorsOnCooldown) 
		{
			currentScissorsCoolDown = currentScissorsCoolDown + Time.deltaTime;
			scissorsTime.text = scissorTimeLeft.ToString ();
		}

		if (currentScissorsCoolDown >= maxCoolDownTime) 
		{
			recharge ("Scissors");
			rechargeEffect ("Scissors");
		}
	}

	void recharge (string state)
	{
		if (state == "Rock") 
		{
			rockOnCooldown = false;
			statesOnCoolDown.Remove ("Rock");
			rockTime.text = nada;
		}
		if (state == "Paper") 
		{
			paperOnCooldown = false;
			statesOnCoolDown.Remove ("Paper");
			paperTime.text = nada;
		}
		if (state == "Scissors") {
			scissorsOnCooldown = false;
			statesOnCoolDown.Remove ("Scissors");
			scissorsTime.text = nada;
		}
	}

	void rechargeEffect (string state)
	{
		if (state == "Rock") 
		{
			if (!rockBursted) 
			{
				p.particleBurst (RPSX.rockColor, 5);
				sfx.playSFX ("newState");
				rockBursted = true;
			}
		}
		if (state == "Paper") 
		{
			if (!paperBursted) {
				p.particleBurst (RPSX.paperColor, 5);
				sfx.playSFX ("newState");
				paperBursted = true;
			}
		}
		if (state == "Scissors") 
		{
			if (!scissorsBursted) {
				p.particleBurst (RPSX.scissorsColor, 5);
				sfx.playSFX ("newState");
				scissorsBursted = true;
			}
		}

	}
}
