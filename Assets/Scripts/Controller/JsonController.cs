using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class JsonController : MonoBehaviour {
	
	Dictionary<string,object> stageDic;
	public TextAsset stageTXT;
	public AbstractStage[] theStage;
	public StageController sc;
	public bool save;
	public bool load;
	public bool loadjson;
	
	
	// Use this for initialization
	void Start () {


		stageDic = MiniJSON.Json.Deserialize(stageTXT.text) as Dictionary<string,object>;

		if (PlayerPrefs.HasKey ("Stage01") && DataInput.stageData == null) {
						LoadData (theStage);
				} 
		else {
				LoadDataInput(DataInput.stageData);
				SaveData (theStage);
				}
		StageController.StarsCount();
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

		}
		if(loadjson){
			LoadStage();
			loadjson = false;

		}
	}

	/// <summary>
	/// Load Stage Data From Txt accroding to stageID
	/// </summary>
	public void LoadStage(){

		foreach(AbstractStage stagechild in theStage){
//			Debug.Log (stagechild.myStageData.stageID);
			Dictionary<string,object> childinfo = stageDic[stagechild.myStageData.stageID] as Dictionary<string,object>;
			stagechild.myStageData.starNum= int.Parse(childinfo["stars"].ToString());
			stagechild.myStageData.stageName= childinfo["name"].ToString();
			stagechild.UpdateStageName();
			stagechild.UpdateStars(stagechild.myStageData.starNum);		
			}		
			StageController.StarsCount();
	}
	/// <summary>
	/// when disabled save the status
	/// </summary>
	void OnDisable(){
		SaveData (theStage);
		}
	/// <summary>
	/// Saves the data.
	/// </summary>
	public static void SaveData(AbstractStage[] stages){
		int i = 1;
		Dictionary<string,object> stageJson = new Dictionary<string, object>();
		foreach(AbstractStage savestagechild in stages){
			stageJson["name"] = savestagechild.myStageData.stageName;
			stageJson["stars"] = savestagechild.myStageData.starNum;
			stageJson["id"] = savestagechild.myStageData.stageID;
			string saveJson = MiniJSON.Json.Serialize(stageJson);
			DataController.SaveJsonData("Stage0"+i, saveJson);
			Debug.Log("save success");
			i++;
		}
	}
	/// <summary>
	/// Loads data of the Datainput.
	/// </summary>
	void LoadDataInput(Dictionary<string,object> stageInfo){

		foreach(AbstractStage stageChild in theStage){
			Dictionary<string,object> childInfo = stageInfo[stageChild.myStageData.stageID] as Dictionary<string,object>;
			stageChild.myStageData.starNum = int.Parse(childInfo["stars"].ToString());
			stageChild.myStageData.stageName = childInfo["name"].ToString();
			stageChild.UpdateStageName();
			stageChild.UpdateStars(stageChild.myStageData.starNum);
		}
		StageController.StarsCount();
	}

	/// <summary>
	/// Loads the data.
	/// </summary>
	public static void LoadData(AbstractStage[] stages){
		int i = 1;
		foreach (AbstractStage loadstagechild in stages) {
			string loadjson = DataController.LoadJsonData("Stage0"+i);
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
		StageController.StarsCount();
		
	}
	
}
