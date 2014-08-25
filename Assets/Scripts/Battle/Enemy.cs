using UnityEngine;
using System.Collections;

//[System.Serializable]
//public class EnemyData{
//	public int enemy_damage;
//}

public class Enemy : Actor {

//	public EnemyData myEnemyData;
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
		Debug.Log (attacker.damage);
		this.hp = EnemyHP;
		UnderAttack (attacker);
		EnemyHP = this.hp;
		if(EnemyHP <0){
			EnemyHP = 0;
		}
		myBar.BarUpdate ();
	}

}
