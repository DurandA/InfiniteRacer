using UnityEngine;
using System.Collections;

public class MenuConfiguration : MonoBehaviour {

	// Positions.
	public Vector3 cameraInitialPosition = new Vector3(0f,1f,-10f);
	public Vector3 cameraMenuClickedPosition = new Vector3(10f,1f,-10f);
	public Vector3 currentPosition;
	public Vector3 newPosition;

	// Configuration.
	public bool enableMusicMenu = true;
	public bool enableMusicGame = true;

	// Self declaration.
	static MenuConfiguration instance = null;
	static readonly object padlock = new object();

	// -----------------------------------------------------------------
	// Constructor.
	// -----------------------------------------------------------------
	
	public static MenuConfiguration Instance{
		get{
			if (instance == null){
				lock (padlock){
					if (instance == null){
						instance = new MenuConfiguration();
					}
				}
			}

			return instance;
		}
	}
}