using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float moveSpeed;
	private float moveForce; 
	public float limit;
	public bool vertical;
	public bool movingPlus;
	public Vector3 startPos;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		startPos = transform.position; 


	}
	
	// Update is called once per frame
	void Update () {

		if (vertical == false) {
			rb.velocity = new Vector2 (moveForce, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (rb.velocity.x, moveForce);
		}

		if (vertical == false) {
			if (transform.localPosition.x >= startPos.x + limit) {
				movingPlus = false;
			}

			if (transform.localPosition.x <= startPos.x - limit) {
				movingPlus = true;
			}
		} else {
			if (transform.localPosition.y >= startPos.y + limit) {
				movingPlus = false;
			}

			if (transform.localPosition.y <= startPos.y - limit) {
				movingPlus = true;
			}
		}

		if (movingPlus == true) 
		{
			moveForce = moveSpeed;
		}
		if (movingPlus == false) 
		{
			moveForce = moveSpeed * -1;
		}
		
	}
		
}
