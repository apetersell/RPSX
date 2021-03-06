﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {

	GameObject player1;
	GameObject player2;
//	public GameObject fusion;
//	public bool fused; 
	public float camZ;
	float camZoom;
	public float zoomLowerLim; 
	public float zoomUpperLim; 
	public float leftLimit;
	public float rightLimit;
	public float upperLimit;
	public float lowerLimit;
	public float smoothing;
	public Vector3 midpoint;
	public Vector3 smoothy;


	// Use this for initialization
	void Start () {

		player1 = GameObject.Find (RPSX.Player1Name);
		player2 = GameObject.Find (RPSX.Player2Name);
		smoothy.x = Mathf.Lerp (smoothy.x, midpoint.x, 1f / smoothing);
		smoothy.y = Mathf.Lerp (smoothy.y, midpoint.y, 1f / smoothing);
	
	}
	
	// Update is called once per frame
	void Update () {

		smoothy.x = Mathf.Lerp (smoothy.x, midpoint.x, 1f / smoothing);
		smoothy.y = Mathf.Lerp (smoothy.y, midpoint.y, 1f / smoothing);
		smoothy.z = Mathf.Lerp (smoothy.z, 1, 1f / smoothing); 
//		fusion = GameObject.Find ("FusionPlayer");
//		if (fused == false) {
		Camera.main.orthographicSize = camZoom;
		midpoint = ((player1.transform.position - player2.transform.position) * 0.5f) + player2.transform.position;
		midpoint.z = camZ;
		midpoint += smoothy;  
		Camera.main.transform.position = midpoint;
		camZoom = Vector3.Distance (player1.transform.position, player2.transform.position);

		if (camZoom > zoomUpperLim) {
			camZoom = zoomUpperLim;
		}

		if (camZoom < zoomLowerLim) {
			camZoom = zoomLowerLim;
		}

		if (midpoint.x > rightLimit) {
			midpoint.x = rightLimit;
		}

		if (midpoint.x < leftLimit) {
			midpoint.x = leftLimit;
		}

		if (midpoint.y > upperLimit) {
			midpoint.y = upperLimit;
		}

		if (midpoint.y < lowerLimit) {
			midpoint.y = lowerLimit;
		}
//		} else 
//		{
//			Camera.main.transform.position = new Vector3 (fusion.transform.position.x, fusion.transform.position.y, camZ);
//		}
	}
}
