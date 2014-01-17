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
	public GUISkin scoresSkin;

	// Variables.
	private int width;
	private int height;
	private string playerName;
	private bool sent = false;
	private bool received = false;
	private List<HighscoreSaver.Highscore> highscores;

	// Use this for initialization.
	void Start () {
		width = (Screen.width / 2);
		height = (Screen.height / 3);
		playerName = "Your Name";
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

			GUI.skin = button;

			// Submit score.
			if(sent == false)
			{
				// Get player name.
				playerName = GUI.TextField(new Rect(width - 200,height * 1.8f,400,50), playerName, 15);

				// Score display.
				GUI.Label(new Rect(0, height * 1.3f,width * 2,70), "SCORED " + GameConfiguration.Instance.score.ToString());

				// Submit button.
				if(GUI.Button(new Rect (width + 200,height * 1.8f,70,70), "GO"))
				{
					// TO DO : check internet connection.
					HighscoreSaver.postScore(playerName, GameConfiguration.Instance.score.ToString(), this);
					sent = true;
				}
			}

			// Display best players.
			else
			{
				if(received == true)
				{
					GUI.skin = scoresSkin;

					float heightHS = 0.6f;
					
					foreach (HighscoreSaver.Highscore hs in this.highscores)
					{
						heightHS += 0.2f;
						GUI.Label(new Rect(width-250, height * heightHS,500, 60), hs.position + "    " + hs.name + "    " + hs.score);
					}

					// Own score.
					//heightHS += 0.5f;
					//GUI.Label(new Rect(width-250, height * heightHS,500, 60), "NEW SCORE    " + GameConfiguration.Instance.score);
				}
			}

			// Control menu.
			GUI.skin = button;

			if(GUI.Button(new Rect (width-((Screen.width * 0.25f)/2), height * 2.275f,(Screen.width * 0.25f),(Screen.height * 0.1f)), "RESTART"))
			{
				Application.LoadLevel(1);
			}

			if(GUI.Button(new Rect (width-((Screen.width * 0.25f)/2), height * 2.28f + (Screen.height * 0.1f),(Screen.width * 0.25f),(Screen.height * 0.1f)), "EXIT"))
			{
				Application.LoadLevel(0);
			}
		}
	}

	// ------------------------------------------------------------------
	// OnHighscoreLoaded.
	// ------------------------------------------------------------------

	public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
	{
		this.highscores = highscores;
		received = true;
	}

	// ------------------------------------------------------------------
	// OnHighscorePosted.
	// ------------------------------------------------------------------

	public void OnHighscorePosted(){
		HighscoreSaver.loadScores(this,HighscoreSaver.ScoreTypes.top3withlastscore);
	}
}