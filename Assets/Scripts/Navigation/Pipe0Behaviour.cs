using UnityEngine;
using System.Collections;

public class Pipe0Behaviour : PipeBehaviour {

	public float minPos = 0.2f;
	public float maxPos = 0.9f;
	private float tempPosition;
	private float tempRotation;

	public GameObject obsPC1;

	public void Awake(){
		curved = false;

		// ONLY FOR TESTS OF THE NEW OBSTACLES.
		tempPosition = Random.Range(minPos, maxPos);
		tempRotation = Random.Range(0, 360);
		StartCoroutine(spawnObstacle(obsPC1.transform, this.transform, tempPosition, new Vector3(0f, 0f, tempRotation)));
	}
}
