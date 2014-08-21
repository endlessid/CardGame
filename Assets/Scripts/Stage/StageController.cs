using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageController : MonoBehaviour {


//	public StageData mySatageData;
	public AbstractStage[] stageArray;
//	public bool show;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
//		if (show) {
//			ShowStage(mySatageData);
//			show=false;
//		}
	}

	public void UnlockStage(){
		for(int i=0; i < stageArray.Length - 1;i++){
			if(stageArray[i].myStageData.starNum == 3 &&  stageArray[i+1].myStageData.starNum < 0){
				stageArray[i+1].myStageData.starNum =0;
				stageArray[i+1].UpdateStars(stageArray[i+1].myStageData.starNum);
			}
			JsonStage.StarsCount(stageArray);
		}
	}

	/// <summary>
	/// Gets the stage identifier.
	/// </summary>
	public string GetStageId(){
		foreach (AbstractStage idChild in stageArray) {
			UIToggle to = idChild.GetComponent<UIToggle>();
			if(to.value == true){
				return idChild.myStageData.stageID;
			}
		}
		return null;
	}

	public void AddStar(){
		foreach(AbstractStage starchild in stageArray){
			if(starchild.myStageData.stageID == GetStageId() && starchild.myStageData.starNum < 3){
					starchild.myStageData.starNum += 1;
				starchild.UpdateStars(starchild.myStageData.starNum);
			}
			JsonStage.StarsCount(stageArray);
			}			
		}
}


	
//	public void ShowStage(StageData[] mydata){
//		int count = 0;
//		for(int i = 0; i < 6; i++){
//			stageArray[i].SetStageinfo(mydata[i]);
//			if(mySatageData[i].starNum > 0){
//				count += mySatageData[i].starNum;
//			}
//		}
//		GameObject go = GameObject.FindGameObjectWithTag("stars");
//		go.GetComponent<UILabel>().text = count.ToString();
//	}
//}
