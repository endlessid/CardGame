using UnityEngine;
using System.Collections;

public class RandomDropItem : MonoBehaviour {

	public string[] itemsID;
	public string[] dropRate;

	// Use this for initialization
	void Start () {
		string testID="A,B,C,D";
		itemsID = testID.Split(',');
		foreach (string child in itemsID){		
//			Debug.Log(child);
		}
		string testRate = "10,4,1,3";
		dropRate = testRate.Split(',');
		foreach(string child in dropRate){
			int totalWeight =  int.Parse(child) ; 

		}
		 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
