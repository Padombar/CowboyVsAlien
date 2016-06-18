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

			float z = Input.GetAxis ("Vertical");
			float x = Input.GetAxis ("Horizontal");
			mycontroller.SimpleMove (transform.forward * z * moveSpeed * Time.deltaTime);
			mycontroller.SimpleMove (transform.right * x * moveSpeed * Time.deltaTime);
			if ((z > 0.2) || (z < -0.2)) {
				myanimation.CrossFade ("ActionWalking");
			} else {
				myanimation.CrossFade ("ActionStanding");
			}


			if (Input.GetMouseButtonDown (0)) {
				if (!shooting) {
					shooting = true;
					myanimation.CrossFade ("ActionShoot");
					StartCoroutine (shoot ());
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
