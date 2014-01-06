using UnityEngine;
using System.Collections;

public class AnimSoundTrigger : MonoBehaviour {

	public AudioSource flyby1;
	public AudioSource flyby2;

	void triggerFlyBy1()
	{
		flyby1.audio.Play();
	}

	void triggerFlyBy2()
	{
		flyby2.audio.Play();
	}
}
