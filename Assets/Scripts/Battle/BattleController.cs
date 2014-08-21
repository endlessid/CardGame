using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public GameObject cardPrefab;
	public UIGrid cardDeck;
	public AbstractBar abBar;

	public Transform map;

	public bool debug;




	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(debug){
			BackToMap();
			debug = false;
		}


	}
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

	public void BackToMap(){

		UIPlayAnimation[] animationList =map.GetComponents<UIPlayAnimation>();
		foreach(UIPlayAnimation child in animationList){
			child.Play(true,false);

		}
		Debug.Log("yeah");
	}

	public void DeleteCards(){

	}	
	}



