using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	
	// Variables.
	//private int loading = 1;
	public Texture loadingTexture;
	public float loadingState;
	
	void Start() 
	{
        Application.LoadLevelAsync("MainScene");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () 
	{
		// Put background image.
		GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);
	}
}
