using UnityEngine;
using System.Collections;

public class CameraInterpolator : MonoBehaviour {
	
	public Transform cameraTarget;
	public Transform cameraViewTarget;

	void Start () {
		transform.position = cameraTarget.position;
		transform.rotation = cameraTarget.rotation;
	}

	void Update () {
		if(cameraTarget != null){
			// Catch on the target's position.
			transform.position = Vector3.Slerp(transform.position, cameraTarget.position, 0.1f);

			// Check if hardcore mode is on or not and uses the right type of camera.
			if(GameConfiguration.Instance.gameMode == 0){
				transform.rotation = Quaternion.Slerp(transform.rotation, cameraTarget.rotation, 0.035f);
			}
			else{
				transform.rotation = Quaternion.Slerp(transform.rotation, cameraTarget.rotation, 0.04f);
				cameraViewTarget.rotation = Quaternion.Slerp(cameraViewTarget.rotation, cameraTarget.rotation, 0.04f);
				transform.LookAt(cameraViewTarget);
			}
		}
		else {
			DestroyImmediate(this);
		}
	}
}