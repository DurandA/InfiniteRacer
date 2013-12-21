using UnityEngine;
using System.Collections;

/*
 * Author :Thomas Rouvinez
 * Description : class to handle scores.
 */
public class ScoreManager : MonoBehaviour {

	// ----------------------------------------------------------------------
	// Variables.
	// ----------------------------------------------------------------------

	public int coins;
	public long score;
	public float scoreCoefficient;
	public float currentScore;
	public float timer;

	// ----------------------------------------------------------------------
	// Initialization.
	// ----------------------------------------------------------------------

	void Start () {
		coins = 0;
		score = 0;
		currentScore = 0;
		scoreCoefficient = 1.0f;;
	}

	// ----------------------------------------------------------------------
	// Update score.
	// ----------------------------------------------------------------------

	void Update () {
		
		// Update and detect each second.
		if(score < currentScore)
		{
			score += 1;
			timer = Time.time;
		}
		
		currentScore += ((long)((Time.time - timer)) * scoreCoefficient);
	}
}