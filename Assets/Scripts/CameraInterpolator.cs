﻿using UnityEngine;
using System.Collections;

public class CameraInterpolator : MonoBehaviour {
	
	public Transform cameraTarget;
	
	// Use this for initialization
	void Start () {
		transform.position=cameraTarget.position;
		transform.rotation=cameraTarget.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraTarget == null)
			DestroyImmediate(this);
		else {
			transform.position=Vector3.Lerp(transform.position, cameraTarget.position, 0.3f);
			transform.rotation=Quaternion.Lerp(transform.rotation, cameraTarget.rotation, 0.15f);
		}
	}
}