using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {
	
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

	}
}