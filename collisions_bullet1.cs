using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions_bullet1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
			if(collision.gameObject.tag == "enemies"){ 
				print("shooot1");
				Debug.Log("Collided with: " + collision.gameObject.name);
			}
			
	}
}
