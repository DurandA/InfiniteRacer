using UnityEngine;
using System.Collections;

public class MenuAnimator : MonoBehaviour {

	// Required Gameobjects.
	public GameObject propellerLeft;
	public GameObject propellerRight;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate propellers
		propellerLeft.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
		propellerRight.transform.Rotate(Vector3.up, Time.deltaTime * 100000);
	}
}
