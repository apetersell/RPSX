using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

//	public int playerNum;
//	public int enemyNum;
//	public string result;
//	public Image content;
//	Player owner;
//	Player enemy; 
//	Color lerpingColor;
//	Color color;
//	Color dark;
//
//
//	// Use this for initialization
//	void Start () {
//
//		if (playerNum == 1) 
//		{
//			owner = GameObject.Find (RPSX.Player1Name).GetComponent<Player> ();
//			enemy = GameObject.Find (RPSX.Player2Name).GetComponent<Player> ();
//		}
//		if (playerNum == 2) 
//		{
//			owner = GameObject.Find (RPSX.Player2Name).GetComponent<Player> ();
//			enemy = GameObject.Find (RPSX.Player1Name).GetComponent<Player> ();
//		}
//			
//	}
//	
//	// Update is called once per fram
//	void Update () {
//
//		if (owner.currentState == "Rock") 
//		{
//			color = RPSX.rockColor;
//			dark = RPSX.rockColorDark;
//		}
//		if (owner.currentState == "Paper") 
//		{
//			color = RPSX.paperColor;
//			dark = RPSX.paperColorDark;
//		}
//		if (owner.currentState == "Scissors") 
//		{
//			color = RPSX.scissorsColor;
//			dark = RPSX.scissorsColorDark;
//		}
//		if (owner.currentState == "Basic") 
//		{
//			color = RPSX.basicColor;
//			dark = RPSX.basicColorFaded;
//		}
//
//		lerpingColor = Color.Lerp(color, dark, Mathf.PingPong(Time.time*RPSX.UIFlashSpeed, 1));
//		result = RPSX.determineWinner (owner.currentState, enemy.currentState);
//		if (result == "Win") {
//			content.color = lerpingColor;
//		} 
//		else 
//		{
//			content.color = color;
//		}
//
//		content.fillAmount = RPSX.fillAmount (owner.HP, RPSX.playerMaxHP);
		
//	}
}
