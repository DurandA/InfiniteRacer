using UnityEngine;
using System.Collections;

public class Pipe90Behaviour : PipeBehaviour {
	float minpos = 0.3f;

	void Awake(){
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
			createBlower(minpos);
			break;
		}
		createTwoBlocks(0.4f);

	}
}
