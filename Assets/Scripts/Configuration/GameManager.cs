using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * Author : Arnaud Durand, adaptations by Thomas Rouvinez
 * Description : handle speed and score.
 */
public class GameManager : MonoBehaviour {
	public GUISkin powerupSkins;
	public float startTimer;
	public float timer;

	private PowerupStacker powerups = new PowerupStacker();

	/*
	 * Author : Arnaud Durand
	 * Description : handle powerup stacking and triggering.
	 */
	class PowerupStacker {
		public const int size = 3;

		private List<Powerup> items = new List<Powerup>();

		public Texture2D[] icons = new Texture2D[0];

		private void BufferIcons(){
			icons = items.Select(p => p.icon).ToArray();
		}

		public void Push(Powerup item)
		{
			if (items.Count < size){
				Debug.Log(item);
				items.Add(item);
				BufferIcons();
			}
		}

		public void Pop(int itemAtPosition)
		{
			items[itemAtPosition].Trigger();
			items.RemoveAt(itemAtPosition);
			BufferIcons();
		}
	}
		
	// ----------------------------------------------------------------------
	// Update score.
	// ----------------------------------------------------------------------

	// Use this for initialization
	void Awake () {
		ResetConfiguration();
	}

	void Start() {
		startTimer = timer = Time.time;
	}

	void Update () {
		// Update and detect each second.
		if(Time.time - timer >= 1f && GameConfiguration.Instance.ended == false)
		{
			timer = Time.time;
			GameConfiguration.Instance.score += 1;
			GameConfiguration.Instance.speed += Mathf.Sqrt(Time.deltaTime)*8;
		}
	}

	void OnGUI(){
		if (!GameConfiguration.Instance.ended) {
			GUI.skin = powerupSkins;

			for (int i=0; i<powerups.icons.Length; i++)
			{
				if (GUI.Button (new Rect (Screen.width - (Screen.width / 10) - i * (Screen.width / 10), Screen.height - (Screen.width / 10), (Screen.width / 12), (Screen.width / 12)), powerups.icons [i])
				    || Input.GetKey (KeyCode.Space) && GameConfiguration.Instance.isOnPowerUp == false)
				{
					powerups.Pop (i);
				}
			}				
		}
	}

	public void addPowerup(Powerup powerup){
		powerups.Push(powerup);
	}

	public void ResetConfiguration () {
		GameConfiguration.Instance.speed = 90;
		GameConfiguration.Instance.coins = 0;
		GameConfiguration.Instance.score = 0;
		GameConfiguration.Instance.paused = false;
		GameConfiguration.Instance.ended = false;
	}
}