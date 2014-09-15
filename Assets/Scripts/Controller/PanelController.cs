using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {
	public UIPanel stagePanel;
	public UIPanel battlePanel;
	public BattleController battleCtrl;
	public StageController stageCtrl;
	public AbstractBar abBar;
	public ParticleSystem bubble;
	public UIPanel bagPanel;
	public BagController bagCtrl;
	public MusicController musicCtrl;


	// Use this for initialization
	void Start () {
		stageCtrl = GetComponent<StageController>();
		stageCtrl.changPanel = changeToBattle;

		battleCtrl = GetComponent<BattleController>();
		battleCtrl.changePanel = changeToStage;

		bagCtrl = GetComponent<BagController> ();
		bagCtrl.changePanel = changeToBag;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void changeToBattle(){
		TweenPosition stageTween = stagePanel.GetComponent<TweenPosition>();
		stageTween.PlayForward ();
		TweenPosition battleTween = battlePanel.GetComponent<TweenPosition>();
		battleTween.PlayForward ();

		battleCtrl.GenerateCard(5);
		//make hp back to full
		abBar.HPbar = 100;
		//play particel
		bubble.Play();


	}
	public void changeToStage(){
		TweenPosition stageTween = stagePanel.GetComponent<TweenPosition>();
		stageTween.PlayReverse();
		TweenPosition battleTween = battlePanel.GetComponent<TweenPosition>();
		battleTween.PlayReverse ();
		battleCtrl.DestoryAllCards ();
		abBar.HPbar =100;
		bubble.Stop ();
		musicCtrl.mapBGM.Play ();
		musicCtrl.battleBGM.Stop ();

	}

	public void changeToBag(){
		TweenPosition bagTween = bagPanel.GetComponent<TweenPosition> ();
		bagTween.PlayForward();
		musicCtrl.mapBGM.Stop ();
		musicCtrl.bagBGM.Play ();
		//not sure if battle can switch to bag yet
		if (musicCtrl.battleBGM != null) {
			musicCtrl.battleBGM.Stop();	
		}
		abBar.HPbar = 100;

		
	}
}
