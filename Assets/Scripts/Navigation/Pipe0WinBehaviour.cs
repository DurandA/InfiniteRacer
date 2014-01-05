using UnityEngine;
using System.Collections;

public class Pipe0WinBehaviour : PipeBehaviour {

	public void Awake(){
		SpawnCoins(0.3f,13,0.1f);
		createBlower(0.8f);
	}


}
