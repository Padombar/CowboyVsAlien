using UnityEngine;
using System.Collections;

public class SetControlsOnStartup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString( "control_forward", "w");		
		PlayerPrefs.SetString( "control_backward", "s");
		PlayerPrefs.SetString( "control_left", "a");	
		PlayerPrefs.SetString( "control_right", "d");
		PlayerPrefs.SetString( "control_shoot", "mouse0");	
		PlayerPrefs.SetString( "control_use", "e");	
		PlayerPrefs.SetString( "control_menu", "escape");
	}
}
