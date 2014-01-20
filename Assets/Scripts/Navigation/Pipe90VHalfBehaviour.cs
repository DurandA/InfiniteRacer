using UnityEngine;
using System.Collections;

public class Pipe90VHalfBehaviour : PipeBehaviour {
	
	public void Awake(){
		int rand = 	Random.Range(0,3);
		if(rand== 2)
			SpawnCoins(0.2f,15,0.0f);
		else
			createLaser(0.3f);

		createLaser(0.6f);

		if(rand == 2)
			createBlower(0.9f);
		else 
			createLaser(0.9f);
	}
	
	
}
