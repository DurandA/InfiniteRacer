using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Description : class to handle the ship's animations in the
 * 				main menu (only the rotating props.)
 * 
 */
public class MenuAnimator : MonoBehaviour {

	// Required Gameobjects.
	public GameObject propellerLeft;
	public GameObject propellerRight;
	
	// Update is called once per frame
	void Update () {
		// Rotate propellers
		propellerLeft.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
		propellerRight.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
	}
}