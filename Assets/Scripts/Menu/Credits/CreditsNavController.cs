using UnityEngine;
using System.Collections;
/*
 * Author : Thomas Rouvinez
 * Description : controller class for the credits menu.
 */

public class CreditsNavController : MonoBehaviour {

	// -----------------------------------------------------------------------------------
	// Variables.
	// -----------------------------------------------------------------------------------



	// -----------------------------------------------------------------------------------
	// Start && Update.
	// -----------------------------------------------------------------------------------

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Get back to main menu.
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel(0);
		}

		// Get user input for directions.
		else if((Input.GetKey ("left")||(Input.GetMouseButton(0) && Input.mousePosition.x<Screen.width/2)))
		{
			// Switch to the previous credits.

		}

		else if((Input.GetKey ("right")||(Input.GetMouseButton(0) && Input.mousePosition.x>Screen.width/2)))
		{
			// Switch to the next credits.

		}

		else
		{
			// Resume idle animations.

		}
	}
}