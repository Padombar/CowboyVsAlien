using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonMapper : MonoBehaviour {

	void Update() {
		
	}

	public void Continue() {
		// From Settings back to menu
		int previousLevel = PlayerPrefs.GetInt( "previousLevel" );
		PlayerPrefs.SetInt( "previousLevel", 0);
		Time.timeScale = 1;
		SceneManager.LoadScene (previousLevel);
	}
}