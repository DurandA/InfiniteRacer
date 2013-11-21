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
	public Transform coin;


	public virtual void SpawnCoins(){
		//Debug.Log();
		Transform[] coins = new Transform[10];
		float k = 0f;
		for (int i =0; i < 5; i++){
			Vector3 v = spline.GetPositionOnSpline(k);
			//Debug.Log(v.x + " " + v.y);
			v.x = v.x-15;
			v.y = v.y-15;
			//v.z = v.z-20;
			coins[i] = Instantiate(coin,v,spline.GetOrientationOnSpline(0)) as Transform;
			k = k + 0.02f;
			coins[i].transform.parent=transform;
		}
	}

	/*
	 * TODO: Spawn obstacles as blocks children
	 */
	public virtual void SpawnObstacles() {
		for (float i = 0.0f; i < 1.0f; i = i + 0.5f)
		{
			//obstacle type
			int obstacleType = Random.Range(1,4);
			switch (obstacleType)
			{
			case 1:
				createBlock(i);
				break;
			case 2:
				createTwoBlocks(i);
				break;
			case 3:
				createBlower(i);
				break;
			default:
				break;
			}
		}
	}
	
	private void createBlock(float newPosition){
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
	}

	private void createTwoBlocks(float newPosition){
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		Transform obs2 = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs2.transform.Rotate(new Vector3(0,0,180),Space.Self);
		obs2.transform.parent=transform;
	}
	
	private void createBlower(float newPosition){
		Transform obs = Instantiate(blowerObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
	}
}