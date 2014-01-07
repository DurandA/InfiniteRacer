using UnityEngine;
using System.Collections;

public class Pipe90Behaviour : PipeBehaviour {
	float minpos = 0.3f;

	void Awake(){
		int rand = 	Random.Range(0,3);
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
		createTwoBlocks(0.4f);

	}
}
