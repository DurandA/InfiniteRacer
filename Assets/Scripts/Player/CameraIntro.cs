using UnityEngine;
using System.Collections;

public class CameraIntro : MonoBehaviour {

	// Variables.
	public Camera camera;
	public GameObject ship;

	private Animator animation;
	private PlayerBehaviour playerScript;

	void Start()
	{
		animation = camera.GetComponent<Animator> ();
		playerScript = ship.GetComponent<PlayerBehaviour> ();
	}

	// Disable cutscene for intro.
	void disableAnimation()
	{
		animation.enabled = false;
		playerScript.InputEnabled(true);
	}
}