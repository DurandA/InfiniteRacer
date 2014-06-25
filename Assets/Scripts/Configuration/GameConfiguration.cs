﻿/*
 * Author: Arnaud Durand
 * Do NOT modify this script without author acknowledgement
 */
public class GameConfiguration {
	
	static GameConfiguration instance=null;
	static readonly object padlock = new object();

	GameConfiguration(){}
	
	public static GameConfiguration Instance
	{
		get
		{
			if (instance==null)
			{
				lock (padlock)
				{
					if (instance==null)
					{
						instance = new GameConfiguration();
					}
				}
			}
			return instance;
		}
	}

	// Game init.
	public float speed;
	public float startSpeed = 90;

	public bool isShieldEnabled = false;
	public bool isOnPowerUp = false;
	public bool paused = false;
	public bool ended = false;

	public int coins = 0;
	public long score = 0;
	public long highestPersonalScore = 0;
	
	// Settings.
	public bool menuMusicOn = true;
	public bool gameMusicOn = true;
	public short shipSelected = 0;
}