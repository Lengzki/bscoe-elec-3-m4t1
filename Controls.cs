using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Controls: MonoBehaviour {

	Vector3 tPosition;
	float xThrow, yThrow;
    float sp = 10f;
    public float xMin = -10f;
    public float xMax = 10f;
    public float yMin = -8f;
    public float yMax = 8f;
    public float tilt = 7f;
    public float yRotation = 0.0F;
    public float xRotation = 0.0F;
    public ParticleSystem explode;

    void Start ()
    { explode.Stop();}

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
    
		// For Up and Down
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
                explode.Play();
                SceneManager.LoadScene(1);
				Debug.Log("Collided with: " + collision.gameObject.name);
			}
    }
}