using UnityEngine;
using System.Collections;

public class Pipe0WinBehaviour : PipeBehaviour {

	public float minPos = 0.2f;
	public float maxPos = 0.9f;
	
	public void Awake(){
		SpawnPowerUp(0.1f);
		int rand = Random.Range(0,3);

		switch (rand){
		case 1:
			createHexa(minPos);
			break;
		case 2:
			createBlower(minPos);
			break;
		default:
			//createLaser(minPos);
			break;
		}

		int rand2 = Random.Range(0,3);

		switch(rand){
		case 1:
			SpawnCoins(0.4f,4+rand+rand2,8.0f);
			break;

		case 2:
			createBlock(0.5f);
			break;

		default:
			SpawnCoins(0.4f,4+rand+rand2,8.0f);
			break;
		}
	}
}