using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public TextMesh coinNumber;
	public TextMesh totalTime;
	public TextMesh score;
	public TextMesh speed;
	public static bool running;

	// Use this for initialization
	void Start () {
		running = true;
	}
	
	// Update is called once per frame
	void Update () {
		// As long as we are not dead.
		if(running == true)
		{
			// Update the fields.
			coinNumber.text = PlayerBehaviour.coins.ToString() ;
			score.text = ScoreManager.score.ToString(); 
			speed.text = "Speed : " + NavigationController.speed;
			totalTime.text = "Time : " + Time.time.ToString("F2");
		}
	}
}
