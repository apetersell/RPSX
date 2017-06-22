using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public RPSState rps;
	public int owner;
	public string currentState;
	public Sprite basic;
	public Sprite rock;
	public Sprite paper;
	public Sprite scissors;
	public Vector2 placement; 
	Rigidbody2D rb;
	SpriteRenderer sr;
	Player p;


	void Awake () {

		p = GetComponentInParent<Player> ();
		sr = GetComponent<SpriteRenderer> ();


	}
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		currentState = p.currentState;
		placement = new Vector2 (Input.GetAxis ("LeftStickX_P" + p.playerNum), Input.GetAxis ("LeftStickY_P" + p.playerNum) * -1); 
		transform.localPosition = placement; 
		if (p.touchingGround == true) 
		{
			if (placement.y <= 0) 
			{
				transform.localPosition = new Vector2 (placement.x, 0);
			}
		}
		rps = GetComponentInParent<RPSState> (); 
		transform.localScale = new Vector2 (rps.shieldSize, rps.shieldSize);

		if (currentState == "Basic") 
		{
			sr.color = RPSX.basicColor;
			sr.sprite = basic;
		}

		if (currentState == "Rock") 
		{
			sr.color = RPSX.rockColor;
			sr.sprite = rock;
		}

		if (currentState == "Paper") 
		{
			sr.color = RPSX.paperColor;
			sr.sprite = paper;
		}

		if (currentState == "Scissors") 
		{
			sr.color = RPSX.scissorsColor;
			sr.sprite = scissors;
		}

	}
		
}
