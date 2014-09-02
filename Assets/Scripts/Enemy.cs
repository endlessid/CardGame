using UnityEngine;
using System.Collections;

//[System.Serializable]
//public class EnemyData{
//	public int enemy_damage;
//}

public class Enemy : Actor {

	public int EnemyDMG=20;
	public AbstractBar myBar;
	public int EnemyHP{
		get{return myBar.BOSShp;}
		set{myBar.BOSShp = value;}
	}
	public int DMG{
		get{return damage;}
		set{damage = value;}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void EnemyUnderAttack(Actor attacker){
		DMG = attacker.damage;
		this.hp = EnemyHP;
		UnderAttack (attacker);
		EnemyHP = this.hp;
		if(EnemyHP <0){
			EnemyHP = 0;
		}
		myBar.BarUpdate ();
	}

	void OnTriggerEnter(Collider other){
		Actor act = other.GetComponent<Actor> ();
		EnemyUnderAttack (act);
		Hashtable camshake = new Hashtable();
		camshake.Add ("y",0.2f);
		camshake.Add("time",0.2f);
		UICamera camera = gameObject.transform.parent.parent.GetComponentInChildren<UICamera>();
		iTween.ShakePosition(camera.gameObject,camshake);
	} 

}
