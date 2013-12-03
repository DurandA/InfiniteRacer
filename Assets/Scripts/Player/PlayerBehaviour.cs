using UnityEngine;
using System.Collections;
	
public class PlayerBehaviour : MonoBehaviour {
	// Variables.
	public float radius=18f;
	public float depth=12;
	public float cameraRadius=6f;
	private float speed=0f;
	public float maxSpeed=1f;
	public float acceleration=2f;
	public float deceleration=2f;
	private bool ft = false;
	public Transform rotationAxis;
	private float positionOnOrbit=0f;
	private float motion;
	private float shiftAmount=0f;
	public static bool onCollision=false;
	public int coins;
	public AudioSource coinNoise;

	// Scripts references.
	public GameObject navigation;
	public GameObject camera;
	private ScoreManager scoreScript;
	private HUD hudScript;
	private NavigationController navigationScript;

	// Shift setter.
	public void Shift(float shiftAmount){
		this.shiftAmount=shiftAmount;
	}

	//public static float horizontalSpeed=200f;
	void Start () {
		//TODO: move all the score logic to another script
		// Initialization for the HUD.
		coins = 0;

		scoreScript = navigation.GetComponent<ScoreManager>();
		hudScript = camera.GetComponent<HUD>();
		navigationScript = navigation.GetComponent<NavigationController>();
	
		//transform.position=new Vector3(0,-radius,depth);
		//Camera.main.transform.position=Vector3.down*cameraRadius;
	}


	// Ship collisions.
	void OnTriggerEnter(Collider other) {

		// If collision is a coin.
		if(other.gameObject.name == "Coin(Clone)")
		{
			coinNoise.audio.Play();
			Destroy(other.gameObject);
			coins++;
			scoreScript.currentScore += 25.0f;
		}
		// If collision requires the ship to explode.
		else
		{
			// Notify the score manager the game is over.
			hudScript.running = false;

			// Destroy the ship.
			onCollision = true;
			navigationScript.speed = 0f;
			motion = 0f;
			GetComponent<Detonator>().Explode();
		}   
    }

	// Rotate arround.
	private Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle){
		return angle * ( point - pivot) + pivot;
	}

	// User input management.
	void LateUpdate () {
		if ((Input.GetKey ("left")||(Input.GetMouseButton(0)&&Input.mousePosition.x<Screen.width/2))&&(speed > -maxSpeed))
       		speed = speed - acceleration * Time.deltaTime;
     	else if( (Input.GetKey ("right")||(Input.GetMouseButton(0)&&Input.mousePosition.x>Screen.width/2))&&(speed < maxSpeed))
       		speed = speed + acceleration * Time.deltaTime;
     	else {
       		if(speed > deceleration * Time.deltaTime)
         		speed = speed - deceleration * Time.deltaTime;
       		else if(speed < -deceleration * Time.deltaTime)
         		speed = speed + deceleration * Time.deltaTime;
       		else
        		speed = 0;
		}
		
		motion=speed * Time.deltaTime;
		
		motion+=shiftAmount;
		shiftAmount=0f;
		positionOnOrbit+=motion;		
		positionOnOrbit=(positionOnOrbit+1)%1;

		// If no collision allow the user to move in the tubes.
		if (!onCollision){
			transform.position=RotateAroundPoint(new Vector3(0f, -radius, 0f), rotationAxis.transform.position, rotationAxis.transform.rotation*Quaternion.Euler(0f,0f,positionOnOrbit*360));
			transform.rotation=rotationAxis.transform.rotation*Quaternion.Euler(0f,0f,positionOnOrbit*360);
		}			
	}
}