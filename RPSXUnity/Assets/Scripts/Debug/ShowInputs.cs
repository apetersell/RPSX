using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInputs : MonoBehaviour {

	public int playerNum;
	public bool aButton;
	public bool bButton;
	public bool xButton;
	public bool yButton;
	public bool rightBumper;
	public bool leftBumper;
	public float leftTrigger;
	public float rightTrigger;
	public Vector2 leftStick;
	public Vector2 rightStick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("AButton_P" + playerNum))
		{
			aButton = true;
		}

		if (Input.GetButtonUp ("AButton_P" + playerNum)) 
		{
			aButton = false;
		}

		if (Input.GetButtonDown("BButton_P" + playerNum))
		{
			bButton = true;
		}

		if (Input.GetButtonUp ("BButton_P" + playerNum)) 
		{
			bButton = false;
		}

		if (Input.GetButtonDown("XButton_P" + playerNum))
		{
			xButton = true;
		}

		if (Input.GetButtonUp ("XButton_P" + playerNum)) 
		{
			xButton = false;
		}

		if (Input.GetButtonDown("YButton_P" + playerNum))
		{
			yButton = true;
		}

		if (Input.GetButtonUp ("YButton_P" + playerNum)) 
		{
			yButton = false;
		}

		if (Input.GetButtonDown("RBumper_P" + playerNum))
		{
			rightBumper = true;
		}

		if (Input.GetButtonUp ("RBumper_P" + playerNum)) 
		{
			rightBumper = false;
		}

		if (Input.GetButtonDown("LBumper_P" + playerNum))
		{
			leftBumper = true;
		}

		if (Input.GetButtonUp ("LBumper_P" + playerNum)) 
		{
			leftBumper = false;
		}

		leftTrigger = Input.GetAxis ("LTrigger_P" + playerNum);
		rightTrigger = Input.GetAxis ("RTrigger_P" + playerNum);
		rightStick = new Vector2 (Input.GetAxis ("RightStickX_P" + playerNum), (Input.GetAxis ("RightStickY_P" + playerNum))*-1);
		leftStick = new Vector2 (Input.GetAxis ("LeftStickX_P" + playerNum), (Input.GetAxis ("LeftStickY_P" + playerNum))*-1);
	}
}
