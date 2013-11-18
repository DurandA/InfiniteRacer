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
	public virtual void SpawnObstacles() {
		if(blockObstacle!=null){
			int total = Random.Range(1,5);
			for (int i = 0; i < total; i++)
			{
				if( i == 1 )
					createBlower();
				else
					createBlock();


			}
		}

			
	}
	
	private void createBlock(){
		
		float newPosition =Random.value;
		Debug.Log(newPosition);
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;

		
	}

	private void createTwoBlocks(){
		float newPosition =Random.value;
		Debug.Log(newPosition);
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		Transform obs2 = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs2.transform.Rotate(new Vector3(0,0,180),Space.Self);
		obs2.transform.parent=transform;

	}
	
	private void createBlower(){
		float newPosition =Random.value;
		Debug.Log(newPosition);
		Transform obs = Instantiate(blowerObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
	}

}
