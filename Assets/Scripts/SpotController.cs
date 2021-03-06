﻿using UnityEngine;
using System.Collections;

public class SpotController : MonoBehaviour 
{

	public float hAxis = 0;
	public float vAxis = 0;
	public bool buttonDown;
	public string gameMode;
	public GameObject song_pref;

	// Use this for initialization
	void Start () {
		gameMode = "Intro"; // Intro, Charge, Guard, Attack, Harmony, End
	}
	
	// Update is called once per frame
	void Update () {

		GameObject spotFx = transform.Find ("control_spot_fx").gameObject; 
		GameObject defCross = transform.Find ("def_cross").gameObject;

		buttonDown = Input.GetButton ("Fire2");

		if (Input.GetButtonDown ("R1")) {
			gameMode = "Guard";
			Instantiate (song_pref);
		}

		if (gameMode == "Intro") {
			defCross.GetComponent<Renderer> ().enabled = false;
			spotFx.GetComponent<Renderer> ().enabled = false;
		}
		else if (gameMode == "Charge" || gameMode == "Attack") {
			
			defCross.GetComponent<Renderer> ().enabled = false;

			hAxis = Input.GetAxis ("Horizontal");
			vAxis = Input.GetAxis ("Vertical");

			if (Mathf.Abs (hAxis) > 0.05 || Mathf.Abs (vAxis) > 0.05) {
				spotFx.GetComponent<Renderer> ().enabled = true;
			} else {
				spotFx.GetComponent<Renderer> ().enabled = false;
			}
				
			if (buttonDown == true) {
				(gameObject.GetComponent ("Halo") as Behaviour).enabled = true;
			} else {
				(gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
			}

			float angle = Mathf.Atan2 (vAxis, hAxis) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle - 90, Vector3.forward);
		}
		else if (gameMode == "Guard") {
			defCross.GetComponent<Renderer> ().enabled = true;
			spotFx.GetComponent<Renderer> ().enabled = false;

		}
	}

	void FixedUpdate(){

	}
}
