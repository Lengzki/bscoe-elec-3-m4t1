using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions_bullet2 : MonoBehaviour {

	public ParticleSystem explosion;
	public ParticleSystem explosion2;
	public ParticleSystem explosion3;

	// Use this for initialization
	void Start () {
		explosion.Stop();
		explosion2.Stop();
		explosion3.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
		
        if (other.gameObject.tag == "enemies")
        {
			Debug.Log("Collided with: " + other.gameObject.name);
			Destroy(other);
			if(other.gameObject.name == "enemy2"){
				explosion2.Play();
			}else if(other.gameObject.name == "enemy3"){
				explosion3.Play();
			}else{
				explosion.Play();
			}
        }
	}

}
