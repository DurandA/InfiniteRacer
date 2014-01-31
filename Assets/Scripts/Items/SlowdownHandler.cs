using UnityEngine;
using System.Collections;

/*
 * Author: Arnaud Durand
 */
public class SlowdownHandler : MonoBehaviour, Powerup {

	public Texture2D _icon;

	public IEnumerator reduceSpeed(){
		float startTimer = Time.time;


		while(startTimer+1.0f > Time.time){
			GameObject.Find("Dust Particles").GetComponent<ParticleEmitter> ().localVelocity = new Vector3 (0,10,0);
			GameConfiguration.Instance.speed -= 80f;
			yield return null;
		}

		GameObject.Find("Dust Particles").GetComponent<ParticleEmitter> ().localVelocity = new Vector3 (0,150,0);
	}

	#region Powerup implementation
	public void Trigger ()
	{
		StartCoroutine(reduceSpeed());
	}

	public Texture2D icon {
		get {
			return _icon;
		}
	}
	#endregion
}