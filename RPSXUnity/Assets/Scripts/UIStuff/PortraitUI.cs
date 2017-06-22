using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUI : MonoBehaviour {

	public int playerNum;
	public Color color;
	public Color dark;
	public Color lerpingColor;
	public Sprite basicSign;
	public Sprite rockSign;
	public Sprite paperSign;
	public Sprite scissorsSign;
	Player p;
	HealthBarUI hb;

	public Image currentSign;
	public Image mask;
	public Image fill;
	public Image healthBar;


	// Use this for initialization
	void Start () {

		p = GameObject.Find ("Player_" + playerNum).GetComponent<Player> ();
		hb = healthBar.GetComponent<HealthBarUI> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		handleFill ();
		lerpingColor = Color.Lerp(color, dark, Mathf.PingPong(Time.time*RPSX.UIFlashSpeed, 1));


		GetComponent<Image>().color = color;
		if (hb.result == "Win") 
		{
			currentSign.color = lerpingColor;
			fill.color = lerpingColor;
		} 
		else 
		{
			currentSign.color = color;
			fill.color = color;
		}

		if (p.currentState == "Rock") 
		{
			color = RPSX.rockColor;
			dark = RPSX.rockColorDark;
			currentSign.sprite = rockSign;
			mask.sprite = rockSign;
			fill.sprite = rockSign;
		}
			

		if (p.currentState == "Paper") 
		{
			color = RPSX.paperColor;
			dark = RPSX.paperColorDark;
			currentSign.sprite = paperSign;
			mask.sprite = paperSign;
			fill.sprite = paperSign;
		}
			
		if (p.currentState == "Scissors") 
		{
			color = RPSX.scissorsColor;
			dark = RPSX.scissorsColorDark;
			currentSign.sprite = scissorsSign;
			mask.sprite = scissorsSign;
			fill.sprite = scissorsSign;
		}

		if (p.currentState == "Basic") 
		{
			color = RPSX.basicColor;
			dark = RPSX.basicColor;
			currentSign.sprite = basicSign; 
			mask.sprite = basicSign; 
			fill.sprite = basicSign; 
		}
		
	}

	void handleFill()
	{
		fill.fillAmount = RPSX.fillAmount (p.currentTimeinState, p.maxTimeinState);
	}
}
