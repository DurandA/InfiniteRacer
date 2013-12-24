using UnityEngine;
using System.Collections;


[RequireComponent(typeof (Spline))]
public class NavigationBehaviour : MonoBehaviour {
	
	// --------------------------------------------------------------------------------------
	// Variables.
	// --------------------------------------------------------------------------------------

	public float torque=0f;

	// --------------------------------------------------------------------------------------
	// Getter/Setter.
	// --------------------------------------------------------------------------------------

	public Spline spline
	{
		get {return GetComponent<Spline>();}
	}

	public virtual void Awake() {}

}