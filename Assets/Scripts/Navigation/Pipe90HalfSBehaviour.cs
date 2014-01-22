using UnityEngine;
using System.Collections;

public class Pipe90HalfSBehaviour : PipeBehaviour {

	public void Awake(){
		SpawnPowerUp(0.1f);
		createBlower(0.2f);
		createLaser(0.4f);	
		SpawnCoins(0.5f,7,8.0f);


	}

}
