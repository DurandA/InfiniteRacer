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
	
	public float speed;
	public int coins;
	public long score;

}
