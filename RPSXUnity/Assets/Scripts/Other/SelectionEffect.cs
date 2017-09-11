using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEffect : MonoBehaviour {

	float lerpSpeed;
	public float expandedScale;
	public float scaleTime;
	public string state;
	public Sprite rock;
	public Sprite paper;
	public Sprite scissors;
	public GameObject playerSign;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = playerSign.transform.position;

		StartCoroutine (scaleOverTime(scaleTime)); 


	
		
	}

	IEnumerator scaleOverTime (float time)
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		if (state == "Rock") 
		{
			GetComponent<SpriteRenderer> ().color = RPSX.rockColor;
			GetComponent<SpriteRenderer> ().sprite = rock;
		}
		if (state == "Paper") 
		{
			GetComponent<SpriteRenderer> ().color = RPSX.paperColor;
			GetComponent<SpriteRenderer> ().sprite = paper;
		}
		if (state == "Scissors") 
		{
			GetComponent<SpriteRenderer> ().color = RPSX.scissorsColor;
			GetComponent<SpriteRenderer> ().sprite = scissors;
		}
		Color originalColor = sr.color;
		Color targetColor = sr.color;
		targetColor.a = 0; 
		Vector3 originalScale = gameObject.transform.localScale;
		Vector3 targetScale = new Vector3 (expandedScale, expandedScale, expandedScale);
		float currentTime = 0.0f;

		do
		{
			gameObject.transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / time);
			sr.color = Color.Lerp (originalColor, targetColor, currentTime/time); 
			currentTime += Time.deltaTime;
					yield return null;
		} 
		while (currentTime <= time);

				Destroy(gameObject);
	}
}
