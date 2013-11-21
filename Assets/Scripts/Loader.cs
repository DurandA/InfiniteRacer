using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	
	public Texture loadingTexture;
	
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

		if(GUI.Button (new Rect (Screen.width/2 - 75, Screen.height -50,150,20), "Start"))
		{
			Time.timeScale = 1;
			Destroy (gameObject);
		}
	}
}
