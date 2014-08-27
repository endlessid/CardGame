using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JsonCrotroller : MonoBehaviour
{
		public TextAsset Stage_JsonTxt;
		public Stage[] theStage;
		public bool show;
		public Stage parameter_stage;
		public Stage nparameter_stage;
		public UISprite blackwindow;
		public bool debug;
		public float time;
		public float i = 0.1f;
		public static JsonCrotroller jsonController;

		void Start ()
		{  
				string data = Stage_JsonTxt.text;
				if (PlayerPrefs.HasKey ("Stage01") && DataInput.stageData == null) {
						LoadData ();
				} else {
						getInfo (DataInput.stageData);
						SaveData ();
						//stageDic = MiniJSON.Json.Deserialize (Stage_JsonTxt.text) as Dictionary<string,object>;
						//getInfo ();
				}
		}

		void Update ()
		{
//				if (show) {
//						SaveData ();
//						//LoadData();
//						show = false;
//				}
				//切换场景时界面变暗
				if (debug) {
						time += Time.deltaTime;
						if (time > 0.075) {
								ChangeWindow ();
								time = 0;
						}
				}
		}
		/// <summary>
		/// 读取最开始的json文件
		/// </summary>
		public void	getInfo (Dictionary<string,object> stageDic)
		{
				int count = 0;
				foreach (Stage stageChild in theStage) {
						Dictionary<string,object> childInfo = stageDic [stageChild.mystageID] as Dictionary<string,object>;
						stageChild.mystagedata.StageStars = int.Parse (childInfo ["StageStars"].ToString ());
						stageChild.mystagedata.StageName = childInfo ["StageName"].ToString ();
						stageChild.mystagedata.EnemyName = childInfo ["EnemyName"].ToString ();
						stageChild.mystagedata.EnemyHp = int.Parse (childInfo ["EnemyHp"].ToString ());
						stageChild.mystagedata.EnemyAtt = int.Parse (childInfo ["EnemyAtt"].ToString ());
						if (stageChild.mystagedata.StageStars > 0) {
								count += stageChild.mystagedata.StageStars;
						}
				}
				GameObject sumstars = GameObject.FindGameObjectWithTag ("Sum");
				Debug.Log (count);
				sumstars.GetComponent<UILabel> ().text = count + "/18";
		}
		/// <summary>
		/// 保存存档
		/// </summary>
		public	void  SaveData ()
		{
				int i = 1;
				int count = 0;
				Dictionary<string,object> aData = new Dictionary<string, object> ();
				foreach (Stage savestage in theStage) {
						aData ["name"] = savestage.mystagedata.StageName;
						aData ["stars"] = savestage.mystagedata.StageStars;
						aData ["id"] = savestage.mystageID;
						//---------------------------------------------------------
						aData ["enemyname"] = savestage.mystagedata.EnemyName;
						aData ["enemyhp"] = savestage.mystagedata.EnemyHp;
						aData ["enemyatt"] = savestage.mystagedata.EnemyAtt;
						//----------------------------------------------------------
						string cardJson = MiniJSON.Json.Serialize (aData);
						DataController.SaveJsonData ("Stage0" + i, cardJson);  
						i++;
						if (savestage.mystagedata.StageStars > 0) {
								count += savestage.mystagedata.StageStars;
						}
				}
				GameObject sumstars = GameObject.FindGameObjectWithTag ("Sum");
				sumstars.GetComponent<UILabel> ().text = count + "/18";
				//-----------------------切换回地图音乐-------------------------------------------
				MusicController.musiccontro.PlayMusic (0);
		}
		/// <summary>
		/// 读取存档
		/// </summary>
		void  LoadData ()
		{
				int j = 1;
				int count = 0;
				foreach (Stage loadstage in theStage) {
						string json = DataController.LoadJsonData ("Stage0" + j);
						Dictionary<string,object> _cardJson = MiniJSON.Json.Deserialize (json) as Dictionary<string,object>;
						loadstage.mystagedata.StageName = _cardJson ["name"].ToString ();
						loadstage.mystagedata.StageStars = int.Parse (_cardJson ["stars"].ToString ());
						loadstage.mystagedata.StageID = _cardJson ["id"].ToString ();
						//----------------------------------------------------------------------------
						loadstage.mystagedata.EnemyName = _cardJson ["enemyname"].ToString ();
						loadstage.mystagedata.EnemyHp = int.Parse (_cardJson ["enemyhp"].ToString ());
						loadstage.mystagedata.EnemyAtt = int.Parse (_cardJson ["enemyatt"].ToString ());
						//-----------------------------------------------------------------------------
						j++;
						if (loadstage.mystagedata.StageStars > 0) {
								count += loadstage.mystagedata.StageStars;
						}
				}
				GameObject sumstars = GameObject.FindGameObjectWithTag ("Sum");
				sumstars.GetComponent<UILabel> ().text = count + "/18";
		}

		public	void BattleData (Stage astage, Stage bstage)
		{
				SwitchMusic (astage);
				parameter_stage = astage;
				nparameter_stage = bstage;
				parameter_stage.UpdateBattlePosition ();
				StartCoroutine (Cor_ChangeWindow ());
				astage.SetEnemyData ();
		}

		public void    ThelastStageData (Stage cstage)
		{
				SwitchMusic (cstage);
				parameter_stage = cstage;
		}
		//音乐切换
		public void  SwitchMusic (Stage stage_music)
		{
				if (stage_music != null) {
						int index = int.Parse (stage_music.mystageID [6].ToString ());
						MusicController.musiccontro.PlayMusic (index);
				}
		}

		public	void VictoryData ()
		{
				if (parameter_stage.mystagedata.StageStars <= 2) {
						Debug.Log ("seccsdas");
						parameter_stage.mystagedata.StageStars += 1;
						parameter_stage.UpdateStageStars ();
						if (parameter_stage.mystagedata.StageStars == 3 && parameter_stage.mystageID != "Stage06") {
								nparameter_stage.mystagedata.StageStars = 0;
								nparameter_stage.UpdateStageStars ();
						}

				}
	
		    
		}

		/// <summary>
		/// 改变界面透明度以此来使界面有切换时变暗的效果
		/// </summary>
		public void ChangeWindow ()
		{
				i += i;
				if (i >= 1) {
						//blackwindow.color=new Color(0.037f,0.037f,0.037f,0);
						debug = false;
				}
				blackwindow.color = new Color (0.037f, 0.037f, 0.037f, 0.1f + i);
		}

		IEnumerator Cor_ChangeWindow ()
		{
				debug = true;
				yield return new WaitForSeconds (1f);
				blackwindow.color = new Color (0.037f, 0.037f, 0.037f, 0.75f);
				yield return new WaitForSeconds (0.25f);
				blackwindow.color = new Color (0.037f, 0.037f, 0.037f, 0.5f);
				yield return new WaitForSeconds (0.25f);
				blackwindow.color = new Color (0.037f, 0.037f, 0.037f, 0.25f);
				yield return new WaitForSeconds (0.25f);
				blackwindow.color = new Color (0.037f, 0.037f, 0.037f, 0);
		}
}
