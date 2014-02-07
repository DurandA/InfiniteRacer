using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Creation date : 02.07.2014
 * 
 * Description : class to handle the controls for the highscores menu.
 */
public class EscController : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel(0);
		}
	}

	// Click system.
	void OnMouseUp()
	{
		Application.LoadLevel(0);
	}
}