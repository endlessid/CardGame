using UnityEngine;
using System.Collections;

[System.Serializable]
public class CardData{
	public int mpNum = 30;
	public int cardDMG = 10;
	public bool isSelect =false;
	public int hpNum;
}


public class AbstractCard : MonoBehaviour {

	public CardData myCardData;
	public int rollOut = 1;
	public float rollTime = 0.5f;

	public AbstractBar myBar;



	// Use this for initialization
	void Start () {
		myBar.BarUpdate(myBar.myBarData);

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void SelectCard(){
		CardRollOut(myCardData);

	}



	void CardRollOut(CardData myCard){

		if(myCard.isSelect == false && myBar.myBarData.mpbar >= myCardData.mpNum ){
			myBar.myBarData.mpbar -= myCardData.mpNum;
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",rollOut,"islocal",true,"time",rollTime,"easetype","spring"));
			myCard.isSelect = true;
		}
		else if(myCard.isSelect == true && myBar.myBarData.mpbar < 100)
		{
			myBar.myBarData.mpbar += myCardData.mpNum;
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",0,"islocal",true,"time",rollTime,"easetype",""));
			myCard.isSelect = false;
		}
		myBar.BarUpdate(myBar.myBarData);
		}
	}



