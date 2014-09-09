using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagController : MonoBehaviour {

	public UIItemStorage cardMatrix;
	public CardCube[] cubeArray;
	List<object> cubeList;
	public TextAsset cubeAsset;
	public UILabel pageCounter;
	int maxPageIndex;
	public bool pre;
	public bool next;


	// Use this for initialization
	void Start () {
		//read cubeinfo from txt
		Dictionary<string,object> cubeDic = MiniJSON.Json.Deserialize(cubeAsset.text) as Dictionary<string,object>;
		cubeList = cubeDic["cards"] as List<object>;
		//get cubes from itemstorage
		cubeArray = cardMatrix.GetComponentsInChildren<CardCube>();
//		Debug.Log(cubeArray.Length);
		ShowBagPage(1);
		Debug.Log(ShowBagPage(1));

	}
	
	// Update is called once per frame
	void Update () {
		if(pre){
			PreviousPage ();
			pre=false;
		}
		if(next){
			NextPage ();
			Debug.Log(maxPageIndex);
			next=false;
		}
		
	}


	//input index of cubelist & ouput the level of it 
	public int GetLevelFromTxt(int count){
		Dictionary<string,object> cubeInfo = cubeList[count] as Dictionary<string,object>;
		return int.Parse(cubeInfo["level"].ToString());
	}

	//show certain page of bag accroding to pageindex
	public int ShowBagPage(int pageIndex){
		//max slots in itemstorage 16
		int pageMaxSlot = cubeArray.Length;
		//maxslots of multiple pages 16*n
		int totalIndex = pageIndex * pageMaxSlot;
		//number of cube data 21
		int count = cubeList.Count;
		for(int i = totalIndex;i<totalIndex+pageMaxSlot;i++ ){
			//if not last page
			if(pageIndex < count/pageMaxSlot){
				cubeArray[i%pageMaxSlot].bLevel = GetLevelFromTxt(i);
				cubeArray[i%pageMaxSlot].UpdateCubeData();
				cubeArray[i%pageMaxSlot].ShowCube(true);

			}
			//last page or latter
			else if(pageIndex >= count/pageMaxSlot){
				//assign cube data
				if(i%pageMaxSlot <count%pageMaxSlot && i<count ){
					cubeArray[i%pageMaxSlot].bLevel = GetLevelFromTxt(i);
					cubeArray[i%pageMaxSlot].UpdateCubeData();
					cubeArray[i%pageMaxSlot].ShowCube(true);
				}
				//hide cube without data
				else if(i%pageMaxSlot >= count%pageMaxSlot ){
					cubeArray[i%pageMaxSlot].ShowCube(false);
				}

			}

		}
		pageCounter.text= (pageIndex+1) + "/" + (count/pageMaxSlot+1);
		return pageIndex;
	}

	public void PreviousPage(){

	}
	public void NextPage(){
		maxPageIndex = cubeList.Count/cubeArray.Length+1;

	}

}
