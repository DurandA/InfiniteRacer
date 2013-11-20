using UnityEngine;
using System.Collections;

// ------------------------------------------------------------------
// Author : Thomas Rouvinez
// Creation date : 16.10.2013
// Last Modified : 17.10.2013
//
// Description : class to handle all animations of the ship.
// ------------------------------------------------------------------

public class ShipAnimator : MonoBehaviour {
	
	// --------------------------------------------------------------
	// Variables.
	// --------------------------------------------------------------
	
	// Game Objects.
	private GameObject propellerLeft;
	private GameObject propellerRight;
	private GameObject wingLeft;
	private GameObject wingRight;
	private Quaternion rotLeft0;
	private Quaternion rotRight0;
	private Vector3 posLeft0;
	private Vector3 posRight0;
	
	// --------------------------------------------------------------
	// Update.
	// --------------------------------------------------------------
	
	// Use this for initialization
	void Start ()
	{		
		// Get propeller objects.
		propellerLeft = GameObject.Find("PropellerLeft");
		propellerRight = GameObject.Find("PropellerRight");
		
		//Get wing objects
		wingLeft = GameObject.Find ("Wing Left");
		wingRight = GameObject.Find ("Wing Right");
		
		rotLeft0 = wingLeft.transform.localRotation;
		posLeft0 = wingLeft.transform.localPosition;
		rotRight0 = wingRight.transform.localRotation;
		posRight0 = wingRight.transform.localPosition;
		
		
	}
	
	// Update is called once per frame.
	void Update ()
	{
		rotatePropellers(); 	// Rotate the propellers.
		moveWings();			// Move the wings
	}
	
	// --------------------------------------------------------------
	// Ship animations.
	// --------------------------------------------------------------
	
	// Rotate the propellers.
	void rotatePropellers()
	{
		propellerLeft.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
		propellerRight.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
	}
	
	//Moves the wings when right/left keys are pressed.
	//TODO clamp the angles of the rotation
	void moveWings()
	{
		if (Input.GetKey ("left"))
		{
			wingLeft.transform.Rotate(Vector3.forward,Time.deltaTime * 100);
			wingRight.transform.Rotate(Vector3.forward,Time.deltaTime * 100);
		}
		else if (Input.GetKey("right"))
		{
			wingLeft.transform.Rotate(-Vector3.forward,Time.deltaTime * 100);
			wingRight.transform.Rotate(-Vector3.forward,Time.deltaTime * 100);
			
		}else
		{
			wingRight.transform.localRotation = Quaternion.Slerp(wingRight.transform.localRotation, rotRight0, Time.time / 50);
			wingRight.transform.localPosition = Vector3.Lerp(wingRight.transform.localPosition, posRight0, Time.time / 50);
			
			wingLeft.transform.localRotation = Quaternion.Slerp(wingLeft.transform.localRotation, rotLeft0, Time.time / 50);
			wingLeft.transform.localPosition = Vector3.Lerp(wingLeft.transform.localPosition, posLeft0, Time.time / 50);
		}
	}
}