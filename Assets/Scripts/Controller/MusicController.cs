using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicController : MonoBehaviour {

	public AudioSource mapBGM;
	public AudioSource battleBGM;
	public AudioSource hitEffect;
	public AudioSource bagBGM;


	public List<AudioClip> bgmList;

	// Use this for initialization


	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void HitSound(){
		hitEffect.Play ();
	}
	public void PlayBGM(GameObject obj){
		mapBGM.Stop();
		int count = int.Parse (obj.name) - 1;
		Debug.Log (count);
		battleBGM.clip = bgmList[count];
		battleBGM.Play();
	}
}
