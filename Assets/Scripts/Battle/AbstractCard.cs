using UnityEngine;
using System.Collections;

[System.Serializable]
public class CardData{
	public int mpNum = 30;
	public bool isSelect =false;
	public bool isCardChara = true;
	public string cardDes;
	public string cardHeart;
	public string cardArmor;
}


public class AbstractCard : Actor {


	public CardData myCardData;
	public int rollOut = 1;
	public float rollTime = 0.5f;
	public Transform[] wayPoints;
	public AbstractBar myBar;
	public UILabel labelHeart;
	public UILabel labelArmor;
	public UILabel labelCardDes;

	public iTween.EaseType easeType;
	public bool isCardChara{
		get{return myCardData.isCardChara;}
		set{myCardData.isCardChara = value;}
	}
	public bool IsSelect{
		get{return myCardData.isSelect;}
		set{myCardData.isSelect = value;}
	}
	public int MP{
		get{return myCardData.mpNum;}
		set{myCardData.mpNum = value;}
	}
	public int DMG{
		get{return damage;}
		set{damage = value;}
	}
	public string cDescription{
		get{return myCardData.cardDes;}
		set{myCardData.cardDes = value;}
	}
	public string cHeart{
		get{return myCardData.cardHeart;}
		set{myCardData.cardHeart = value;}
	}
	public string cArmor{
		get{return myCardData.cardArmor;}
		set{myCardData.cardArmor = value;}
	}
	public bool debug;

	// Use this for initialization
	void Start () {

		myBar.BarUpdate();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(debug){
			GameObject go = GameObject.FindGameObjectWithTag("Enemy");
			CardAttackMove (go.transform);
			debug = false;
		}

	
	}
	/// <summary>
	/// update the labels on the card model
	/// </summary>
	public void UpdateCardLabel(){
		labelArmor.text = cArmor;
		labelCardDes.text = cDescription;
		labelHeart.text = cHeart;
	}

	//check if card can be select,change mp,roll out & roll back
	public  void CardRollOut(){

		if(IsSelect == false && myBar.MPbar >= MP ){
			myBar.MPbar -= MP;
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",rollOut,"islocal",true,"time",rollTime,"easetype","spring"));
			IsSelect = true;
		}
		else if(IsSelect == true && myBar.MPbar < 100)
		{
			myBar.MPbar += MP;
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",0,"islocal",true,"time",rollTime,"easetype","linear"));
			IsSelect = false;
		}
		myBar.BarUpdate();
		}

	/// <summary>
	/// check cardtype and attck in the way which depends on the type
	/// </summary>
	/// <param name="target">Target.</param>
	public void CardAttackMove(Transform target){
		if(isCardChara){
			if (IsSelect == true) {
						Hashtable arg = new Hashtable ();
						wayPoints [0] = transform;
						wayPoints [1] = target;
						wayPoints [2] = transform;
//						iTween.ScaleFrom(gameObject,);
						arg.Add ("path", wayPoints);
						arg.Add ("time", 0.6f);
						arg.Add ("easetype", easeType);
						iTween.MoveFrom (gameObject, arg);
				}
		}
		else{
			if (IsSelect == true) {
				Hashtable arg = new Hashtable ();
				wayPoints [0] = transform;
				wayPoints [1] = target;
				Hashtable scl = new Hashtable();

				arg.Add ("path", wayPoints);
				arg.Add ("time", 0.4f);
				arg.Add ("easetype", easeType);
				iTween.ScaleFrom(gameObject,scl);
				iTween.MoveFrom (gameObject, arg);
				Destroy(this);
				}
			}
		  				
		}

//	public void CardSuicide(Transform target){
//		if (IsSelect == true) {
//			Hashtable arg = new Hashtable ();
//			wayPoints [0] = transform;
//			wayPoints [1] = target;
//			arg.Add ("path", wayPoints);
//			arg.Add ("time", 0.5f);
//			arg.Add ("easetype", easeType);
//			iTween.MoveFrom (gameObject, arg);
//		}
//
//	}

	}






