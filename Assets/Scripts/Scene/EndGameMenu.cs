using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
	private string playerName;
	private bool sent = false;

	// Use this for initialization.
	void Start () {
		width = (Screen.width / 2);
		height = (Screen.height / 3);
		playerName = "Your Name";
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

			// Get player name.
			playerName = GUI.TextField(new Rect(width - 200,height * 1.8f,400,50), playerName, 25);

			// Score display.
			GUI.Label(new Rect(0, height * 1.3f,width * 2,70), "SCORED " + GameConfiguration.Instance.score.ToString());

			// Submit button.
			if(GUI.Button(new Rect (width + 200,height * 1.8f,70,70), "GO"))
			{
				if(sent == false)
				{
					// manque : tester s'il y a une connexion internet
					HighscoreSaver.postScore(playerName, GameConfiguration.Instance.score.ToString(), this);
					sent = true;
				}
			}

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
	// ------------------------------------------------------------------
	// OnHighscoreLoaded.
	// callback method, called if the higscores are loaded correctly
	// ------------------------------------------------------------------
	public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
	{
		Debug.Log("The last highscores:");
		foreach (HighscoreSaver.Highscore hs in highscores)
		{
			Debug.Log(hs.position + "\t\t" + hs.name + "\t\t" + hs.score + "\n");
		}
	}
	// ------------------------------------------------------------------
	// OnHighscorePosted.
	// callback method, called if the Rest-request is sucessful
	// ------------------------------------------------------------------
	public void OnHighscorePosted(){
		HighscoreSaver.loadScores(this);
		Debug.Log("Scores published with success.");
	}
}