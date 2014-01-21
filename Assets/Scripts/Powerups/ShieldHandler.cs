using UnityEngine;
using System.Collections;

/*
 * Author: Arnaud Durand
 */
public class ShieldHandler : MonoBehaviour, Powerup {

	public Texture2D _icon;

	public IEnumerator enableShield(float duration){
		Renderer shieldField = GameObject.Find("/Player/Shield Field").renderer;
		shieldField.enabled = true;
		float startTimer = Time.time;
		Color fieldColor=shieldField.material.color;

		while(startTimer+duration > Time.time){
			fieldColor.a=Mathf.Sin(Time.time*5f)/2f+0.5f;
			shieldField.material.color=fieldColor;

			yield return null;
		}
	
		shieldField.enabled = false;
		Destroy(gameObject);
	}

	#region Powerup implementation
	public void Trigger ()
	{
		StartCoroutine(enableShield(7.5f));
	}

	public Texture2D icon {
		get {
			return _icon;
		}
	}
	#endregion
}
