using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Variables.
	public TextMesh coinNumber;
	public TextMesh totalTime;
	public TextMesh score;
	public bool running;

	private GameObject nav;
	private GameObject ship;
	private ScoreManager scoreScript;
	private PlayerBehaviour playerScript;

	// Get the required script references for the information displayed in the HUD.
	void Start () {
		running = true;

		// Get score script.
		nav = GameObject.Find("Navigation");
		scoreScript = nav.GetComponent<ScoreManager>();

		// Get player management script.
		ship = GameObject.Find("Ship");
		playerScript = ship.GetComponent<PlayerBehaviour>();

	}
	
	// Update fields in the HUD
	void Update () {
		// As long as we are not dead.
		if(running == true)
		{
			// Update the fields.
			coinNumber.text = playerScript.coins.ToString() ;
			score.text = scoreScript.score.ToString(); 
			totalTime.text = Time.time.ToString("F2");
		}
	}
}