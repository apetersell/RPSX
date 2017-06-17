using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSelector : MonoBehaviour {

	public int playerNum;
	public Sprite rock;
	public Sprite paper;
	public Sprite scissors;
	public Color lerpingRock;
	public Color lerpingPaper;
	public Color lerpingScissors;
	public float lerpSpeed;
	public float timer;
	public float timerMax; 
	public bool visible;
	GameObject player;
	Player p;
	StateCooldowns sc;
	SpriteRenderer sr;



	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player_" + playerNum);
		p = player.GetComponent<Player> ();
		sc = player.GetComponent<StateCooldowns> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		lerpingRock = Color.Lerp(RPSX.rockColor, RPSX.rockColorDark, Mathf.PingPong(Time.time*lerpSpeed, 1));
		lerpingPaper = Color.Lerp(RPSX.paperColor, RPSX.paperColorDark, Mathf.PingPong(Time.time*lerpSpeed, 1));
		lerpingScissors = Color.Lerp(RPSX.scissorsColor, RPSX.scissorsColorDark, Mathf.PingPong(Time.time*lerpSpeed, 1));

		if (timer > 0) {
			visible = true;
		} else 
		{
			visible = false;
		}

		if (timer <= 0) 
		{
			timer = 0;
		}

		if (timer >= timerMax) 
		{
			timer = timerMax;
		}

		if (visible) 
		{
			timer = timer - Time.deltaTime;

			if (p.selectedState == "Rock") {
				sr.sprite = rock;
				if (p.selectedState == p.currentState) 
				{
					sr.color = lerpingRock;
				}
				else if (sc.rockOnCooldown) {
					sr.color = RPSX.rockColorFaded;
				} else {
					sr.color = RPSX.rockColor;
				}

			}

			if (p.selectedState == "Paper") {
				sr.sprite = paper;
				if (p.selectedState == p.currentState) 
				{
					sr.color = lerpingPaper;
				}
				else if (sc.paperOnCooldown) {
					sr.color = RPSX.paperColorFaded;
				} else {
					sr.color = RPSX.paperColor;
				}
			}

			if (p.selectedState == "Scissors") {
				sr.sprite = scissors;
				if (p.selectedState == p.currentState) 
				{
					sr.color = lerpingScissors;
				}
				else if (sc.scissorsOnCooldown) {
					sr.color = RPSX.scissorsColorFaded;
				} else {
					sr.color = RPSX.scissorsColor;
				}
			}
		} else 
		{
			sr.sprite = null;
		}

	}

	public void addToTimer(float amount)
	{
		timer = amount;
	}
}
