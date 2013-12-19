using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	// Variables.
	public Texture loadingTexture;
	public GUISkin skin;
	public GameObject navigation;
	private ScoreManager scoreScript;
	private NavigationController navigationScript;

	// On resume.
	void Awake()
	{
		Time.timeScale = 0;
	}
	
	// Register the scripts.
	void Start () {
		scoreScript = navigation.GetComponent<ScoreManager>();
		navigationScript = navigation.GetComponent<NavigationController>();
	}
	
	void OnGUI () 
	{
		// Put background image.
		GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);

		// Create the "START" button when loading is complete.
		GUI.skin = skin;
		if(GUI.Button (new Rect ((Screen.width/2) - ((Screen.width * 0.25f)/2) , (Screen.height * 0.85f),(Screen.width * 0.25f),(Screen.height * 0.1f)), "START"))
		{
			// Reset values of the game.
			scoreScript.currentScore = 0;
			scoreScript.score = 0;
			scoreScript.scoreCoefficient = 1.0f;

			navigationScript.speed = 90.0f;
			navigationScript.speedIncrement = 0.005f;

			// Start game.
			Time.timeScale = 1;
			Destroy (gameObject);
		}
	}
}