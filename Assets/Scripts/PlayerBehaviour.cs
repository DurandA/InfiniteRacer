using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float radius=12f;
	public float depth=12;
	public float cameraRadius=6f;
	private float speed=0f;
	public float maxSpeed=2f;
	public float acceleration=1f;
	public float deceleration=1f;
	
	
	// Use this for initialization
	void Start () {
		transform.position=new Vector3(0,-radius,depth);
		Camera.main.transform.position=Vector3.down*cameraRadius;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey ("left")&&(speed > -maxSpeed))
			speed = speed - acceleration * Time.deltaTime;
		else if (Input.GetKey ("right")&&(speed < maxSpeed))
			speed = speed + acceleration * Time.deltaTime;
		else {
			if(speed > deceleration * Time.deltaTime)
				speed = speed - deceleration * Time.deltaTime;
			else if(speed < -deceleration * Time.deltaTime)
				speed = speed + deceleration * Time.deltaTime;
			else
				speed = 0;
		}
		
		float motion=speed * Time.deltaTime;
		
		//better use rotate around API
		//transform.position=new Vector3(Mathf.Sin(relativePlayerPosition*Mathf.PI)*radius,-Mathf.Cos(relativePlayerPosition*Mathf.PI)*radius,transform.position.z);
		transform.RotateAround (Vector3.zero, Vector3.forward, motion * 360);
		
		Camera.main.transform.transform.RotateAround (Vector3.zero, Vector3.forward, motion * 360);
	}
		
}
