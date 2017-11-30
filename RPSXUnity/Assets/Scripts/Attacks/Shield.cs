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
	public float mod;
	Rigidbody2D rb;
	SpriteRenderer sr;
	public Player p;


	void Awake () {

		p = GetComponentInParent<Player> ();
		sr = GetComponent<SpriteRenderer> ();


	}
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		float shieldPosX = (Input.GetAxis ("LeftStickX_P" + p.playerNum) * mod * (p.directionModifier));
		float shieldPosY = (Input.GetAxis ("LeftStickY_P" + p.playerNum) * (mod * -1));
		placement = new Vector2 (shieldPosX, shieldPosY);   
		transform.localPosition = placement; 
		if (shieldPosX < mod) 
		{
			shieldPosX = mod;
		}
		if (shieldPosY <= mod) 
		{
			shieldPosY = mod;
		}
		if (p.touchingGround == true) {
			if (placement.y <= 0) {
				transform.localPosition = new Vector2 (shieldPosX, 0);
			}
		}

		float angle = Mathf.Atan2 (placement.y, placement.x * p.directionModifier) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	

		rps = GetComponentInParent<RPSState> (); 
		currentState = p.currentState;
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

//	void OnCollisionEnter2D (Collision2D coll)
//	{
//		if (coll.gameObject.tag == "Player") 
//		{
//			Player p = coll.gameObject.GetComponent<Player> ();
//			if (p.playerNum == owner) 
//			{
//				Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
//			}
//		}
//	}
		
}
