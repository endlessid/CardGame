using UnityEngine;
using System.Collections;

public class CardCube : MonoBehaviour {
	public int cubeID;
	public UILabel showID;


	// Use this for initialization
	void Start () {
		SetCubeData();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetCubeData(){
		cubeID = Random.Range (1,100);
		showID.text = cubeID.ToString();

	}

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     