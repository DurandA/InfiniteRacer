using UnityEngine;
using System.Collections;

// Simply resumes the time when coming from the pause menu back
// to the main menu.
public class LaunchController : MonoBehaviour {
	void Start () {
		Time.timeScale = 1;
	}
}