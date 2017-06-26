using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSX : MonoBehaviour {

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

	public static float UIFlashSpeed = 3f;
	public static float playerMaxHP = 100f;

	public static int basicProjectileLimit = 1;
	public static int rockProjectileLimit = 1;
	public static int paperProjectileLimit = 3;
	public static int scissorsProjectileLimit = 5;

	public static float rockThrowSpeed = 12;


	public static string determineWinner (string hero, string villian)
	{
		string result = null;
		if (hero == "Basic" && villian != "Basic") 
		{
			result = "Loss";
		}
		if (hero != "Basic" && villian == "Basic") 
		{
			result = "Win";
		}
		if (hero == villian) 
		{
			result = "Tie";
		}
		if (hero == "Rock") 
		{
			if (villian == "Paper") 
			{
				result = "Loss";
			}

			if (villian == "Scissors")
			{
				result = "Win";
			}
		}

		if (hero == "Paper") 
		{
			if (villian == "Rock") 
			{
				result = "Win";
			}
			if (villian == "Scissors") 
			{
				result = "Loss";
			}
		}
		if (hero == "Scissors") 
		{
			if (villian == "Rock") 
			{
				result = "Loss";
			}

			if (villian == "Paper") 
			{
				result = "Win";
			}

		}

		return result;

	}

	public static float fillAmount (float current, float max)
	{
		float result = current / max;
		return result;
	}

}
