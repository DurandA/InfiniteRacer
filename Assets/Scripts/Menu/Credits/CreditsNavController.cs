using UnityEngine;
using System.Collections;
/*
 * Author : Thomas Rouvinez
 * Description : controller class for the credits menu.
 */

public class CreditsNavController : MonoBehaviour {

	// -----------------------------------------------------------------------------------
	// Start && Update.
	// -----------------------------------------------------------------------------------

	public GameObject directionalLight;
	
	private float targetAngle = 180.0f;
	private bool token = true;
	private float startTime;
	private float resetTime = 1.2f;
	private byte direction = 1;

	// -----------------------------------------------------------------------------------
	// Start && Update.
	// -----------------------------------------------------------------------------------

	// Update is called once per frame
	void Update () {
		// Get back to main menu.
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel(0);
		}

		// Get user input for directions.
		else if((Input.GetKey ("left")||(Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width/2)) && token == true)
		{
			startTime = Time.time;
			token = false;

			targetAngle = targetAngle - 90f;
		}

		else if((Input.GetKey ("right")||(Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width/2)) && token == true)
		{
			startTime = Time.time;
			token = false;

			targetAngle = targetAngle + 90f;
		}

		else if(Time.time - startTime > resetTime)
		{
			token = true;
		}

		// Execute animations.
		Vector3 end = new Vector3(0f, targetAngle, 0f);

		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(end), Time.deltaTime * 8f); 
		directionalLight.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(end), Time.deltaTime);
	}
}