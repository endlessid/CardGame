using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public GameObject cardPrefab;
	public UIGrid cardDeck;
	public AbstractBar abBar;

	public delegate void ChangeToStage();
	public ChangeToStage changePanel;

	public Enemy myEnemy;
	public Player myPlayer;
	public StageController sc;
//	public bool debug;
//	public bool debug1;




	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {



	}
	//add count cards into deck
	public void GenerateCard(int count){
		for(int i = 0;i < count ;i++){
			GameObject newCard = NGUITools.AddChild(cardDeck.gameObject,cardPrefab);
			newCard.transform.localPosition = new Vector3(3,3,-10);
			newCard.transform.RotateAround(newCard.transform.position,Vector3.up,180);
			newCard.GetComponent<AbstractCard>().myBar = abBar ;
		}
		if(count>0){
			cardDeck.Reposition();
		}
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
		AbstractCard[] cards = cardDeck.GetComponentsInChildren<AbstractCard>();
		for(int i = cards.Length-1;i>=0;i--){
			if(cards[i].IsSelect){
				cards[i].CardAttackMove(myEnemy.transform);
				yield return new WaitForSeconds(0.6f);
		
			}
		}
		cardDeck.Reposition ();
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
		for(int i = cards.Length -1 ;i>=0;i--){
			cards[i].IsSelect = false;
			}
		}


	}



