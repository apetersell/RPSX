using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSelector : MonoBehaviour {

	public int playerNum;
	public Sprite rock;
	public Sprite paper;
	public Sprite scissors;
	public Color rockColor;
	public Color rockColorDark; 
	public Color paperColor;
	public Color paperColorDark;
	public Color scissorsColor;
	public Color scissorsColorDark;
	public Color lerpingRock;
	public Color lerpingPaper;
	public Color lerpingScissors;
	public Color rockCD;
	public Color paperCD;
	public Color scissorsCD;
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

		lerpingRock = Color.Lerp(rockColor, rockColorDark, Mathf.PingPong(Time.time*lerpSpeed, 1));
		lerpingPaper = Color.Lerp(paperColor, paperColorDark, Mathf.PingPong(Time.time*lerpSpeed, 1));
		lerpingScissors = Color.Lerp(scissorsColor, scissorsColorDark, Mathf.PingPong(Time.time*lerpSpeed, 1));

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
					sr.color = rockCD;
				} else {
					sr.color = rockColor;
				}

			}

			if (p.selectedState == "Paper") {
				sr.sprite = paper;
				if (p.selectedState == p.currentState) 
				{
					sr.color = lerpingPaper;
				}
				else if (sc.paperOnCooldown) {
					sr.color = paperCD;
				} else {
					sr.color = paperColor;
				}
			}

			if (p.selectedState == "Scissors") {
				sr.sprite = scissors;
				if (p.selectedState == p.currentState) 
				{
					sr.color = lerpingScissors;
				}
				else if (sc.scissorsOnCooldown) {
					sr.color = scissorsCD;
				} else {
					sr.color = scissorsColor;
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
