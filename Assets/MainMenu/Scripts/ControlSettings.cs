using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlSettings : MonoBehaviour {
	GameObject controls;

	void Start () {		
		controls = GameObject.FindGameObjectWithTag("Controls");
		controls.SetActive (false);
	}

	// Set Popup visible
	void OnMouseDown() {
		controls.SetActive (true);

	}

	public void CloseControls() {
		controls.SetActive (false);
	}

	public void SaveSettingsButton() {
		Dropdown forward = GameObject.FindGameObjectWithTag("Forward").GetComponent<Dropdown>();
		Dropdown backward = GameObject.FindGameObjectWithTag("Backward").GetComponent<Dropdown>();
		Dropdown left = GameObject.FindGameObjectWithTag("Left").GetComponent<Dropdown>();
		Dropdown right = GameObject.FindGameObjectWithTag("Right").GetComponent<Dropdown>();
		Dropdown shoot = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Dropdown>();
		Dropdown use = GameObject.FindGameObjectWithTag ("Use").GetComponent<Dropdown> ();
		Dropdown menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Dropdown>();


		int forwardKey = forward.value;
		int backwardKey = backward.value;
		int leftKey = left.value;
		int rightKey = right.value;
		int shootKey = shoot.value;
		int useKey = use.value;
		int menuKey = menu.value;


		if (forwardKey == 0) {
			PlayerPrefs.SetString( "control_forward", "w");		
		} else if (forwardKey == 1) {
			PlayerPrefs.SetString( "control_forward", "up");
		}

		if (backwardKey == 0) {
			PlayerPrefs.SetString( "control_backward", "s");		
		} else if (backwardKey == 1) {
			PlayerPrefs.SetString( "control_backward", "down");
		}	

		if (leftKey == 0) {
			PlayerPrefs.SetString( "control_left", "a");		
		} else if (leftKey == 1) {
			PlayerPrefs.SetString( "control_left", "left");
		}	

		if (rightKey == 0) {
			PlayerPrefs.SetString( "control_right", "d");		
		} else if (rightKey == 1) {
			PlayerPrefs.SetString( "control_right", "right");
		}	

		if (shootKey == 0) {
			PlayerPrefs.SetString( "control_shoot", "Fire1");		
		} else if (shootKey == 1) {
			PlayerPrefs.SetString( "control_shoot", "space");
		}

		if (useKey == 0) {
			PlayerPrefs.SetString( "control_use", "e");		
		} else if (useKey == 1) {
			PlayerPrefs.SetString( "control_use", "f");
		}

		if (menuKey == 0) {
			PlayerPrefs.SetString( "control_menu", "escape");		
		} else if (menuKey == 1) {
			PlayerPrefs.SetString( "control_menu", "p");
		}
	}
}
