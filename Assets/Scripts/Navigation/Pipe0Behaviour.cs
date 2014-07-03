using UnityEngine;
using System.Collections;

public class Pipe0Behaviour : PipeBehaviour {

	public float minPos = 0.2f;
	public float maxPos = 0.9f;

	public void Awake(){
		curved = false;

		SpawnPowerUp(0.1f);
		int rand = Random.Range(0,3);
		int rand2 = Random.Range(0,3);
		switch (rand)
		{
			case 1:
				createHexa(minPos);
				break;
			case 2:
				createBlower(minPos);
				break;
			default:
				createBlower(minPos);
				break;
		}
		switch(rand2)
		{
			case 1:
				SpawnCoins(0.4f,4+rand+rand2,8.0f);
				break;
			case 2:
				createBlock(0.6f);
				break;
			default:
				SpawnCoins(0.4f,4+rand+rand2,8.0f);
				break;
		}
		switch(rand)
		{
		case 1:
			createBlock(maxPos);
			break;
		case 2:
			break;
		default:
			break;
		}
	}
}
