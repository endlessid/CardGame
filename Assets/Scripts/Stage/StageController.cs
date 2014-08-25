using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageController : MonoBehaviour {



	public AbstractStage[] stageArray;
	public delegate void GotoBattle();
	public GotoBattle changPanel;



	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

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
