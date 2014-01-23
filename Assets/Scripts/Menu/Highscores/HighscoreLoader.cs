using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class HighscoreLoader : MonoBehaviour {
	// Variables.
	public TextMesh intanceScore;
	public TextMesh intanceName;

	private long height;
	private bool sent = false;

	private List<HighscoreSaver.Highscore> highscores;

	// ------------------------------------------------------------------
	// Main.
	// ------------------------------------------------------------------

	void Start ()
	{
		LoadHighscores();
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel(0);
		}
	}

	// ------------------------------------------------------------------
	// OnHighscoreLoaded.
	// ------------------------------------------------------------------
	
	public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
	{
		this.highscores = highscores;
		float offset = 0f;

		foreach (HighscoreSaver.Highscore hs in this.highscores)
		{
			offset -= 1.5f;

			// Spawn highscores.
			TextMesh score = (TextMesh)Instantiate(intanceScore, this.transform.localPosition, Quaternion.identity);
			score.transform.position = new Vector3(score.transform.position.x - 0.5f, score.transform.position.y + offset, score.transform.position.z);
			score.text =  hs.score;
			score.transform.parent = this.transform;

			TextMesh name = (TextMesh)Instantiate(intanceName, this.transform.localPosition, Quaternion.identity);
			name.transform.position = new Vector3(name.transform.position.x + 6f, name.transform.position.y + offset, name.transform.position.z);
			name.text =  hs.name;
			name.transform.parent = this.transform;
		}

		this.transform.Rotate(new Vector3(32.69793f, 62.9713f, 13.55636f));
	}

	// ------------------------------------------------------------------
	// Load Highscores.
	// ------------------------------------------------------------------

	public void LoadHighscores()
	{
		HighscoreSaver.loadScores (this, HighscoreSaver.ScoreTypes.top10);
	}
}