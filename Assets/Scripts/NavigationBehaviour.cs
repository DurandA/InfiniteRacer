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

	
	/*
	 * TODO: Spawn obstacles as blocks children
	 */
	public virtual void SpawnObstacles() {
		for(float i = 0; i < 1.0f; i=i+0.25f)
		{
			int total = Random.Range(0,4);
			switch(total)
			{
			case 0 : 
				Debug.Log("");
				break;
			case 1 :
				createBlower(i);
				break;
			case 2 : 
				createTwoBlocks(i);
				break;
			case 3 : 
				createBlock(i);
				break;
				
			}
		}

		SpawnCoins();
	}

	public virtual void SpawnCoins(){
		//Debug.Log();

		Transform[] coins = new Transform[10];
		float k = 0f;
		for (int i =0; i < 5; i++){

			coins[i] = Instantiate(coin,spline.GetPositionOnSpline(k),spline.GetOrientationOnSpline(0)) as Transform;
			k = k + 0.1f;
			coins[i].transform.parent=transform;
		}

		

	}
	
	private void createBlock(float newPosition){
		float random =  Random.value;
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;

		
	}

	private void createTwoBlocks(float newPosition){

		float random = Random.value;
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
