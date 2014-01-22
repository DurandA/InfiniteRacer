using UnityEngine;
using System.Collections;

public class PipeBehaviour : NavigationBehaviour { 
		
	public Transform blockObstacle;
	public Transform hexaObstacle;
	public Transform blowerObstacle;
	public Transform cannonObstacle;
	public Transform laserObstacle;
	public Transform coin;
	public Transform shield;
	public Transform booster;
	public Transform coinPack;
	public Transform slowDown;

	public virtual void SpawnShield(float positionOnSpline){
		Transform obs = Instantiate(shield,spline.GetPositionOnSpline(positionOnSpline),spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}
	public virtual void SpawnBooster(float positionOnSpline){
		Transform obs = Instantiate(booster,spline.GetPositionOnSpline(positionOnSpline),spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}
	public virtual void SpawnCoinPack(float positionOnSpline){
		Transform obs = Instantiate(coinPack,spline.GetPositionOnSpline(positionOnSpline),spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}
	public virtual void SpawnSlowDown(float positionOnSpline){
		Transform obs = Instantiate(slowDown,spline.GetPositionOnSpline(positionOnSpline),spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}

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

	
	public void createBlock(float newPosition){
		float x = 	Random.Range(0,360);
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		obs.transform.Rotate(new Vector3(180,0,x),Space.Self);
	}
	
	public void createTwoBlocks(float newPosition){
		float x = 	Random.Range(0,360);
		Transform obs = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		obs.transform.Rotate(new Vector3(180,0,x),Space.Self);

		Transform obs2 = Instantiate(blockObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs2.transform.Rotate(new Vector3(180,0,x+180),Space.Self);
		obs2.transform.parent=transform;
	}

	public void createHexa(float newPosition){
		if (hexaObstacle != null) {
			Transform hexa = Instantiate (hexaObstacle, spline.GetPositionOnSpline (newPosition), spline.GetOrientationOnSpline (newPosition)) as Transform;
			hexa.transform.parent = transform;
		}
	}
	
	public void createBlower(float newPosition){
		Transform obs = Instantiate(blowerObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
	}

	public void createLaser(float newPosition){
		Transform obs = Instantiate(laserObstacle,spline.GetPositionOnSpline(newPosition),spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
	}
	
	public void createCannon(){
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
