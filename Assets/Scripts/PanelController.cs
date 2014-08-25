using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {
	public UIPanel mapPanel;
	public UIPanel battlePanel;
	public BattleController battleCtrl;
	public StageController stageCtrl;


	// Use this for initialization
	void Start () {
		stageCtrl = GetComponent<StageController> ();


		battleCtrl = GetComponent < BattleController ();

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
