using UnityEngine;
using System.Collections;


public class BlowerAnimator : MonoBehaviour {

	public GameObject propeller;


	
	// Update is called once per frame.
	void Update ()
	{
		propeller.transform.Rotate(Vector3.forward, Time.deltaTime * -25);
	}
	
	// --------------------------------------------------------------
	// Ship animations.
	// --------------------------------------------------------------
	
	// Rotate the propellers.
	void rotatePropellers()
	{

	}
}

