using UnityEngine;

/*
 * Author: Arnaud Durand
 */
public class NavigationController : MonoBehaviour {
	
	public static float speed=120f;
	
	private float splinePosition=0f;
	//public static float acceleration=1f;
	
	public NavigationBehaviour[] tubes;
	private int tubeIdx=0;

	public NavigationBehaviour block0Prefab;
	public NavigationBehaviour block45Prefab;
	
	public Transform Ring;
	public Transform Player;
	
	void RespawnBlocks(){
		Destroy(tubes[tubeIdx].gameObject);
		
		int prvIdx=(tubeIdx+tubes.Length-1)%tubes.Length;
		Spline previousSpline=tubes[prvIdx].GetComponent<Spline>();
		
		tubes[tubeIdx]=Instantiate((Random.value>0.5)?block0Prefab:block45Prefab, previousSpline.GetPositionOnSpline(1f), previousSpline.GetOrientationOnSpline(1f)) as NavigationBehaviour;
		tubes[tubeIdx].transform.parent=transform;

		float torque=Random.Range(0,360);
		
		tubes[tubeIdx].torque=torque;
		tubes[tubeIdx].SpawnObstacles();
		tubes[tubeIdx].transform.Rotate(new Vector3(0,0,torque), Space.Self);
		
		
		tubeIdx=(tubeIdx+1)%tubes.Length;
	}
	

	
	
	void Start(){
		tubes=new NavigationBehaviour[6];
		
		Vector3 nextPosition=Vector3.zero;
		Quaternion nextOrientation=Quaternion.identity;
		Spline nextSpline=null;
		
		for(int i=0; i<tubes.Length; i++){
			tubes[i]=Instantiate (block0Prefab, nextPosition, nextOrientation) as NavigationBehaviour;

			nextSpline=tubes[i].spline;
			nextPosition=nextSpline.GetPositionOnSpline(1f);
			nextOrientation=nextSpline.GetOrientationOnSpline(1f);
			tubes[i].transform.parent=transform;
		}
	}
	
	void Update () {
		Spline spline=tubes[tubeIdx].spline;
		splinePosition+=(speed*Time.deltaTime)/spline.Length;
		
		if (splinePosition>1f)/*Change current tube*/{
			float exceedingDistance=(splinePosition%1)*spline.Length;
			Vector3 sOffset=-spline.GetPositionOnSpline(1f);
			foreach (NavigationBehaviour tube in tubes){
      	      tube.transform.position+=sOffset;
       		 }
			RespawnBlocks(); //Warning: change tubeIdx
			spline=tubes[tubeIdx].spline;
			splinePosition=exceedingDistance/spline.Length;
			
			Player.GetComponentInChildren<PlayerBehaviour>().Shift(-tubes[tubeIdx].torque/360);
			
		}
		
		Vector3 offset=-spline.GetPositionOnSpline(splinePosition);
		foreach (NavigationBehaviour tube in tubes){
            tube.transform.position+=offset;
        }
		
		Ring.rotation=spline.GetOrientationOnSpline(splinePosition);
		Player.rotation=spline.GetOrientationOnSpline(splinePosition);
		
		
	}
	
}
