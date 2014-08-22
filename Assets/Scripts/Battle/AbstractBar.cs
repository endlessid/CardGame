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

	public int  HPbar{
		get{return myBarData.hpbar;}
		set{myBarData.hpbar = value;}
	}
	public int  MPbar{
		get{return myBarData.mpbar;}
		set{myBarData.mpbar = value;}
	}
	public int BOSShp{
		get{return myBarData.bossbar;}
		set{myBarData.bossbar = value;}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void BarUpdate(BarData myBar){
		if(HPbar <101 && HPbar >0 ){
			hpSprite.width = (int)HPbar*267/100;		
		}
		if ( MPbar < 101 && MPbar > 0){
			mpSprite.width = (int)MPbar*267/100;
		}
		if ( BOSShp < 101 && BOSShp > 0){
			bosshpSprite.width = (int)BOSShp*274/100;
		}
	}

}
