using UnityEngine;
using System.Collections;

public class BagController : MonoBehaviour {

	public UIItemStorage cardMatrix;
	public CardCube[] cubeArray;






	// Use this for initialization
	void Start () {
		cubeArray = cardMatrix.GetComponentsInChildren<CardCube>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpiltPage(int pageIndex){
		int pageMaxSlot = cubeArray.Length;
		

	}
}
