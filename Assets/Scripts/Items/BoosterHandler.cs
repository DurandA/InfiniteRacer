using UnityEngine;
using System.Collections;

/*
 * Author: Arnaud Durand
 */
public class BoosterHandler : MonoBehaviour, Powerup {

	public Texture2D _icon;

	#region Powerup implementation
	public void Trigger ()
	{
		;;;
	}

	public Texture2D icon {
		get {
			return _icon;
		}
	}
	#endregion
}
