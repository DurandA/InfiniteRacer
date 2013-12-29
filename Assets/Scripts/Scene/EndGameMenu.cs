using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Description : class to handle the endgame menu.
 */

public class EndGameMenu : MonoBehaviour {

	// GUI.
	public GUISkin endedBackground;
	public GUISkin button;

	// Variables.
	private int width;
	private int height;

	// Use this for initialization
	void Start () {
		width = (Screen.width / 2);
		height = (Screen.height / 3);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// ------------------------------------------------------------------
	// GUI.
	// ------------------------------------------------------------------

	void OnGUI () 
	{
		if(GameConfiguration.Instance.ended)
		{
			// Put background image.
			GUI.skin = endedBackground;
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

			// Game Over.
			GUI.skin = button;
			GUI.Label(new Rect ((Screen.width / 2) - 300, 0, 600, 150), "GAME OVER");

			// Restart button.
			if(GUI.Button(new Rect (width-((Screen.width * 0.25f)/2), height * 2.27f,(Screen.width * 0.25f),(Screen.height * 0.1f)), "RESTART"))
			{
				Application.LoadLevel(1);
			}

			// Main menu button.
			if(GUI.Button(new Rect (width-((Screen.width * 0.25f)/2), height * 2.28f + (Screen.height * 0.1f),(Screen.width * 0.25f),(Screen.height * 0.1f)), "EXIT"))
			{
				Application.LoadLevel(0);
			}
		}
	}
}