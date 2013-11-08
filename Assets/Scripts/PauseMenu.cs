using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	// Variables.
	public bool paused = false;
	
	// GUI.
	public GUISkin pauseBackground;
	public GUISkin pauseResume;
	public GUISkin pauseOptions;
	public GUISkin pauseQuit;
	
	private int width = 0;
	private int height = 0;
	
	// Trigger for the pause menu.
	void Start()
	{
		width = (Screen.width / 6) * 4;
		height = (Screen.height / 2);
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
			if(GUI.Button(new Rect (width,height,250,30), "Resume"))
			{
				Time.timeScale = 1;
				paused = false;
			}
			
			// Options button.
			GUI.skin = pauseOptions;
			if(GUI.Button (new Rect (width,height + 40,250,30), "Options"))
			{
				Debug.Log("Options requested from pause menu");
			}
			
			// Quit button.
			GUI.skin = pauseQuit;
			if(GUI.Button (new Rect (width,height + 80,250,30), "Rage Quit"))
			{
				Application.Quit();
			}
		}
	}
}