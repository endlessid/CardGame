using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public GameObject cardPrefab;
	public UIGrid cardDeck;
	public AbstractBar abBar;

	public delegate void ChangeToStage();
	public ChangeToStage changePanel;

	public Enemy myEnemy;
	public Player myPlayer;
	public StageController sc;
	public TextAsset cardAsset;
	List<object> cardsList;
//	public bool debug;
//	public bool debug1;
	// Use this for initialization

	void Start () {
		//load card info from txt and make them a list<>
		Dictionary<string,object>  cardDic  = MiniJSON.Json.Deserialize(cardAsset.text) as Dictionary<string,object>;
		cardsList = cardDic["cards"]as List<object>;

	}
	
	// Update is called once per frame
	void Update () {



	}


	//add count cards into deck
	public void GenerateCard(int count){
		for(int i = 0;i < count ;i++){
			GameObject newCard = NGUITools.AddChild(cardDeck.gameObject,cardPrefab);
			Dictionary<string,object> cardInfo = cardsList[i] as Dictionary<string,object>;
			newCard.GetComponent<AbstractCard>().cHeart= int.Parse(cardInfo["heart"].ToString());
			newCard.GetComponent<AbstractCard>().cDescription=cardInfo["description"].ToString();
			newCard.GetComponent<AbstractCard>().cArmor=int.Parse(cardInfo["armor"].ToString());
			newCard.GetComponent<AbstractCard>().isCardChara= bool.Parse(cardInfo["iscardchar"].ToString());
			newCard.transform.localPosition = new Vector3(3,3,-10);
			newCard.transform.RotateAround(newCard.transform.position,Vector3.up,180);
			newCard.GetComponent<AbstractCard>().myBar = abBar ;
			newCard.GetComponent<AbstractCard>().UpdateCardLabel();
		}
		if(count>0){
			cardsList.RemoveRange(0,count);

		}
		cardDeck.Reposition();
	}



	public void DestoryAllCards(){ 
		GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
		for(int i = cards.Length-1;i>=0;i--){
			Destroy(cards[i]);
		}

	}

	public void attackEnemy(){
		StartCoroutine("CreatureCardAttack");
	}

	IEnumerator CreatureCardAttack(){
		//selected cards excute attack move
		AbstractCard[] cards = cardDeck.GetComponentsInChildren<AbstractCard>();
		for(int i = cards.Length-1;i>=0;i--){
			if(cards[i].IsSelect){
				//wait untill attack finish
				cards[i].StartCoroutine("CardAttackMove",myEnemy.transform);
				yield return new WaitForSeconds(0.6f);						
			}
		}
		//fill vacancies with cards &check vacancies and cardlist which one is bigger in case of index out range
		AbstractCard[] remaincards = cardDeck.GetComponentsInChildren<AbstractCard>();
		if(cardsList.Count < 5-remaincards.Length){
		GenerateCard(cardsList.Count);
		}
		else{
			GenerateCard(5-remaincards.Length);
		}
		//deal damage to enemy if its reach 0 change panel &update bars
		if(myEnemy.EnemyHP >0){		
			abBar.HPbar -=myEnemy.EnemyDMG;
			yield return new WaitForSeconds(1f);
		}
		else if(myEnemy.EnemyHP <=0){
			myEnemy.EnemyHP = 100;
			changePanel();
			sc.AddStar();
			sc.UnlockStage();
			StageController.StarsCount();
		}
		abBar.MPbar = 100;
		abBar.BarUpdate();
		//make cards back to unselected
		AbstractCard[] allcards = cardDeck.GetComponentsInChildren<AbstractCard>();
		for(int i = allcards.Length -1 ;i>=0;i--){
			cards[i].IsSelect = false;
			}
		}

	}



