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
		Dropdown forward = GameObject.Find("Forward").GetComponent<Dropdown>();
		Dropdown backward = GameObject.Find("Backward").GetComponent<Dropdown>();
		Dropdown left = GameObject.Find("Left").GetComponent<Dropdown>();
		Dropdown right = GameObject.Find("Right").GetComponent<Dropdown>();
		Dropdown shoot = GameObject.Find("Shoot").GetComponent<Dropdown>();
		Dropdown use = GameObject.Find ("Use").GetComponent<Dropdown> ();
		Dropdown menu = GameObject.Find("MenuDD").GetComponent<Dropdown>();


		int forwardKey = forward.value;
		int backwardKey = backward.value;
		int leftKey = left.value;
		int rightKey = right.value;
		int shootKey = shoot.value;
		int useKey = use.value;
		int menuKey = menu.value;



//		if (forwardKey == 0) {
//			PlayerPrefs.SetString( "control_forward", "W");		
//		} else if (forwardKey == 1) {
//			PlayerPrefs.SetString( "control_forward", "MouseUp");
//		}

//		PlayerPrefs.SetInt( "control_forward", forwardKey);
//		PlayerPrefs.SetInt("control_backward", backwardKey);
//		PlayerPrefs.SetInt("control_left", leftKey);
//		PlayerPrefs.SetInt("control_right", rightKey);
//		PlayerPrefs.SetInt("control_shoot", shootKey);
//		PlayerPrefs.SetInt("control_menu", menuKey);

	}
}
