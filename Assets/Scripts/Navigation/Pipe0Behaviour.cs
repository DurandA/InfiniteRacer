using UnityEngine;
using System.Collections;

public class Pipe0Behaviour : PipeBehaviour {

	public void Awake(){
		SpawnCoins(0.3f,14,0.2f);
		createHexa(0.2f);
	}
}
