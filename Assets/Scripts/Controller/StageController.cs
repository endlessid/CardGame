using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageController : MonoBehaviour {



	public AbstractStage[] stageArray;
	public delegate void ChangeToBattle();
	public ChangeToBattle changPanel;



	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(0.1f);
		UnlockStage();



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
			StarsCount();
		}
	}

	/// <summary>
	/// Gets the stage identifier.
	/// </summary>
	public string GetStageId(){
		foreach (AbstractStage idChild in stageArray) {
			UIToggle to = idChild.GetComponent<UIToggle>();
			if(to.value){
				return idChild.myStageData.stageID;
			}
		}
		return null;
	}

	/// <summary>
	/// Sum num of stars
	/// </summary>
	public static void StarsCount(){
		int sum = 0;
		GameObject level = GameObject.FindGameObjectWithTag("level");
		AbstractStage[] stages = level.GetComponentsInChildren<AbstractStage>();
		foreach(AbstractStage starchild in stages){
			if(starchild.myStageData.starNum >0 )
				sum += starchild.myStageData.starNum;				
		}
		GameObject go = GameObject.FindGameObjectWithTag("stars");
		go.GetComponent<UILabel>().text =sum.ToString ();
	}

	public void AddStar(){
		foreach(AbstractStage starchild in stageArray){
			if(starchild.myStageData.stageID == GetStageId() && starchild.myStageData.starNum < 3){
					starchild.myStageData.starNum += 1;
				starchild.UpdateStars(starchild.myStageData.starNum);
			}
			StarsCount();
			}			
		}
}	
