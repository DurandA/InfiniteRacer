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

	public Detonator smokePrefab;

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

		// Falling from half pipes detection.
		else if(collision.gameObject.name == "ColliderHalfPipe")
		{
			player.enabled=false;
			GameConfiguration.Instance.speed=0;
			Rigidbody rigidBody=GetComponent<Rigidbody>();
			rigidbody.isKinematic=false;
			rigidbody.AddForce(transform.localPosition*5000f+transform.forward*10000f*GameConfiguration.Instance.speed);

			foreach(Collider collider in GetComponents<Collider>())
				Destroy(collider);

			StartCoroutine(WaitAndExplode(0.3f));
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
			StartCoroutine(WaitAndExplode(0f));

		}  
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

		// Instantiate a detonator game object where the bomb is  

		Instantiate (smokePrefab, transform.position-transform.forward*5, Quaternion.identity);  
		// Destroy the bomb (because it exploded lol)

		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}

	void OnDestroy() {
		Debug.Log("End of game, score : "+GameConfiguration.Instance.score);
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