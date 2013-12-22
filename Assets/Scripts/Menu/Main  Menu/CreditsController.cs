using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {

	public AudioSource hover;
	public AudioSource click;
	private int count = 1;

	// Hover system.
	void OnMouseOver() 
	{
		if(count == 1)
		{
			count = 0;
			hover.audio.Play();
			renderer.material.color = Color.blue;
		}
	}
	
	void OnMouseExit()
	{
		count = 1;
		renderer.material.color = Color.white;
	}
	
	// Click system.
	void OnMouseUp()
	{
		click.audio.Play();
	
		// Get the loading screen.
		Application.LoadLevel(3);
	}
}