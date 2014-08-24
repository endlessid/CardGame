using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	public int hp;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public virtual void Attack(Actor target){
		target.UnderAttack (this);	
	
	}
	public virtual void UnderAttack(Actor attcker){
		Debug.Log (attcker.name);
		hp -= attcker.damage;
	}
}
