using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    SceneManager.LoadScene("HUD",LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
