using UnityEngine;
using System.Collections;

[System.Serializable]
public class BarData{
	public int hpbar = 100;
	public int mpbar = 100;
	public int bossbar = 100;
}

public class AbstractBar : MonoBehaviour {

	public BarData myBarData;
	public UISprite hpSprite;
	public UISprite mpSprite;
	public UISprite bosshpSprite;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void BarUpdate(BarData myBar){
		if(myBar.hpbar <101 && myBar.hpbar >0 ){
			hpSprite.width = (int)myBar.hpbar*267/100;		
		}
		if ( myBar.mpbar < 101 && myBar.mpbar > 0){
			mpSprite.width = (int)myBar.mpbar*267/100;
		}
		if ( myBar.bossbar < 101 && myBar.bossbar > 0){
			bosshpSprite.width = (int)myBar.bossbar*274/100;
		}
	}

}
