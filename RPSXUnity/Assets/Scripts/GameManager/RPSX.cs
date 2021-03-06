﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RPS_State 
{
	Basic = 0,
	Rock = 1,
	Paper = 2,
	Scissors = 3
}

public enum RPS_Result
{
	Tie = 0,
	Win = 1,
	Loss = 2
}

public class RPSX : MonoBehaviour {

	public static string Player1Name = "RoughHiro";
	public static string Player2Name = "RoughHiro2";

	public static Color rockColor = new Color (0, 1f, 0f);
	public static Color rockColorFaded = new Color (0.54f, 0.7f, 0.5f, 0.5f);
	public static Color rockColorDark = new Color (0f, 0.44f, 0.03f); 
	public static Color paperColor = new Color (0.42f, 0.87f, 1f);
	public static Color paperColorFaded = new Color (0.42f, 0.71f, 1f, 0.5f);
	public static Color paperColorDark = new Color (0.2f, 0.48f, 0.56f); 
	public static Color scissorsColor = new Color (1f, 0.21f, 0.21f);
	public static Color scissorsColorFaded = new Color (1f, 0.56f, 0.56f, 0.5f);
	public static Color scissorsColorDark = new Color (0.37f, 0f, 0f); 
	public static Color basicColor = new Color (1f,1f,1f);
	public static Color basicColorFaded = new Color (1f,1f,1f,0.5f);
	public static Color alphadOut = new Color (0f, 0f, 0f, 0f);
	public static Color inHitStun = new Color (0f, 0f, 0f);
	public static Color inBounceStun = new Color (74f, 0f, 107f);

	public static float UIFlashSpeed = 3f;
	public static float playerMaxHP = 20f;

	public static float maxShieldDuration = 25f;

	public static float rockThrowSpeed = 12;

	public static string playerName (int playerNum)
	{
		string result = "";
		if (playerNum == 1) {
			result = Player1Name;
		} else {
			result = Player2Name;
		}
		return result;
	}

	public static RPS_Result determineWinner (RPS_State hero, RPS_State villian)
	{
		RPS_Result result = RPS_Result.Tie;
		if (hero == RPS_State.Basic && villian != RPS_State.Basic) 
		{
			result = RPS_Result.Loss;
		}
		if (hero != RPS_State.Basic && villian == RPS_State.Basic) 
		{
			result = RPS_Result.Win;
		}
		if (hero == villian) 
		{
			result = RPS_Result.Tie;
		}
		if (hero == RPS_State.Rock) 
		{
			if (villian == RPS_State.Paper) 
			{
				result = RPS_Result.Loss;
			}

			if (villian == RPS_State.Scissors)
			{
				result = RPS_Result.Win;
			}
		}

		if (hero == RPS_State.Paper) 
		{
			if (villian == RPS_State.Rock) 
			{
				result = RPS_Result.Win;
			}
			if (villian == RPS_State.Scissors) 
			{
				result = RPS_Result.Loss;
			}
		}
		if (hero == RPS_State.Scissors) 
		{
			if (villian == RPS_State.Rock) 
			{
				result = RPS_Result.Loss;
			}

			if (villian == RPS_State.Paper) 
			{
				result = RPS_Result.Win;
			}

		}

		return result;

	}

	public static string input (float x, float y, int dir, bool grounded, bool running, bool crouching)
	{
		string result = null; 
		if (grounded) 
		{
			if (x == 0 && y == 0) {
				result = "ForwardTilt";
			}
			if (Mathf.Abs (x) > Mathf.Abs (y)) 
			{
				result = "ForwardTilt";
			}
			if ((Mathf.Abs (x) < Mathf.Abs (y)) && y > 0) {
				result = "DownTilt"; 
			} 
			if ((Mathf.Abs (x) < Mathf.Abs (y)) && y < 0) {
				result = "UpTilt"; 
			}
		} 
		else 
		{
			if (x == 0 && y == 0) {
				result = "ForwardAir";
			}
			if (Mathf.Abs (x) > Mathf.Abs (y)) 
			{
				if ((x > 0 && dir > 0) || (x < 0 && dir < 0)) {
					result = "ForwardAir";
				}
				else {
					result = "BackAir";
				}
			}
			if ((Mathf.Abs (x) < Mathf.Abs (y)) && y > 0) {
				result = "DownAir"; 
			}
			if ((Mathf.Abs (x) < Mathf.Abs (y)) && y < 0) {
				result = "UpAir"; 
			}
		}
		return result;
	}

	public static float fillAmount (float current, float max)
	{
		float result = current / max;
		return result;
	}

	public static int opponentNum (int playerNum)
	{
		int result = 0;
		if (playerNum == 1) 
		{
			result = 2;
		}

		if (playerNum == 2) 
		{
			result = 1;
		}

		return result;
	}

}
