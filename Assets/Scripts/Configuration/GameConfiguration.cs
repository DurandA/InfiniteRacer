/*
 * Author: Arnaud Durand
 * Do NOT modify this script without author acknowledgement
 */
public class GameConfiguration {
	
	static GameConfiguration instance=null;
	static readonly object padlock = new object();

	GameConfiguration()
	{
	}
	
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

	public float startSpeed = 90;
	public bool isShieldEnabled = false;
	public bool isOnPowerUp = false;
	/*public bool boosterOn = false;*/
	public float speed;
	public int coins;
	public long score;
	public bool paused;
	public bool ended;
}