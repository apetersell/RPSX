using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public int playerNum;
	public Color color;
	public Color faded;
	Player p;
	public Image content;
	public Image shieldIcon;
	public Text shieldValue;
	public Sprite fullShield;
	public Sprite brokenShield;


	// Use this for initialization
	void Start () {

		p = GameObject.Find ("Player_" + playerNum).GetComponent<Player> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (p.currentState == "Rock") 
		{
			color = RPSX.rockColor;
			faded = RPSX.rockColorFaded;
		}
		if (p.currentState == "Paper") 
		{
			color = RPSX.paperColor;
			faded = RPSX.paperColorFaded;
		}
		if (p.currentState == "Scissors") 
		{
			color = RPSX.scissorsColor;
			faded = RPSX.scissorsColorFaded;
		}
		if (p.currentState == "Basic") 
		{
			color = RPSX.basicColor;
			faded = RPSX.basicColorFaded;
		}

		if (p.shieldBroken) 
		{
			shieldIcon.sprite = brokenShield;
			content.color = faded;
		} else {
			shieldIcon.sprite = fullShield;
			content.color = color;
		}

		shieldValue.GetComponent<Text> ().text = Mathf.Round (p.currentShieldDuration).ToString ();

		handleFill ();
		
	}

	private float map (float current, float max)
	{
		return current / max;
	}

	void handleFill ()
	{
		content.fillAmount = map (p.currentShieldDuration, p.maxShieldDuration);
	}
		
}
