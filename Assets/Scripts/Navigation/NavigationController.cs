using UnityEngine;

/*
 * Author: Arnaud Durand
 */

public class NavigationController : MonoBehaviour {

	// --------------------------------------------------------------------------------------
	// Variables.
	// --------------------------------------------------------------------------------------

	public float speed = 100f;				// Check loader.cs as values are reset in there
	public float speedIncrement = 0.05f;	// from a current game to a new game.
	
	private float splinePosition = 0f;
	private NavigationBehaviour[] pipes;
	private int pipeIdx = 0;

	public NavigationBehaviour[] pipePrefabs;

	public Transform rotationAxis;
	public PlayerBehaviour player;
	public GameObject occlusionLight;
	private GameObject navigation;
	private NavigationController navigationScript;

	// --------------------------------------------------------------------------------------
	// Block creation.
	// --------------------------------------------------------------------------------------

	void RespawnBlocks(float speed){
		Destroy(pipes[pipeIdx].gameObject);
		
		int prvIdx=(pipeIdx+pipes.Length-1) % pipes.Length;
		Spline previousSpline=pipes[prvIdx].GetComponent<Spline>();
		
		pipes[pipeIdx]=Instantiate(pipePrefabs[Random.Range(1,pipePrefabs.Length)], previousSpline.GetPositionOnSpline(1f), previousSpline.GetOrientationOnSpline(1f)) as NavigationBehaviour;
		pipes[pipeIdx].transform.parent=transform;

		float torque=Random.Range(0,12) * 60f;
		
		pipes[pipeIdx].torque=torque;
		pipes[pipeIdx].SpawnSpineContent(speed);
		pipes[pipeIdx].transform.Rotate(new Vector3(0,0,torque), Space.Self);
		pipeIdx=(pipeIdx+1)%pipes.Length;
	}

	// --------------------------------------------------------------------------------------
	// Start && Update.
	// --------------------------------------------------------------------------------------

	void Start(){
		pipes=new NavigationBehaviour[5];
		navigation = GameObject.Find("Navigation");
		navigationScript= navigation.GetComponent<NavigationController>();

		Vector3 nextPosition=Vector3.zero;
		Quaternion nextOrientation=Quaternion.identity;
		Spline nextSpline=null;

		// Spawn first tube (for animation).
		pipes[0]=Instantiate (pipePrefabs[0], nextPosition, nextOrientation) as NavigationBehaviour;
		nextSpline=pipes[0].spline;
		nextPosition=nextSpline.GetPositionOnSpline(1f);
		nextOrientation=nextSpline.GetOrientationOnSpline(1f);
		pipes[0].transform.parent=transform;

		// Spawn second tube (for animation).
		pipes[1]=Instantiate (pipePrefabs[2], nextPosition, nextOrientation) as NavigationBehaviour;
		nextSpline=pipes[1].spline;
		nextPosition=nextSpline.GetPositionOnSpline(1f);
		nextOrientation=nextSpline.GetOrientationOnSpline(1f);
		pipes[1].transform.parent=transform;

		// Spawn the rest of the initial tubes.
		for(int i=2; i<pipes.Length; i++){
			pipes[i]=Instantiate (pipePrefabs[Random.Range(1,pipePrefabs.Length)], nextPosition, nextOrientation) as NavigationBehaviour;

			nextSpline=pipes[i].spline;
			nextPosition=nextSpline.GetPositionOnSpline(1f);
			nextOrientation=nextSpline.GetOrientationOnSpline(1f);
			pipes[i].transform.parent=transform;
		}
	}
	
	void Update (){
		Spline spline=pipes[pipeIdx].spline;
		splinePosition+=(speed*Time.deltaTime) / spline.Length;
		
		if (splinePosition>1f)/*Change current tube*/{
			float exceedingDistance=(splinePosition%1) * spline.Length;
			Vector3 sOffset=-spline.GetPositionOnSpline(1f);
			foreach (NavigationBehaviour tube in pipes){
      	      tube.transform.position+=sOffset;
       		 }
			RespawnBlocks(navigationScript.speed); //Warning: change tubeIdx
			spline=pipes[pipeIdx].spline;
			splinePosition=exceedingDistance/spline.Length;
			player.Shift(-pipes[pipeIdx].torque/360);
		}
		
		Vector3 offset=-spline.GetPositionOnSpline(splinePosition);
		foreach (NavigationBehaviour tube in pipes){
            tube.transform.position+=offset;
        }

		rotationAxis.rotation=spline.GetOrientationOnSpline(splinePosition);
	}
}