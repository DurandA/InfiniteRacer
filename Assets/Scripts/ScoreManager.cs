using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	// Variables.
	public static float score;
	public float scoreCoefficient;
	
	private float rateIncrease;
	public static long currentScore;
	private float timer;
	public long coins;

	// Use this for initialization
	void Start () {
		score = 0.0f;
		currentScore = 0;
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