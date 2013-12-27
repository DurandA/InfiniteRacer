using UnityEngine;
using System.Collections;

public class PipeBehaviour : NavigationBehaviour {
		
	public Transform blockObstacle;
	public Transform hexaObstacle;
	public Transform blowerObstacle;
	public Transform cannonObstacle;
	public Transform lazer;

	public Transform coin;

	public virtual void SpawnCoins(float positionOnSpline, int number, float shift){
		float shiftAdd = shift;
		Transform[] coins = new Transform[number];
		for (int i =0; i < number; i++){
			Vector3 v = spline.GetPositionOnSpline(positionOnSpline);
			coins[i] = Instantiate(coin,v,spline.GetOrientationOnSpline(0)) as Transform;
			positionOnSpline = positionOnSpline + 0.03f;
			coins[i].transform.parent=transform;
			coins[i].transform.Rotate(new Vector3(0,0,shiftAdd),Space.Self);
			shiftAdd += shift;
		}
	}
	
	// --------------------------------------------------------------------------------------
	// Spawn obstacles.
	// --------------------------------------------------------------------------------------
	
	public virtual void Awake() {
		float newPosition = 0.2f;
		Transform obs = Instantiate(lazer,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		float spineType = 0;
		if(spline.gameObject.name == "Pipe 0 full(Clone)")
		{
			createTwoBlocks(0f);
			createTwoBlocks(0.2f);
			createTwoBlocks(0.4f);
			createTwoBlocks(0.6f);
			createTwoBlocks(0.8f);
			createTwoBlocks(0.99f);
		}
		if(spline.gameObject.name == "Pipe 90 full(Clone)")
		{
			createTwoBlocks(0f);
			createTwoBlocks(0.2f);
			createTwoBlocks(0.4f);
			createTwoBlocks(0.6f);
			createTwoBlocks(0.8f);
			createTwoBlocks(0.99f);
		}
		if(spline.gameObject.name == "Pipe 90 half(Clone)")
		{
			createTwoBlocks(0f);
			createTwoBlocks(0.2f);
			createTwoBlocks(0.4f);
			createTwoBlocks(0.6f);
			createTwoBlocks(0.8f);
			createTwoBlocks(0.99f);
		}
		if(spline.gameObject.name == "Pipe 90 half+s(Clone)")
		{
			createTwoBlocks(0f);
			createTwoBlocks(0.2f);
			createTwoBlocks(0.4f);
			createTwoBlocks(0.6f);
			createTwoBlocks(0.8f);
			createTwoBlocks(0.99f);
		}
	
		float start = 0.1f;
		float increment = 0.5f;
		
		if(GameConfiguration.Instance.speed > 170.0){
			start = 0.3f;
			increment = 0.6f;
		} 
		
		/*for (float i = start; i < 1.0f; i = i + increment)
		{
			int obstacleType = Random.Range(1,6);

			if(i>0.4)
			{
				switch (obstacleType)
				{
				case 1:
					SpawnCoins(i+0.3f,7,8.0f);
					break;
				case 2:
					SpawnCoins(i+0.3f,10,0.0f);
					break;
				case 3:
					SpawnCoins(i+0.3f,15,0.0f);
					break;
				default:
					break;
				}
			}
			
			//obstacle type
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
			case 4:
				createCannon();
				break;
			case 5:
				createHexa(i);
				break;
			default:
				break;
			}
		}*/
	}

	private void spawnForFullPipe(){

	}

	private void spawnForFullPipe90(){

	}

	private void spawnForHalfPipe90(){

	}

	private void spawnForHalfPipe90s(){

	}
	
	private void createBlock(float newPosition){
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		obs.transform.Rotate(new Vector3(180,0,0),Space.Self);
	}
	
	private void createTwoBlocks(float newPosition){
		float x = 	Random.Range(0,180);
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		obs.transform.Rotate(new Vector3(180,0,x),Space.Self);

		Transform obs2 = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs2.transform.Rotate(new Vector3(180,0,x+180),Space.Self);
		obs2.transform.parent=transform;
	}

	private void createHexa(float newPosition){
		if (hexaObstacle != null) {
			Transform hexa = Instantiate (hexaObstacle, spline.GetPositionOnSpline (newPosition), spline.GetOrientationOnSpline (newPosition)) as Transform;
			hexa.transform.parent = transform;
		}
	}
	
	private void createBlower(float newPosition){
		Transform obs = Instantiate(blowerObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
	}
	
	private void createCannon(){
		// No lazer for 90° tubes.
		if (cannonObstacle != null)
		{
			Transform cannon = Instantiate (cannonObstacle, spline.GetPositionOnSpline (0.85f), spline.GetOrientationOnSpline (0.85f)) as Transform;
			cannon.transform.Rotate (new Vector3 (180, 0, 0), Space.Self);
			cannon.transform.Translate (new Vector3 (0, -15, 0), Space.Self);
			
			cannon.transform.parent = transform;
		}
	}

}
