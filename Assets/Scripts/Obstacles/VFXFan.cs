using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 */

public class VFXFan : MonoBehaviour {

	private int random;

	void Start()
	{
		random = Random.Range (100, 150);
	}

	void Update () {
		transform.Rotate(Vector3.up, Time.deltaTime * -1 * random);
	}
}