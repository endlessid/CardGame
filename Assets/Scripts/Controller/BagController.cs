using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagController : MonoBehaviour {

	public UIItemStorage cardMatrix;
	public CardCube[] cubeArray;
	List<object> cubeList;
	public int pageMaxSlot = 16;
	public TextAsset cubeAsset;

	// Use this for initialization
	void Start () {
		//read cubeinfo from txt
		Dictionary<string,object> cubeDic = MiniJSON.Json.Deserialize(cubeAsset.text) as Dictionary<string,object>;
		cubeList = cubeDic["cards"] as List<object>;
		Debug.Log(cubeList.Count%pageMaxSlot);
		//get cubes from itemstorage
		cubeArray = cardMatrix.GetComponentsInChildren<CardCube>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
//
//	public void AssignCubeData(){
//		for(int i = 0; i<cubeList.Count ;i++){
//		Dictionary<string,object> cubeInfo = cubeList[i] as Dictionary<string,object>; 
//		
//		}
//	}
//
//	public void SpiltPage(int pageIndex){
//		int totalIndex = pageIndex * pageMaxSlot;
//		for(int i = totalIndex;i<totalIndex+pageMaxSlot;i++  ){
//			if(pageIndex < cubeList.Count/pageMaxSlot){
//				cubeArray[i%pageMaxSlot]
//			}
//		}
//		
//
//	}
	public void PreviousPage(){

	}
	public void NextPage(){
		
	}

}
