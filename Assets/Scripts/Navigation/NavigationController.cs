using UnityEngine;

/*
 * Author: Arnaud Durand
 */
public class NavigationController : MonoBehaviour {
	
	public static float speed=90f;
	public float speedIncrement = 0.05f;
	
	private float splinePosition=0f;
	//public static float acceleration=1f;
	
	private NavigationBehaviour[] pipes;
	private int pipeIdx=0;

	public NavigationBehaviour[] pipePrefabs;
	
	//could be static

	
	public Transform rotationAxis;
	public PlayerBehaviour player;
	
	void RespawnBlocks(){
		Destroy(pipes[pipeIdx].gameObject);
		
		int prvIdx=(pipeIdx+pipes.Length-1)%pipes.Length;
		Spline previousSpline=pipes[prvIdx].GetComponent<Spline>();
		
		
		pipes[pipeIdx]=Instantiate(pipePrefabs[Random.Range(0,pipePrefabs.Length)], previousSpline.GetPositionOnSpline(1f), previousSpline.GetOrientationOnSpline(1f)) as NavigationBehaviour;
		pipes[pipeIdx].transform.parent=transform;

		float torque=Random.Range(0,12)*60f;
		
		pipes[pipeIdx].torque=torque;
		pipes[pipeIdx].SpawnSpineContent();
		pipes[pipeIdx].transform.Rotate(new Vector3(0,0,torque), Space.Self);
		
		
		pipeIdx=(pipeIdx+1)%pipes.Length;
	}
	
	
	void Start(){
		pipes=new NavigationBehaviour[5];
		
		Vector3 nextPosition=Vector3.zero;
		Quaternion nextOrientation=Quaternion.identity;
		Spline nextSpline=null;
		
		for(int i=0; i<pipes.Length; i++){
			pipes[i]=Instantiate (pipePrefabs[0], nextPosition, nextOrientation) as NavigationBehaviour;

			nextSpline=pipes[i].spline;
			nextPosition=nextSpline.GetPositionOnSpline(1f);
			nextOrientation=nextSpline.GetOrientationOnSpline(1f);
			pipes[i].transform.parent=transform;
		}
	}
	
	void Update (){
		Spline spline=pipes[pipeIdx].spline;
		splinePosition+=(speed*Time.deltaTime)/spline.Length;
		
		if (splinePosition>1f)/*Change current tube*/{
			float exceedingDistance=(splinePosition%1)*spline.Length;
			Vector3 sOffset=-spline.GetPositionOnSpline(1f);
			foreach (NavigationBehaviour tube in pipes){
      	      tube.transform.position+=sOffset;
       		 }
			RespawnBlocks(); //Warning: change tubeIdx
			spline=pipes[pipeIdx].spline;
			splinePosition=exceedingDistance/spline.Length;
			player.Shift(-pipes[pipeIdx].torque/360);
		}
		
		Vector3 offset=-spline.GetPositionOnSpline(splinePosition);
		foreach (NavigationBehaviour tube in pipes){
            tube.transform.position+=offset;
        }
		rotationAxis.rotation=spline.GetOrientationOnSpline(splinePosition);

		// Increment speed.
		speed += speedIncrement;
	}
	
}
