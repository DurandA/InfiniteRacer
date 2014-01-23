using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
	public AudioSource music;

	private ParticleEmitter leftSparks;
	private ParticleEmitter rightSparks;

	// Scripts references.
	//public GameObject navigation;
	public GameObject camera;
	public GameObject ship;

	public Detonator smokePrefab;
	public GameManager gameManager;

	//private HUD hud;
	private PlayerBehaviour player;

	// ------------------------------------------------------------------------
	// Start.
	// ------------------------------------------------------------------------

	void Start () 
	{
		//hud = camera.GetComponent<HUD>();
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
		if(collision.gameObject.tag == "Coin")
		{
			Destroy(collision.gameObject);

			coinNoise.audio.Play();

			GameConfiguration.Instance.coins++;
			GameConfiguration.Instance.score += 10;
		}

		// Falling from half pipes detection.
		else if(collision.gameObject.name == "ColliderHalfPipe")
		{
			collision.enabled=false;
			/*foreach(Collider collider in GetComponents<Collider>())
				Destroy(collider);*/
			player.enabled=false;

			GameConfiguration.Instance.speed=0;
			Rigidbody rigidBody=GetComponent<Rigidbody>();

			rigidbody.isKinematic=false;
			rigidbody.AddForce(transform.localPosition*50000f+transform.forward*10000f*GameConfiguration.Instance.speed);


			StartCoroutine(WaitAndFall(0.3f));
		}
		else if(collision.gameObject.tag == "Powerup"){
			collision.gameObject.transform.parent = gameObject.transform;
			collision.gameObject.renderer.enabled = false;
			collision.enabled=false;
			gameManager.addPowerup((Powerup) collision.GetComponent(typeof(Powerup)));
		}
		// Lost the game.
		else
		{
			foreach(Collider collider in GetComponents<Collider>())
				collider.enabled = false;

			GameConfiguration.Instance.speed = 0f;
			// Destroy the ship.
			player.onCollision = true;
			player.motion = 0f;

			music.audio.Stop();

			StartCoroutine(WaitAndExplode(0f));

			GameConfiguration.Instance.ended = true;
		}  
	}

	IEnumerator WaitAndFall(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		
		Destroy(rigidbody);
		Destroy(GetComponent<ShipAnimator>());
		
		yield return new WaitForSeconds(5f);

		
		// Get ended game screen.
		GameConfiguration.Instance.ended = true;
	}
	/*
	 * Author : Arnaud Durand
	 */
	IEnumerator WaitAndExplode(float waitTime) {
		yield return new WaitForSeconds(waitTime);

		Destroy(rigidbody);
		Destroy(GetComponent<ShipAnimator>());

		Detonator[] parts=GetComponentsInChildren<Detonator>();

		foreach (Detonator part in parts){
			if (part.gameObject == gameObject)
				continue;

			part.gameObject.AddComponent<Rigidbody>();
			part.transform.parent=null;
			part.rigidbody.AddExplosionForce(200f,transform.position-transform.forward*10,20f);
		}

		GetComponent<Detonator>().Explode();

		yield return new WaitForSeconds(0.25f);
		foreach (Detonator part in parts){
			part.Explode();
		}

		// Instantiate a detonator game object where the bomb is.
		Instantiate (smokePrefab, transform.position-transform.forward*5, Quaternion.identity);  

		// Destroy the bomb (because it exploded lol).
		yield return new WaitForSeconds(3f);

		Destroy(gameObject);
	}


	void OnDestroy() {
		Debug.Log("End of game, score : " + GameConfiguration.Instance.score);
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