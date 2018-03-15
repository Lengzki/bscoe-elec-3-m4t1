using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controls: MonoBehaviour {

	Vector3 tPosition;
	float xThrow, yThrow;
    float sp = 20f;
    float delayTime = 2f;
    AudioSource Explode_Sound;

    [SerializeField] Renderer spaceship;
    [SerializeField] float xMin = -10f;
    [SerializeField] float xMax = 10f;
    [SerializeField] float yMin = -16f;
    [SerializeField] float yMax = 16f;
    [SerializeField] float tilt = 7f;
    [SerializeField] float yRotation = 0.0F;
    [SerializeField] float xRotation = 0.0F;
    [SerializeField] ParticleSystem explode;
    [SerializeField] Text score_label;

    void Start (){ 
        explode.Stop();
        spaceship = GetComponent<Renderer>();
        spaceship.enabled = true;
    }

    void Update(){
        tPosition = transform.localPosition;

        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        tPosition.x += xThrow * sp * Time.deltaTime;
        tPosition.y += yThrow * sp * Time.deltaTime;
        tPosition = new Vector3(Mathf.Clamp(tPosition.x, xMin, xMax), Mathf.Clamp(tPosition.y, yMin, yMax), transform.localPosition.z);

        yRotation = Mathf.Clamp(yRotation, -50.0f, 50.0f);
        xRotation = Mathf.Clamp(xRotation, -38.0f, 50.0f);

		// For Rotation
        // up and down
		if (yThrow == 0 && (transform.localEulerAngles.x >= 1 || transform.localEulerAngles.x <= -1)){   
			if (yRotation >= -50.0f && yRotation <= 0.0f){
				yRotation += 1f;
			}else if (yRotation <= 50.0f){
				yRotation -= 1f;
			}
		}else if (yThrow == 0){
			yRotation = 0f;
		}

		yRotation += -yThrow * tilt * Time.deltaTime * 10;
		yRotation = Mathf.Clamp(yRotation, -50.0f, 50.0f);
    
		// left and right
        if (xThrow == 0 && ( transform.localEulerAngles.z >= 1 || transform.localEulerAngles.z <= -1)){
            if (xRotation >= -50.0f && xRotation <= 0.0f){
                xRotation += 1f;
			}else if (xRotation <= 50.0f){
                xRotation -= 1f;
			}
        }else if (xThrow==0){
            xRotation = 0f;
        }

		xRotation += -xThrow * tilt * Time.deltaTime * 10;
        xRotation = Mathf.Clamp(xRotation, -38.0f, 50.0f);


        transform.localEulerAngles = new Vector3( 
            Mathf.Clamp(yRotation, -50.0f, 50.0f), 
            0, 
            Mathf.Clamp(xRotation, -50.0f, 50.0f)
            );

       transform.localPosition = tPosition;

    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "obstacle"){ 
            Debug.Log("Collided with: " + collision.gameObject.name);    
            Explode_Sound = GetComponent<AudioSource>();
			Explode_Sound.Play();
            explode.Play();
            spaceship.enabled = false;
            Invoke("DelayedAction", delayTime);
        }
    }

    void DelayedAction()
    {
        Global.score = 0;
        score_label.text = " Score : 0";
        SceneManager.LoadScene(1);
    }

    public class Global
    {
        public static int score = 0;
    }
        
}