using UnityEngine;
using System.Collections;

public class pipe90halfSBehaviour : PipeBehaviour {

	public virtual void Awake() {


			createTwoBlocks(0.1f);
			createTwoBlocks(0.1f);
			createTwoBlocks(0.3f);
			createTwoBlocks(0.3f);
		
		
		float start = 0.1f;
		float increment = 0.5f;
		
		if(GameConfiguration.Instance.speed > 170.0){
			start = 0.3f;
			increment = 0.6f;
		} 
		/*

		for (float i = start; i < 1.0f; i = i + increment)
		{
			int obstacleType = Random.Range(1,6);

			if(i>0.4)
			{
				switch (obstacleType)
				{
				case 1:
					SpawnCoins(i+0.3f,7,8.0f);
					break;
				case 2:
					SpawnCoins(i+0.3f,10,0.0f);
					break;
				case 3:
					SpawnCoins(i+0.3f,15,0.0f);
					break;
				default:
					break;
				}
			}


			//obstacle type
			switch (obstacleType)
			{
			case 1:
				createBlock(i);
				break;
			case 2:
				createTwoBlocks(i);
				break;
			case 3:
				createBlower(i);
				break;
			case 4:
				createCannon();
				break;
			case 5:
				createHexa(i);
				break;
			default:
				break;
			}
		}*/
	}

}
