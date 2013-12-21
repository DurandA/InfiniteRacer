using UnityEngine;
using System.Collections;
	
public class PlayerBehaviour : MonoBehaviour {

	// ----------------------------------------------------------------------------
	// Variables.
	// ----------------------------------------------------------------------------

	public float radius=20f;
	public float depth=12;
	public float cameraRadius=6f;
	public float speed=0f;
	public float maxSpeed=1.2f;
	public float acceleration=4f;
	public float deceleration=2.5f;

	public float motion;
	public bool onCollision=false;
	public Transform rotationAxis;

	private bool ft = false;
	private float positionOnOrbit=0f;
	private float shiftAmount=0f;

	// Scripts references.
	public GameObject navigation;
	public GameObject camera;

	private HUD hudScript;
	private ScoreManager scoreScript;
	private NavigationController navigationScript;

	// ----------------------------------------------------------------------------
	// Setter.
	// ----------------------------------------------------------------------------

	public void Shift(float shiftAmount){
		this.shiftAmount=shiftAmount;
	}

	// ----------------------------------------------------------------------------
	// Start && Late Update.
	// ----------------------------------------------------------------------------

	//public static float horizontalSpeed=200f;
	void Start () {
		//transform.position=new Vector3(0,-radius,depth);
		//Camera.main.transform.position=Vector3.down*cameraRadius;
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