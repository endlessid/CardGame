using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataController : MonoBehaviour {

//	Dictionary<string,object> mapDic;
//	List<string> cardJson;

	// Use this for initialization
	void Start () {

		//save
//		string mapJson;
//		DataController.SaveJsonData("map", mapJson);
//
//		string cardJson = MiniJSON.Json.Serialize(cardJson);
//		DataController.SaveJsonData("card", cardJson);

		//load
//		string json = LoadJsonData("card");
//		Dictionary<string,object> _cardJson = MiniJSON.Json.Deserialize(json) as Dictionary<string,object>;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SaveJsonData(string key, string json){
		PlayerPrefs.SetString(key,json);
	}
	public static string LoadJsonData(string key){
		if(!PlayerPrefs.HasKey(key)){
			return "no this key";
		}
		return PlayerPrefs.GetString(key);
	}
}
