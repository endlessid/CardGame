using UnityEngine;
using System.Collections;



[System.Serializable]
public class StageData{	
	public int starNum;
	public string stageID;
	public string stageName;
	}

public class AbstractStage : MonoBehaviour {
	
	public StageData myStageData;
	public UILabel nameSprite;
	public UISprite lockSprite;
	public UISprite star1;
	public UISprite star2;
	public UISprite star3;

//	public void SetStageinfo(StageData aData){
//		myStageData.stageName = aData.stageName;
//		myStageData.stageID = aData.stageID;
//		myStageData.starNum = aData.starNum;
//		UpdateStageName();
//		UpdateStars(myStageData.starNum);
//	}

	public void UpdateStageName(){
		nameSprite.text = myStageData.stageName;
	}


	public void UpdateStars(int stars){
		BoxCollider box = lockSprite.GetComponentInParent<BoxCollider>();
		switch (stars){
		case -1:
			box.enabled = false;
			lockSprite.alpha = 1;
			star1.alpha = 0;
			star2.alpha = 0;
			star3.alpha = 0;
			break;
		case 0:
			box.enabled = true;
			lockSprite.alpha = 0;
			star1.alpha = 0;
			star2.alpha = 0;
			star3.alpha = 0;
			break;
		case 1:
			box.enabled = true;
			lockSprite.alpha = 0;
			star1.alpha = 1;
			star2.alpha = 0;
			star3.alpha = 0;
			break;
		case 2:
			box.enabled = true;
			lockSprite.alpha = 0;
			star1.alpha = 1;
			star2.alpha = 1;
			star3.alpha = 0;
			break;
		case 3:
			box.enabled = true;
			lockSprite.alpha = 0;
			star1.alpha = 1;
			star2.alpha = 1;
			star3.alpha = 1;
			break;
		}
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
