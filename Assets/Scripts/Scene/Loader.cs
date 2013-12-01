using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	
	public Texture loadingTexture;
	public GUISkin skin;
	
	void Awake()
	{
		Time.timeScale = 0;
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () 
	{
		// Put background image.
		GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);

		GUI.skin = skin;
		if(GUI.Button (new Rect ((Screen.width/2) - ((Screen.width * 0.25f)/2) , (Screen.height * 0.85f),(Screen.width * 0.25f),(Screen.height * 0.1f)), "START"))
		{
			Time.timeScale = 1;
			Destroy (gameObject);
		}
	}
}