using UnityEngine;
using System.Collections;

/*
 * Author : Thomas Rouvinez
 * Description : animation linked functions to play the passby sounds
 * 				according to the markers on the animation.
 * 
 */
public class PassbySound : MonoBehaviour {

	public AudioSource passby1;
	public AudioSource passby2;

	private void playSound1()
	{
		passby1.audio.Play ();
	}

	private void playSound2()
	{
		passby2.audio.Play ();
	}
}