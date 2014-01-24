using UnityEngine;
using System.Collections;

/*
 * Author: Arnaud Durand
 */
public class SlowdownHandler : MonoBehaviour, Powerup {

	public Texture2D _icon;

	public IEnumerator reduceSpeed(){
		float startTimer = Time.time;
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -80f;

		while(startTimer+1.0f > Time.time){
			GameObject.Find("Dust Particles").GetComponent<ParticleEmitter> ().localVelocity = new Vector3 (0,10,0);
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed +60f;

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