﻿using UnityEngine;
using System.Collections;

public class SoundAnalysis : MonoBehaviour {
	public AudioClip background_sound;
	
	void Start () {
		//audio.PlayOneShot(background_sound);
		// Causes 2 musics at the same time ...
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);
		int i = 1;
		while (i < 1023) {
			//Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.yellow);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.red);
			i++;
		}
	}
}