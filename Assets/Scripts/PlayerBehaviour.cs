using UnityEngine;
using System.Collections;
	
public class PlayerBehaviour : MonoBehaviour {
	
	public float radius=12f;
	public float depth=12;
	public float cameraRadius=6f;
	private float speed=0f;
	public float maxSpeed=1f;
	public float acceleration=2f;
	public float deceleration=2f;
	bool ft = false;
	public Spline ring;
	private float positionOnRing=0f;
	private float motion;
	private float shiftAmount=0f;
	public static bool onCollision=false;
	public static int coins;

	public void Shift(float shiftAmount){
		this.shiftAmount=shiftAmount;
	}

	//public static float horizontalSpeed=200f;
	
	void Start () {
		//transform.position=new Vector3(0,-radius,depth);
		//Camera.main.transform.position=Vector3.down*cameraRadius;
	}

	
	void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Coin(Clone)")
		{
			coins++;
			ScoreManager.currentScore += 25;
		}else{
			// Notify the score manager the game is over.
			HUD.running = false;

			// Destroy the ship.
			onCollision=true;
			NavigationController.speed=0f;
			motion=0f;
			GetComponent<Detonator>().Explode();
		}   
    }
		
	// Update is called once per frame
	
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
		
		//Camera.main.transform.position=Vector3.back*speed*10;
		

			//Camera.main.transform.Translate(speed,0,0);
			//Camera.main.transform.position=Vector3.back*50;
		
		
		//Camera.main.transform.position=Vector3.back*50;
		
		motion=speed * Time.deltaTime;
		
		motion+=shiftAmount;
		shiftAmount=0f;
		positionOnRing+=motion;		
		positionOnRing=(positionOnRing+1)%1;

		if (!onCollision){
			transform.position=ring.GetPositionOnSpline(positionOnRing);
			transform.Rotate(new Vector3(0f, 0f, motion*360),Space.Self);
		}
		//transform.rotation=ring.GetOrientationOnSpline(positionOnRing);				
		
			
	}
}