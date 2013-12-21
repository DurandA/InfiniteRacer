using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Description : class to handle the collisions on the ship.
 */

public class ShipCollisions : MonoBehaviour {

	// ------------------------------------------------------------------------
	// Variables.
	// ------------------------------------------------------------------------

	public BoxCollider colliderLeft;
	public BoxCollider colliderRight;
	public GameObject sparksLeft;
	public GameObject sparksRight;
	public AudioSource coinNoise;

	private ParticleEmitter rightSparks;

	// Scripts references.
	public GameObject navigation;
	public GameObject camera;
	public GameObject ship;

	private HUD hudScript;
	private ScoreManager scoreScript;
	private NavigationController navigationScript;
	private PlayerBehaviour playerScript;

	// ------------------------------------------------------------------------
	// Start.
	// ------------------------------------------------------------------------

	void Start () 
	{
		// Get scripts.
		scoreScript = navigation.GetComponent<ScoreManager>();
		hudScript = camera.GetComponent<HUD>();
		navigationScript = navigation.GetComponent<NavigationController>();
		playerScript = ship.GetComponent<PlayerBehaviour>();

		// Get particle systems.
		rightSparks = sparksRight.GetComponent<ParticleEmitter>();
	}

	// ------------------------------------------------------------------------
	// Collisions.
	// ------------------------------------------------------------------------

	// Ship collisions detection.
	void OnTriggerEnter(Collider collision)
	{
		// Coins detection.
		if(collision.gameObject.name == "Coin(Clone)")
		{
			coinNoise.audio.Play();
			Destroy(collision.gameObject);
			scoreScript.coins++;
			scoreScript.currentScore += 25.0f;
		}

		// Void detection (falling from half pipes).
		else if(collision.gameObject.name == "ColliderHalfPipe")
		{
			Debug.Log("COLLISION FALLING OUT");
		}

		// Lost the game.
		else
		{
			//Notify the score manager the game is over.
			hudScript.running = false;
			
			// Destroy the ship.
			playerScript.onCollision = true;
			navigationScript.speed = 0f;
			playerScript.motion = 0f;
			GetComponent<Detonator>().Explode();
		}  
	}

	// Wings collisions detection.
	public void OnHitLeft()
	{
		Debug.Log("COLLISION LEFT WING");
	}

	public void OnHitRight()
	{
		Debug.Log("COLLISION RIGHT WING");
	}
}