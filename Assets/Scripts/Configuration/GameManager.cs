using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Description : handle speed and score.
 */
public class GameManager : MonoBehaviour {

	public float speed = 100f;
	private int coins = 0;
	private long score = 0;
	private float timer;
		
	// ----------------------------------------------------------------------
	// Update score.
	// ----------------------------------------------------------------------

	// Use this for initialization
	void Awake () {
		ResetConfiguration();
	}

	void Start() {
		timer = Time.time;
	}

	void Update () {
		// Update and detect each second.
		if(Time.time - timer >= 1f && GameConfiguration.Instance.ended == false)
		{
			timer = Time.time;
			GameConfiguration.Instance.score += 1;

			GameConfiguration.Instance.speed = Mathf.Clamp(GameConfiguration.Instance.speed +0.2f, 100f, 180f);
		}
	}

	public void ResetConfiguration () {
		GameConfiguration.Instance.speed = 100;
		GameConfiguration.Instance.coins = 0;
		GameConfiguration.Instance.score = 0;
		GameConfiguration.Instance.paused = false;
		GameConfiguration.Instance.ended = false;
	}
}