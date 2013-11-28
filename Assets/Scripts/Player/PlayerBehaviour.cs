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


	// HUD management variables.
	public GameObject nav;
	private ScoreManager scoreScript;
	public GameObject camera;
	private HUD hudScript;

	// Shift setter.
	public void Shift(float shiftAmount){
		this.shiftAmount=shiftAmount;
	}

	//public static float horizontalSpeed=200f;
	
	void Start () {
		//TODO: move all the score logic to another script
		// Initialization for the HUD.
		coins = 0;
		//TODO: assign by instance reference
		nav = GameObject.Find("Navigation");
		scoreScript = nav.GetComponent<ScoreManager>();

		camera = GameObject.Find("Main Camera");
		hudScript = camera.GetComponent<HUD>();

		//transform.position=new Vector3(0,-radius,depth);
		//Camera.main.transform.position=Vector3.down*cameraRadius;
	}

	
	void OnTriggerEnter(Collider other) {

		Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Coin(Clone)")
		{
			Destroy(other.gameObject);
			coins++;
			scoreScript.currentScore += 25.0f;
		}else{
			// Notify the score manager the game is over.
			hudScript.running = false;

			// Destroy the ship.
			onCollision=true;
			NavigationController.speed=0f;
			motion=0f;
			GetComponent<Detonator>().Explode();
		}   
    }

	private Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle){
		return angle * ( point - pivot) + pivot;
	}
	
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

		if (!onCollision){
			transform.position=RotateAroundPoint(new Vector3(0f, -radius, 0f), rotationAxis.transform.position, rotationAxis.transform.rotation*Quaternion.Euler(0f,0f,positionOnOrbit*360));
			transform.rotation=rotationAxis.transform.rotation*Quaternion.Euler(0f,0f,positionOnOrbit*360);
		}			

	}
}