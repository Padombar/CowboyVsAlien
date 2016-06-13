using UnityEngine;
using System.Collections;

public class HideControlsOnStartup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject controls = GameObject.FindGameObjectWithTag ("Controls");
		controls.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
//		controls.SetActive (false);
	}
}
