using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SQLtest : MonoBehaviour {


	string listUrl ="http://1.cardgamedemo1.sinaapp.com/shoplist.php";

	// Use this for initialization
	IEnumerator Start () {

		WWW wWw = new WWW(listUrl);
		yield return wWw;

//		Dictionary<string,object> testDic = MiniJSON.Json.Deserialize(wWw.text) as Dictionary<string,object>;

//		Debug.Log (testDic["id"].ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

