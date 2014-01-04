using UnityEngine;
using System.Collections;

public class Pipe90Behaviour : PipeBehaviour {

	void Awake(){
		createHexa(0.2f);
		createBlower(0.4f);
	}
}
