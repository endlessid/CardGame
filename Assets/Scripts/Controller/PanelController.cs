using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {
	public UIPanel stagePanel;
	public UIPanel battlePanel;
	public BattleController battleCtrl;
	public StageController stageCtrl;
	public AbstractBar abBar;
	public ParticleSystem bubble;
	public AudioSource mapBGM;
	public AudioSource battleBGM;


	// Use this for initialization
	void Start () {
		stageCtrl = GetComponent<StageController>();
		stageCtrl.changPanel = changeToBattle;

		battleCtrl = GetComponent<BattleController>();
		battleCtrl.changePanel = changeToStage;
	
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
		abBar.HPbar = 100;
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
		mapBGM.Play();
		battleBGM.Stop();
	}


}
