using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Description : handle speed and score.
 */
public class GameManager : MonoBehaviour {
		
	public float speed=100f;
	private int coins=0;
	private long score=0;

	public float scoreCoefficient=1.0f;
	private float currentScore = 0f;
	private float timer;
		
	// ----------------------------------------------------------------------
	// Update score.
	// ----------------------------------------------------------------------

	// Use this for initialization
	void Awake () {
		ResetConfiguration();
	}

	void Update () {
		
		// Update and detect each second.
		if(score < currentScore)
		{
			score += 1;
			timer = Time.time;
		}
		
		currentScore += ((long)((Time.time - timer)) * scoreCoefficient);
	}

	public void ResetConfiguration () {
		GameConfiguration.Instance.speed=speed;
		GameConfiguration.Instance.coins=coins;
		GameConfiguration.Instance.score=score;
	}

}
