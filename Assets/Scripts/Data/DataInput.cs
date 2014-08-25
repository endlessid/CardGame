using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataInput : MonoBehaviour {
	string json = "test";
	bool applyCard;
	bool show;

	public static Dictionary<string, object> stageData;
	public static Dictionary<string, object> cardData;
	// Use this for initialization

	IEnumerator Start () {

		DontDestroyOnLoad(this);

		yield return new WaitForSeconds(1);
		Application.LoadLevel("empty");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		show = GUI.Toggle(new Rect(10, 10, 24,24), show, "");
		GUI.Label(new Rect(4, 20, 40,20), "show");

		if(!show)return;
		json = GUI.TextField(new Rect(50, 10, 200, 100), json);

		applyCard = GUI.Toggle(new Rect(10, 50, 24,24), applyCard, "");
		if(applyCard){
			GUI.Label(new Rect(4, 64, 40,20), "card");
			
		}else{
			GUI.Label(new Rect(4, 64, 40,20), "stage");
			
		}

		if(GUI.Button(new Rect(10, 120, 80,30), "Apply") && json.Length > 0){
			//json to game data
			if(applyCard){
				Dictionary<string, object> _obj = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
				if(_obj != null){
					cardData = _obj;
					Debug.Log("Update CardData : " + json);
					//DebugShow(cardData);
				}
			}else{
				Dictionary<string, object> _obj = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
				if(_obj != null){
					stageData = _obj;
					Debug.Log("Update StageData : " + json);
					//DebugShow(stageData);
				}
			
			}
		}

		if(GUI.Button(new Rect(90, 120, 80,30), "Start")){
			Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(170, 120, 80,30), "Loader")){
			Application.LoadLevel(1);
		}


	}

	void DebugShow(Dictionary<string, object> dic){
		foreach(KeyValuePair<string, object> pairList in dic){

			Dictionary<string, object> dat = pairList.Value as Dictionary<string, object>;
			foreach(KeyValuePair<string, object> pair in dat){
				Debug.Log(pair.Key + " : " + pair.Value.ToString());
			}
		}
	}
}
