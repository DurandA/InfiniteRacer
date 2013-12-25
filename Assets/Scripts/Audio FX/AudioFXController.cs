using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System;

/*
 * Author: Arnaud Durand
 * Do NOT modify this script without author acknowledgement
 */
public class AudioFXController : MonoBehaviour {
	
	//singleton
	private static AudioFXController instance;
	
	public static AudioFXController Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject ("AudioFXController").AddComponent<AudioFXController> ();
			}
			
			return instance;
		}
	}
	
	public void OnApplicationQuit ()
	{
		instance = null;
	}
	//END singleton

	
	List<AudioFXHandler> listeners;

	public void NotifyAll(){
		foreach (AudioFXHandler listener in listeners){
			listener.UpdateFX(0f);
		}
	}
	
	public static void RegisterListener(AudioFXHandler listener){
		Instance.listeners.Add(listener);
	}

	public static void UnregisterListener(AudioFXHandler listener){
		Instance.listeners.Remove(listener);
	}



}
