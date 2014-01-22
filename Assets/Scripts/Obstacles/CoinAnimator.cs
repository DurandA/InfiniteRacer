using UnityEngine;
using System.Collections;


public class CoinAnimator : MonoBehaviour {

	public int y = 0;
	public bool upDown = false;

	// Update is called once per frame.
	void Update ()
	{
		transform.localRotation*=Quaternion.Euler(0f,Time.deltaTime*-120f,0f);

		if(upDown == false){
			transform.localPosition += Vector3.up * 0.1F;
		}
		else{
			transform.localPosition += Vector3.down * 0.1F;
		}
		if(y == 15){
			if(upDown == false){
				upDown = true;
				y=0;
			}	
			else{
				upDown = false;	
				y=0;
			}
		}

		y++;
	}
}