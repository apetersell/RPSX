using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUI : MonoBehaviour {

	public int playerNum;
	public Color basic;
	public Color rock;
	public Color paper;
	public Color scissors; 
	public Sprite basicSign;
	public Sprite rockSign;
	public Sprite paperSign;
	public Sprite scissorsSign;
	Player p;

	public Image currentSign;
	public Image mask;
	public Image fill;


	// Use this for initialization
	void Start () {

		p = GameObject.Find ("Player_" + playerNum).GetComponent<Player> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		handleFill ();

		if (p.currentState == "Rock") 
		{
			GetComponent<Image> ().color = rock;
			currentSign.sprite = rockSign;
			mask.sprite = rockSign;
			fill.sprite = rockSign;
			fill.color = rock;
		}
			

		if (p.currentState == "Paper") 
		{
			GetComponent<Image> ().color = paper;
			currentSign.color = paper;
			currentSign.sprite = paperSign;
			mask.sprite = paperSign;
			fill.sprite = paperSign;
			fill.color = paper;
		}
			
		if (p.currentState == "Scissors") 
		{
			GetComponent<Image> ().color = scissors;
			currentSign.color = scissors;
			currentSign.sprite = scissorsSign;
			mask.sprite = scissorsSign;
			fill.sprite = scissorsSign;
			fill.color = scissors;
		}

		if (p.currentState == "Basic") 
		{
			GetComponent<Image> ().color = basic; 
			currentSign.color = basic;
			currentSign.sprite = basicSign; 
			mask.sprite = basicSign; 
			fill.sprite = basicSign; 
			fill.color = basic;
		}
		
	}

	private float map (float current, float max)
	{
		return current / max;
	}

	void handleFill()
	{
		fill.fillAmount = map (p.currentTimeinState, p.maxTimeinState);
	}
}
