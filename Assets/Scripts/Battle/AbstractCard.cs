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
	public Transform[] path;


	public AbstractBar myBar;
	public bool IsSelect{
		get{return myCardData.isSelect;}
		set{myCardData.isSelect = value;}
	}
	public int MP{
		get{return myCardData.mpNum;}
		set{myCardData.mpNum = value;}
	}
	public int DMG{
		get{return myCardData.cardDMG;}
		set{myCardData.cardDMG = value;}
	}

	public bool debug;

	// Use this for initialization
	void Start () {
		myBar.BarUpdate(myBar.myBarData);

	
	}
	
	// Update is called once per frame
	void Update () {
		if(debug){
			CardMoveOut ();
			debug = false;
		}

	
	}



	//check if card can be select,change mp,roll out & roll back
	public void CardRollOut(){
		if(IsSelect == false && myBar.MPbar >= MP ){
			myBar.MPbar -= MP;
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",rollOut,"islocal",true,"time",rollTime,"easetype","spring"));
			IsSelect = true;
		}
		else if(IsSelect == true && myBar.MPbar < 100)
		{
			myBar.MPbar += MP;
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",0,"islocal",true,"time",rollTime,"easetype",""));
			IsSelect = false;
		}
		myBar.BarUpdate(myBar.myBarData);
		}

	//card attack enemy and return
	public void CardMoveOut(){
//		AbstractCard[] cards = gameObject.GetComponentsInChildren<AbstractCard>();
		Hashtable cardAttack = new Hashtable();
//		path[0] =; 
//		path[1] = ;
//		path[2] =;
		cardAttack.Add ("x",3.6f);
		cardAttack.Add ("y",7);
		cardAttack.Add ("time",0.5f);
		cardAttack.Add ("islocal",true);
		cardAttack.Add ("easetype","spring");
//		iTween.MoveFrom(gameObject,cardAttack);
		  				
	}

	}






