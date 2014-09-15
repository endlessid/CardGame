using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagController : MonoBehaviour {

	public UIItemStorage cardMatrix;
	public CardCube[] cubeArray;
	List<object> cubeList;
	public TextAsset cubeAsset;
	public UILabel pageCounter;
	int max_pageIndex;
	public bool pre;
	public bool next;
	public int pageIndex;

	public UISprite priviousPage;
	public UISprite nextPage;




	// Use this for initialization
	void Start () {
		//read cubeinfo from txt
		Dictionary<string,object> cubeDic = MiniJSON.Json.Deserialize(cubeAsset.text) as Dictionary<string,object>;
		cubeList = cubeDic["cards"] as List<object>;
		Debug.Log("cubeList:"+cubeList.Count);
		//get cubes from itemstorage
		cubeArray = cardMatrix.GetComponentsInChildren<CardCube>();
//		Debug.Log(cubeArray.Length);
		ShowBagPage(0);
		priviousPage.alpha=0;
		Debug.Log("cubeSlots:"+cubeArray.Length);

	}
	
	// Update is called once per frame
	void Update () {
	
		
	}


	//input index of cubelist & ouput the level of it 
	public int GetLevelFromTxt(int count){
		Dictionary<string,object> cubeInfo = cubeList[count] as Dictionary<string,object>;
		return int.Parse(cubeInfo["level"].ToString());
	}

	//show certain page of bag accroding to _pageIndex
	public int ShowBagPage(int _pageIndex){
		pageIndex = _pageIndex;
		//max slots in itemstorage 16
		int pageMaxSlot = cubeArray.Length;
		//maxslots of multiple pages 16*n
		int totalIndex = _pageIndex * pageMaxSlot;
		//number of cube data 21
		int count = cubeList.Count;
		for(int i = totalIndex;i<totalIndex+pageMaxSlot;i++ ){
			//if not last page
			if(_pageIndex < count/pageMaxSlot){
				cubeArray[i%pageMaxSlot].bLevel = GetLevelFromTxt(i);
				cubeArray[i%pageMaxSlot].UpdateCubeData();
				cubeArray[i%pageMaxSlot].ShowCube(true);

			}
			//last page or latter
			else if(_pageIndex >= count/pageMaxSlot){
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
		pageCounter.text= (_pageIndex+1) + "/" + (count/pageMaxSlot+1);
		return pageIndex;
	}
	//check if paging button enable
	public void PageButtonControl(){
		max_pageIndex = cubeList.Count/cubeArray.Length;
		if(pageIndex == max_pageIndex){
			priviousPage.enabled = false;
			nextPage.enabled = false;
		}
		else if(pageIndex<=0 && max_pageIndex >0)
		{	
			priviousPage.enabled = false;
			nextPage.enabled = true;
		}
		else if(pageIndex >= max_pageIndex && pageIndex !=0){
			priviousPage.enabled = true;
			nextPage.enabled = false;
		}
		else if(pageIndex>0 && pageIndex <max_pageIndex){
			priviousPage.enabled = true;
			nextPage.enabled = true;
		}
	}

	public void PreviousPage(){
		ShowBagPage(pageIndex--);
		PageButtonControl();
	}
	public void NextPage(){
		ShowBagPage(pageIndex++);
		PageButtonControl();
		}
}
