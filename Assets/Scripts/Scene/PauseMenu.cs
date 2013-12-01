using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	// Variables.
	public static bool paused;
	
	// GUI.
	public GUISkin pauseBackground;
	public GUISkin pauseResume;
	public GUISkin pauseMainMenu;
	
	private int width = 0;
	private int height = 0;
	
	// Trigger for the pause menu.
	void Start()
	{
		width = (Screen.width / 6) * 4;
		height = (Screen.height / 2);
		paused = false;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
		{
			paused = true;
			Time.timeScale = 0;
		}
		
		else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
		{
			paused = false;
			Time.timeScale = 1;
		}
	}
	
	void OnGUI () 
	{
		if(paused)
		{
			// Put background image.
			GUI.skin = pauseBackground;
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			
			// Resume button.
			GUI.skin = pauseResume;
			if(GUI.Button(new Rect (width,height,(Screen.width * 0.25f),(Screen.height * 0.1f)), "RESUME"))
			{
				Time.timeScale = 1;
				paused = false;
			}
			
			// Quit button.
			GUI.skin = pauseMainMenu;
			if(GUI.Button(new Rect (width,height + (Screen.height * 0.1f),(Screen.width * 0.25f),(Screen.height * 0.1f)), "MAIN MENU"))
			{
				Application.LoadLevel(0);
			}
		}
	}
}