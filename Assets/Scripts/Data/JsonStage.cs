using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class JsonStage : MonoBehaviour {
	
	Dictionary<string,object> stageDic;
	public TextAsset stageTXT;
	public AbstractStage[] theStage;
	public bool save;
	public bool load;
	
	
	// Use this for initialization
	void Start () {
		stageDic = MiniJSON.Json.Deserialize(stageTXT.text) as Dictionary<string,object>;
		LoadStage();
	}	
	// Update is called once per frame
	void Update () {
		if(save){
			SaveData(theStage);
			save = false;
		}
		if(load){
			LoadData(theStage);
			load = false;
			StarsCount(theStage);
		}
		
	}

	/// <summary>
	/// Load Stage Data From Txt
	/// </summary>
	public void LoadStage(){

		foreach(AbstractStage stagechild in theStage){
			//Debug.Log (stagechild.myStageData.stageID);
			Dictionary<string,object> childinfo = stageDic[stagechild.myStageData.stageID] as Dictionary<string,object>;
			stagechild.myStageData.starNum= int.Parse(childinfo["stars"].ToString());
			stagechild.myStageData.stageName= childinfo["name"].ToString();
			stagechild.UpdateStageName();
			stagechild.UpdateStars(stagechild.myStageData.starNum);		
			}		
			StarsCount(theStage);
	}
	/// <summary>
	/// Sum num of stars
	/// </summary>
	public static void StarsCount(AbstractStage[] stages){
		int sum = 0;
		foreach(AbstractStage starchild in stages){
			if(starchild.myStageData.starNum >0 )
				sum += starchild.myStageData.starNum;				
		}
		GameObject go = GameObject.FindGameObjectWithTag("stars");
		go.GetComponent<UILabel>().text =sum.ToString ();
	}
	/// <summary>
	/// Saves the data.
	/// </summary>
	public static void SaveData(AbstractStage[] stages){
		int i = 0;
		Dictionary<string,object> stageJson = new Dictionary<string, object>();
		foreach(AbstractStage savestagechild in stages){
			stageJson["name"] = savestagechild.myStageData.stageName;
			stageJson["stars"] = savestagechild.myStageData.starNum;
			stageJson["id"] = savestagechild.myStageData.stageID;
			string saveJson = MiniJSON.Json.Serialize(stageJson);
			DataController.SaveJsonData("card"+i, saveJson);
			Debug.Log("save success");
			i++;
		}
	}

	/// <summary>
	/// Loads the data.
	/// </summary>
	public static void LoadData(AbstractStage[] stages){
		int i = 0;
		foreach (AbstractStage loadstagechild in stages) {
			string loadjson = DataController.LoadJsonData("card"+i);
			Dictionary<string,object> _stageJson = MiniJSON.Json.Deserialize(loadjson) as Dictionary<string,object>;
			loadstagechild.myStageData.stageID = _stageJson["id"].ToString();
			loadstagechild.myStageData.starNum= int.Parse(_stageJson["stars"].ToString());
			loadstagechild.myStageData.stageName = _stageJson["name"].ToString();
			loadstagechild.UpdateStageName();
			loadstagechild.UpdateStars(loadstagechild.myStageData.starNum);
			Debug.Log("load success");
			i++;		
			//load data and show it
		}
		
	}
	
}
