using UnityEngine;
using System.Collections;

/*
 * Class to animate the wireframed earth planet of the main menu.
 */
public class EarthRotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.up * Time.deltaTime, Space.Self);
		this.transform.Rotate(Vector3.right * Time.deltaTime, Space.Self);
	}
}
