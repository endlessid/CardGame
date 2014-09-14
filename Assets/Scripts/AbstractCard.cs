using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CardData{

	public int mpNum = 30;
	public bool isSelect =false;
	public bool isCardChara ;
	public string cardDes;
	public int cardHeart;
	public int cardArmor;
	public int cardLevel;
	public string spriteName ;

}


public class AbstractCard : Actor {



	public CardData myCardData;
	public int rollOut = 1;
	public float rollTime = 0.5f;
	public Transform[] wayPoints;
	public Transform[] swayPoints;
	public AbstractBar myBar;
	public UILabel labelHeart;
	public UILabel labelArmor;
	public UILabel labelCardDes;
	public UILabel lableLevel;
	public Renderer cardFront;
	 

	public iTween.EaseType easeType;
	public string cName{
		get{return myCardData.spriteName;}
		set{myCardData.spriteName = value;}
	}
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
	public int cHeart{
		get{return myCardData.cardHeart;}
		set{myCardData.cardHeart = value;}
	}
	public int cLevel{
		get{return myCardData.cardLevel;}
		set{myCardData.cardLevel = value;}
	}
	public int cArmor{
		get{return myCardData.cardArmor;}
		set{myCardData.cardArmor = value;}
	}


	// Use this for initialization
	void Start () {	
		myBar.BarUpdate();	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	/// <summary>
	/// update the labels on the card model
	/// </summary>
	public void UpdateCardLabel(){

		Object[] texturesList = Resources.LoadAll<Texture2D>("monster");
		for(int i=0;i<texturesList.Length;i++){
			if(texturesList[i].name == cName.ToString())
			{
				cardFront.renderer.material.mainTexture =  (Texture2D)texturesList[i];				
			}
		}
		labelArmor.text = cArmor.ToString();
		labelCardDes.text = cDescription;
		labelHeart.text = cHeart.ToString();
		lableLevel.text = cLevel.ToString();	
 
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
	public IEnumerator CardAttackMove(Transform target){
		if(isCardChara){
			if (IsSelect == true) {
						Hashtable arg = new Hashtable ();
						wayPoints [0] = transform;
						wayPoints [1] = target;
						wayPoints [2] = transform;
						arg.Add ("path", wayPoints);
						arg.Add ("time", 0.6f);
						arg.Add ("easetype", easeType);
						iTween.MoveFrom (gameObject, arg);
				}
		}
		else{
			if (IsSelect == true) {						
				iTween.MoveTo(gameObject,iTween.Hash("position",target.transform,"time",0.3f,"easetype",easeType));			
				yield return new WaitForSeconds(0.4f);
				Destroy(gameObject);			
				}
			}
		  				
		}


	}






