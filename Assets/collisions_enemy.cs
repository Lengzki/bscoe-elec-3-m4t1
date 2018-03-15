﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class collisions_enemy : MonoBehaviour {		
	
	public ParticleSystem explosion;
    public Renderer enemy;      
    public Text score_label;
    public Text enemy_health;
    
    AudioSource enemy_explode;
    
    private int score;
    private int health;

    // Use this for initialization
    void Start () {
        explosion.Stop();
        enemy_explode = GetComponent<AudioSource>();
        enemy = GetComponent<Renderer>();
        enemy.enabled = true;

        score_label.text = "Score: " + Controls.Global.score.ToString();
        enemy_health.text = "";
        health = 20;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "bullet")
        {
			Debug.Log("Collided with: " + gameObject.name + "; Health =" + health);

            health -= 1;
            enemy_health.text = gameObject.name + " 's Health : " + health;

            if(health < 1){
                enemy_health.text = "";
			    enemy.enabled = false;
			    explosion.Play();
               
                if (!enemy_explode.isPlaying) {
                    enemy_explode.Play();
                    control.Global.score += 100;
                    score_label.text = "Score: " + Controls.Global.score.ToString();   
                }
            }

        }
	}

}