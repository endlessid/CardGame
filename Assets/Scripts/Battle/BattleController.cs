using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public GameObject cardPrefab;
	public UIGrid cardDeck;
	public AbstractBar abBar;
	public Enemy myEnemy;

	public Transform map;

	public bool debug;




	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(debug){
			GenerateCard(5);
			debug = false;
		}


	}
	//add count cards into deck
	public void GenerateCard(int count){
		for(int i = 0;i < count ;i++){
			GameObject newCard = NGUITools.AddChild(cardDeck.gameObject,cardPrefab);
			newCard.transform.localPosition = new Vector3(3,10,-10);
			newCard.transform.RotateAround(newCard.transform.position,Vector3.up,180);
			newCard.GetComponent<AbstractCard>().myBar = abBar ;
		}
		if(count>0){
			cardDeck.Reposition();
		}
	}

	//back to map 
	public void BackToMap(){

		UIPlayAnimation[] animationList =map.GetComponents<UIPlayAnimation>();
		foreach(UIPlayAnimation child in animationList){
			child.Play(true,false);
		}
	}

	//
	void OnTriggerEnter(Collider other){
		Actor act = other.GetComponent<Actor> ();
		myEnemy.EnemyUnderAttack (act);
		Debug.Log("yeah");


	} 

//	public IEnumerator SpellCardAttack(){
//		bool attackReady = false;
//		AbstractCard[] cards = gameObject.GetComponentsInChildren<AbstractCard>();
//		for(int i = cards.Length )
//	}
	}



