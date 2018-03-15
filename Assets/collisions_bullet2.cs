using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions_bullet2 : MonoBehaviour {

	AudioSource bullet_Sound;
	
	private int enemy_cnt;
	private int score;

	// Use this for initialization
	void Start () {
		bullet_Sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
