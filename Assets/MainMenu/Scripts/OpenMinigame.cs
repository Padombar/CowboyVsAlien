using UnityEngine;
using System.Collections;

public class OpenMinigame : MonoBehaviour {

	void OnMouseDown() {
		StartGameScene ();
	}

	public void StartGameScene() {
		PlayerPrefs.SetInt ("playerHealth", 100);
		UnityEngine.SceneManagement.SceneManager.LoadScene (2);
	}
}