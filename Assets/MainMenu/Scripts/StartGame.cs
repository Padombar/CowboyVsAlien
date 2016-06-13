using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	void OnMouseDown() {
		PlayerPrefs.SetInt ("playerHealth", 100);
		StartGameScene ();
	}

	public void StartGameScene() {		
		// Change value to game index
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");		
	}
}
