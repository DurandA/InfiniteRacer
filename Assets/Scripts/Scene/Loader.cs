using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	// Variables.
	public Texture loadingTexture;
	public GUISkin skin;
	public GameObject navigation;
	public AudioSource music;
	public GameManager gameManager;

	// On resume.
	void Awake()
	{
		Time.timeScale = 0;
	}
	
	void OnGUI () 
	{
		// Put background image.
		GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);
		
		// Create the "START" button when loading is complete.
		GUI.skin = skin;
		if(GUI.Button (new Rect ((Screen.width/2) - ((Screen.width * 0.25f)/2) , (Screen.height * 0.85f),(Screen.width * 0.25f),(Screen.height * 0.1f)), "START")
		   || Input.GetKeyDown(KeyCode.Return))
		{
			// Reset values of the game.
			gameManager.ResetConfiguration();

			// Start the music.
			music.audio.Play();

			// Start game.
			Time.timeScale = 1;
			Destroy (gameObject);
		}
	}
}