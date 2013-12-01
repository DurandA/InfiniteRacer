using UnityEngine;
using System.Collections;

public class NewGameController : MonoBehaviour {
	
	// Hover system.
	void OnMouseOver() 
	{
		renderer.material.color = Color.blue;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	// Click system.
	void OnMouseUp()
	{
		// Get the loading screen.
		Application.LoadLevel(1);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}