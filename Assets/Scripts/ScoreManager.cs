using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	// Variables.
	public long score;
	public float scoreCoefficient;
	public float currentScore;
	public float timer;
	public float increment;

	// Use this for initialization
	void Start () {
		score = 0;
		currentScore = 0;
		scoreCoefficient = 1.0f;
		increment = 0.0f;
	}
	
	// Update score.
	void Update () {
		
		// Update and detect each second.
		if(score < currentScore)
		{
			score += 1;
			timer = Time.time;
		}
		
		currentScore += ((long)((Time.time - timer)) * scoreCoefficient);
		scoreCoefficient += increment;
	}
}