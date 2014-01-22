using UnityEngine;
using System.Collections;

public class OpenPipeBehaviour : PipeBehaviour {

	float minPos = 0.3f;


	public void Awake(){
		SpawnPowerUp(0.1f);
		int rand = 	Random.Range(0,3);
		int rand2 = 	Random.Range(0,3);
		switch (rand)
		{
		case 1:
			createLaser(minPos);
			break;
		case 2:
			SpawnCoins(minPos,10,0.0f);
			break;
		default:
			createLaser(minPos);
			break;
		}
		switch (rand2)
		{
		case 1:
			SpawnCoins(minPos+0.3f,10,0.0f);
			break;
		case 2:
			SpawnCoins(0.4f,10,0.0f);			
			break;
		default:
			createLaser(minPos+0.3f);
			break;
		}
		createLaser(0.8f);

	}
}
