using UnityEngine;
using System.Collections;

public class Pipe90HalfSBehaviour : PipeBehaviour {

	public void Awake(){

		createBlower(0.1f);
		createLaser(0.3f);	
		SpawnCoins(0.3f,7,8.0f);


	}

}
