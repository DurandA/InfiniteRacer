using UnityEngine;
using System.Collections;

public class Pipe0WinBehaviour : PipeBehaviour {

	public float minPos = 0.2f;
	public float maxPos = 0.9f;
	
	public void Awake(){
		int rand = 	Random.Range(0,3);
		int rand2 = 	Random.Range(0,3);
		Debug.Log(rand + "  " + rand2);
		switch (rand)
		{
		case 1:
			createHexa(minPos);
			break;
		case 2:
			createBlower(minPos);
			break;
		default:
			createLaser(minPos);
			break;
		}
		switch(rand2)
		{
		case 1:
			SpawnCoins(0.4f,4+rand+rand2,8.0f);
			createTwoBlocks(0.7f);
			break;
		case 2:
			createTwoBlocks(0.4f);
			createBlock(0.5f);
			createTwoBlocks(0.6f);
			break;
		default:
			SpawnCoins(0.4f,4+rand+rand2,8.0f);
			createTwoBlocks(0.7f);
			break;
		}
		switch(rand)
		{
		case 1:
			createBlock(maxPos);
			break;
		case 2:
			createTwoBlocks(maxPos);
			break;
		default:
			createTwoBlocks(maxPos);
			break;
		}
	}


}
