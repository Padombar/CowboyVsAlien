using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	CharacterController mycontroller;
	Animation myanimation;

	public GameObject projectile;

	public MonoBehaviour InGameMenu;

	public float moveSpeed = 100;
    
	bool shooting = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (PlayerPrefs.GetInt("controllDeactive", 0) == 0) {

			myanimation = (Animation)gameObject.GetComponent ("Animation");

			mycontroller = (CharacterController)gameObject.GetComponent ("CharacterController");

		    bool forward = Input.GetKey(PlayerPrefs.GetString("control_forward", "w"));
            bool backward = Input.GetKey(PlayerPrefs.GetString("control_backward", "s"));
            bool left = Input.GetKey(PlayerPrefs.GetString("control_left", "a"));
            bool right = Input.GetKey(PlayerPrefs.GetString("control_right", "d"));
            bool shootKey = Input.GetKey(PlayerPrefs.GetString("control_shoot", "Fire1"));

		    float x = left ? -1 : 0;
		    x = right ? 1 : 0;
		    x = left && right ? 0 : x;

            float z = backward ? -1 : 0;
            z = forward ? 1 : 0;
            z = forward && backward ? 0 : x;
            
			mycontroller.SimpleMove (transform.forward * z * moveSpeed * Time.deltaTime);
			mycontroller.SimpleMove (transform.right * x * moveSpeed * Time.deltaTime);
			if ((z > 0.2) || (z < -0.2)) {
				myanimation.CrossFade ("ActionWalking");
			} else {
				myanimation.CrossFade ("ActionStanding");
			}


			if (shootKey) {
				if (!shooting) {
					shooting = true;
					myanimation.CrossFade ("ActionShoot");
					StartCoroutine (shoot());
					shooting = false;
				}
			}


		}


	}


	IEnumerator shoot(){
		
		yield return new WaitForSeconds(0.13F);
		GameObject newProjectile = (GameObject)Instantiate (projectile, transform.position + transform.forward + transform.up, Quaternion.identity);//transform.rotation);
		newProjectile.SendMessage ("setDirection", transform.forward);//transform.TransformDirection( transform.forward));


	}

}
