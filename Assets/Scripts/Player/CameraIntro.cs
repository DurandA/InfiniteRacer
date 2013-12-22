using UnityEngine;
using System.Collections;

public class CameraIntro : MonoBehaviour {

	// -------------------------------------------------------------
	// Variables.
	// -------------------------------------------------------------

	public Camera camera;
	public GameObject ship;

	private Animator animation;
	private PlayerBehaviour playerScript;

	// -------------------------------------------------------------
	// Start.
	// -------------------------------------------------------------

	void Start()
	{
		animation = camera.GetComponent<Animator> ();
		playerScript = ship.GetComponent<PlayerBehaviour> ();
	}

	// -------------------------------------------------------------
	// Disable intro cutscene.
	// -------------------------------------------------------------

	void disableAnimation()
	{
		// Game is starting.
		animation.enabled = false;
		playerScript.InputEnabled(true);
	}
}