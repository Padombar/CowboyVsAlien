using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	void OnMouseDown() {
        //Set Game parameter for new Game
        PlayerPrefs.SetInt("playerHealth", 100);
        PlayerPrefs.SetInt("gameWon", 0);
        PlayerPrefs.SetInt("controllDeactive", 0);
        PlayerPrefs.SetInt("profTürOffen", 0);
        PlayerPrefs.SetInt("jollyFree", 0);

        StartGameScene ();
	}

	public void StartGameScene() {		
		// Change value to game index
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");		
	}
}
