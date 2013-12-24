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

	private ParticleEmitter leftSparks;
	private ParticleEmitter rightSparks;

	// Scripts references.
	public GameObject navigation;
	public GameObject camera;
	public GameObject ship;

	private HUD hud;
	private PlayerBehaviour player;

	// ------------------------------------------------------------------------
	// Start.
	// ------------------------------------------------------------------------

	void Start () 
	{
		hud = camera.GetComponent<HUD>();
		player = ship.GetComponent<PlayerBehaviour>();

		// Get particle systems.
		leftSparks = sparksLeft.GetComponent<ParticleEmitter>();
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
			GameConfiguration.Instance.coins++;
			GameConfiguration.Instance.score += 25;
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
			hud.running = false;
			
			// Destroy the ship.
			player.onCollision = true;
			GameConfiguration.Instance.speed = 0f;
			player.motion = 0f;
			GetComponent<Detonator>().Explode();
		}  
	}

	// Wings collisions detection.
	public void OnHitLeft()
	{
		leftSparks.Emit ();
	}

	public void OnHitRight()
	{
		rightSparks.Emit ();
	}
}