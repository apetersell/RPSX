using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSelector : MonoBehaviour {

	public int playerNum;
	public GameObject rock;
	public GameObject paper;
	public GameObject scissors;
	public GameObject shield;
	Color lerpingRock;
	Color lerpingPaper;
	Color lerpingScissors;
	public float lerpSpeed;
	public float timer;
	public float timerMax; 
	public bool visible;
	Player p;
	StateCooldowns sc;
	SpriteRenderer sr;
	public Color used;



	// Use this for initialization
	void Start () {

		p = GetComponentInParent<Player> ();
		sc = GetComponentInParent<StateCooldowns> ();
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
//
//			if (p.selectedState == "Rock") {
//				sr.sprite = rock;
//				if (sc.rockOnCooldown || p.currentState == "Rock") {
//					sr.color = used;
//				} else {
//					sr.color = lerpingRock;
//				}
//
//			}
//
//			if (p.selectedState == "Paper") {
//				sr.sprite = paper;
//				if (sc.paperOnCooldown || p.currentState == "Paper") {
//					sr.color = used;
//				} else {
//					sr.color = lerpingPaper;
//				}
//			}
//
//			if (p.selectedState == "Scissors") {
//				sr.sprite = scissors;
//				if (sc.scissorsOnCooldown || p.currentState == "Scissors") {
//					sr.color = used;
//				} else {
//					sr.color = lerpingScissors;
//				}
//			}
			if (p.selectedState == "Rock") 
			{
				rock.SetActive (true);
				paper.SetActive (false);
				scissors.SetActive (false);
			}
			if (p.selectedState == "Paper") 
			{
				rock.SetActive (false);
				paper.SetActive (true);
				scissors.SetActive (false);
			}
			if (p.selectedState == "Scissors") 
			{
				rock.SetActive (false);
				paper.SetActive (false);
				scissors.SetActive (true);
			}
		} 
		else 
		{
			rock.SetActive (false);
			paper.SetActive (false);
			scissors.SetActive (false);
		}

	}

	public void addToTimer(float amount)
	{
		timer = amount;
	}
}
