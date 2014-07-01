using UnityEngine;
using System.Collections;

public class Pipe90Behaviour : PipeBehaviour {
	float minpos = 0.3f;

	void Awake(){
		SpawnPowerUp(0.1f);
		int rand = 	Random.Range(0,3);
		switch (rand)
		{
		case 1:
			createHexa(minpos);
			break;
		case 2:
			createBlower(minpos);
			break;
		default:
			//createLaser(minpos);
			break;
		}
	
		SpawnCoins(minpos+0.1f, 15,0.0f);
	}
}
