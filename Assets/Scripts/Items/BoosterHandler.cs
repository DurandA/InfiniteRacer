using UnityEngine;
using System.Collections;

/*
 * Author: Arnaud Durand
 */
public class BoosterHandler : MonoBehaviour, Powerup {

	public Texture2D _icon;

	public IEnumerator booster(float duration){
		GameConfiguration.Instance.boosterOn = true;
		Renderer boosterField = GameObject.Find("/Player/Booster Field").renderer;
		boosterField.enabled = true;
		float startTimer = Time.time;
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed +480;
		GameObject.Find("Dust Particles").GetComponent<ParticleEmitter> ().localVelocity = new Vector3 (0,400,0);

		while(startTimer+duration-2.8f > Time.time){
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -120f;
		while(startTimer+duration-2.4f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -100f;
		while(startTimer+duration-2.0f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -40f;
		while(startTimer+duration-1.6f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -40f;
		while(startTimer+duration-1.3f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -20f;
		while(startTimer+duration-1.0f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -20f;
		while(startTimer+duration-0.7f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -20f;
		while(startTimer+duration-0.5f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -20f;
		while(startTimer+duration-0.3f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.2f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.1f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.8f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.6f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.4f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.3f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.2f > Time.time){
			boosterField.enabled = false;
			yield return null;
		}		
		GameConfiguration.Instance.startSpeed = GameConfiguration.Instance.startSpeed -10f;
		while(startTimer+duration-0.1f > Time.time){
			boosterField.enabled = true;
			yield return null;
		}
		GameObject.Find("Dust Particles").GetComponent<ParticleEmitter> ().localVelocity = new Vector3 (0,150,0);
		boosterField.enabled=false;
		GameConfiguration.Instance.boosterOn = false;



	}

	#region Powerup implementation
	public void Trigger ()
	{
		StartCoroutine(booster(7.0f));
	}

	public Texture2D icon {
		get {
			return _icon;
		}
	}
	#endregion
}