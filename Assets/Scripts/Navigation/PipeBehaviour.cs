using UnityEngine;
using System.Collections;

public class PipeBehaviour : NavigationBehaviour { 
		
	// -------------------------------------------------------------------------------------
	// Variables.
	// -------------------------------------------------------------------------------------

	private int boosterProbability = 15; 	// 2/30 chances to appear
	private int shieldProbability = 1; 		// 3/30 chances to appear
	private int slowDownProbability = 1;	// 2/30 chances to appear
	private int coinPackProbability = 2; 	// 2/30 chances to appear

	private GameObject navigation;
	private ObstacleManager spawnableTypes;

	// -------------------------------------------------------------------------------------
	// Functions.
	// -------------------------------------------------------------------------------------

	public void Start(){
		navigation = GameObject.Find("Navigation");
		spawnableTypes = navigation.GetComponent<ObstacleManager>();
	}

	public virtual void SpawnPowerUp(float postionOnSpline){
		// max 20/30 that a power up (each power up has max 5/30 to appear) appears and min 10/30 that no power ups appear
		// min 4/40 that a power up (each power up has min 1/30 to appear) appears and max 26/30 that no power ups appear
		int rand = Random.Range(0,30);

		if(rand >= 0 && rand <= boosterProbability) {
			SpawnBooster(postionOnSpline); Debug.Log("spawn booset " + rand);
		} 
		else if (rand > boosterProbability && rand <= (boosterProbability +shieldProbability)) {
			SpawnShield(postionOnSpline); Debug.Log("spawn shield " + rand);
		} 
		else if (rand > (boosterProbability+shieldProbability) && rand <= (boosterProbability +shieldProbability+slowDownProbability)) {
			SpawnSlowDown(postionOnSpline); Debug.Log("spawn slow down " + rand);
		} 
		else if(rand > (boosterProbability +shieldProbability+slowDownProbability) && rand <= (boosterProbability +shieldProbability+slowDownProbability+coinPackProbability)){
			SpawnCoinPack(postionOnSpline);  Debug.Log("spawn coin pack " + rand);
		}
	}

	// -------------------------------------------------------------------------------------
	// Power-ups.
	// -------------------------------------------------------------------------------------

	public virtual void SpawnShield(float positionOnSpline){
		Transform obs = Instantiate(spawnableTypes.shield, spline.GetPositionOnSpline(positionOnSpline), spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}

	public virtual void SpawnBooster(float positionOnSpline){
		Transform obs = Instantiate(spawnableTypes.booster, spline.GetPositionOnSpline(positionOnSpline), spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}

	public virtual void SpawnCoinPack(float positionOnSpline){
		Transform obs = Instantiate(spawnableTypes.coinPack, spline.GetPositionOnSpline(positionOnSpline), spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}

	public virtual void SpawnSlowDown(float positionOnSpline){
		Transform obs = Instantiate(spawnableTypes.slowDown, spline.GetPositionOnSpline(positionOnSpline), spline.GetOrientationOnSpline(positionOnSpline)) as Transform;
		obs.transform.parent=transform;
	}

	public virtual void SpawnCoins(float positionOnSpline, int number, float shift){
		float shiftAdd = shift;
		Transform[] coins = new Transform[number];

		for (int i = 0; i < number; i++){
			Vector3 v = spline.GetPositionOnSpline(positionOnSpline);
			coins[i] = Instantiate(spawnableTypes.coin, v, spline.GetOrientationOnSpline(0)) as Transform;
			positionOnSpline = positionOnSpline + 0.03f;

			// Attach coin to parent for automatic destroying.
			coins[i].transform.parent = transform;

			// Set coin initial rotation.
			coins[i].transform.Rotate(new Vector3(0,0,shiftAdd),Space.Self);
			shiftAdd += shift;
		}
	}

	// -------------------------------------------------------------------------------------
	// Obstacles.
	// -------------------------------------------------------------------------------------
	
	public void createBlock(float newPosition){
		float x = (Random.Range(0,6) * 60f);
		Transform obs = Instantiate(spawnableTypes.getBlockObstacle(), spline.GetPositionOnSpline(newPosition), spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent=transform;
		obs.transform.Rotate(new Vector3(180,0,x),Space.Self);
	}

	public void createHexa(float newPosition){
		Transform hexa = Instantiate (spawnableTypes.hexaObstacle, spline.GetPositionOnSpline (newPosition), spline.GetOrientationOnSpline(newPosition)) as Transform;
		hexa.transform.parent = transform;
	}
	
	public void createBlower(float newPosition){
		Transform obs = Instantiate(spawnableTypes.blockObstacle, spline.GetPositionOnSpline(newPosition), spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent = transform;
	}

	public void createLaser(float newPosition){
		Transform obs = Instantiate(spawnableTypes.laserObstacle, spline.GetPositionOnSpline(newPosition), spline.GetOrientationOnSpline(newPosition)) as Transform;
		obs.transform.parent = transform;
	}
}