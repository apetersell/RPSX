using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUI : MonoBehaviour {

	public int playerNum;
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
			GetComponent<Image> ().color = RPSX.rockColor;
			currentSign.color = RPSX.rockColor;
			currentSign.sprite = rockSign;
			mask.sprite = rockSign;
			fill.sprite = rockSign;
			fill.color = RPSX.rockColor;
		}
			

		if (p.currentState == "Paper") 
		{
			GetComponent<Image> ().color = RPSX.paperColor;
			currentSign.color =RPSX.paperColor;
			currentSign.sprite = paperSign;
			mask.sprite = paperSign;
			fill.sprite = paperSign;
			fill.color = RPSX.paperColor;
		}
			
		if (p.currentState == "Scissors") 
		{
			GetComponent<Image> ().color = RPSX.scissorsColor;
			currentSign.color = RPSX.scissorsColor;
			currentSign.sprite = scissorsSign;
			mask.sprite = scissorsSign;
			fill.sprite = scissorsSign;
			fill.color = RPSX.scissorsColor;
		}

		if (p.currentState == "Basic") 
		{
			GetComponent<Image> ().color = RPSX.basicColor; 
			currentSign.color = RPSX.basicColor;
			currentSign.sprite = basicSign; 
			mask.sprite = basicSign; 
			fill.sprite = basicSign; 
			fill.color = RPSX.basicColor;
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
