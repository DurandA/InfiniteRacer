using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Spline))]
public class NavigationBehaviour : MonoBehaviour {
	
	
	
	public Spline spline
	{
		get {return GetComponent<Spline>();}
	}
	
	public float torque=0f;
	public Transform blockObstacle;
	public Transform blowerObstacle;
	
	/*
	 * TODO: Spawn obstacles as blocks children
	 */
	public virtual void SpawnObstacle() {
		float random =Random.value;

		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(random),spline.GetOrientationOnSpline(random)) as Transform;
				obs.transform.parent=transform;
		//Transform obs2 = Instantiate(blockObstacle,new Vector3(x,y,z),new Quaternion(-r_x,-r_y,r_z,r_w)) as Transform;
		//Transform obs2 = Instantiate(blockObstacle,spline.GetPositionOnSpline(random),spline.GetOrientationOnSpline(random)) as Transform;
		//	obs2.transform.Rotate(new Vector3(0,0,180),Space.Self);
		//	obs2.transform.parent=transform;
			
			
	}
	

	
}
