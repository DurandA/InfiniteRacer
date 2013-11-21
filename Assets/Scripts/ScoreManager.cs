using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	// Variables.
	public float score;
	public float scoreCoefficient;
	
	private float rateIncrease;
	private long currentScore;
	private float timer;
	public long coins;

	// Use this for initialization
	void Start () {
		score = 0.0f;
		currentScore = 10;
		scoreCoefficient = 1.0f;
		rateIncrease = 0.000001f;
	}
	
	// Update score.
	void Update () {
		
		// Update and detect each second.
		if(score < currentScore)
		{
			score += 1.0f;
			timer = Time.time;
		}
		
		currentScore += (long)((Time.time - timer) * scoreCoefficient);
	}
}