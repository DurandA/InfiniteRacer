﻿using UnityEngine;
using System.Collections;

public class Pipe90Behaviour : PipeBehaviour {
	float minpos = 0.3f;

	void Awake(){
		SpawnCoinPack(0.1f);
		SpawnBooster(0.2f);
		SpawnShield(0.3f);
		SpawnSlowDown(0.4f);
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
			createLaser(minpos);
			break;
		}
		createTwoBlocks(minpos+ 0.4f);
		SpawnCoins(minpos+0.1f, 15,0.0f);

	}
}
