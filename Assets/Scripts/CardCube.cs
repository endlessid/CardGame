using UnityEngine;
using System.Collections;

[System.Serializable]
public class CubeData{
	public int cubeLevel;
	public bool isSold =false ;
}

public class CardCube : MonoBehaviour {

	public UILabel level;
	public CubeData myCubeData;
	public int bLevel{
		get{return myCubeData.cubeLevel;}
		set{myCubeData.cubeLevel = value;}
	}
	public bool isSold{
		get{return myCubeData.isSold;}
		set{myCubeData.isSold = value;}
	}


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UpdateCubeData(){
		level.text = bLevel.ToString();
	}

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     