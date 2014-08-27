using UnityEngine;
using System.Collections;

[System.Serializable]
public class CardData{
	public int mpNum = 30;
	public bool isSelect =false;
}


public class AbstractCard : Actor {


	public CardData myCardData;
	public int rollOut = 1;
	public float rollTime = 0.5f;
	public Transform[] wayPoints;
	public AbstractBar myBar;
	public iTween.EaseType easeType;
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

	public bool debug;

	// Use this for initialization
	void Start () {
		myBar.BarUpdate();

	
	}
	
	// Update is called once per frame
	void Update () {
		if(debug){
			GameObject go = GameObject.FindGameObjectWithTag("Enemy");
			CardSuicide (go.transform);
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
			iTween.MoveTo(gameObject,iTween.Hash("x",transform.localPosition.x,"y",0,"islocal",true,"time",rollTime,"easetype","spring"));
			IsSelect = false;
		}
		myBar.BarUpdate();
		}

	//check card isselectd & card attack enemy and return
	public void CardAttackMove(Transform target){
		if (IsSelect == true) {
						Hashtable arg = new Hashtable ();
						wayPoints [0] = transform;
						wayPoints [1] = target;
						wayPoints [2] = transform;
						arg.Add ("path", wayPoints);
						arg.Add ("time", 0.7f);
						arg.Add ("easetype", easeType);
						iTween.MoveFrom (gameObject, arg);
				}
		  				
		}

	public void CardSuicide(Transform target){
		if (IsSelect == true) {
			Hashtable arg = new Hashtable ();
			wayPoints [0] = transform;
			wayPoints [1] = target;
			arg.Add ("path", wayPoints);
			arg.Add ("time", 0.5f);
			arg.Add ("easetype", easeType);
			iTween.MoveFrom (gameObject, arg);
		}

	}

	}






