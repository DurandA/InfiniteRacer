using UnityEngine;
using System.Collections;


public class BlowerAnimator : MonoBehaviour {
	
	
	// Update is called once per frame.
	void Update ()
	{
		rotatePropellers(); 	// Rotate the propellers.
	}
	
	// --------------------------------------------------------------
	// Ship animations.
	// --------------------------------------------------------------
	
	// Rotate the propellers.
	void rotatePropellers()
	{
		GameObject.Find("Propeller").transform.Rotate(Vector3.forward, Time.deltaTime * 10);
	}
}

