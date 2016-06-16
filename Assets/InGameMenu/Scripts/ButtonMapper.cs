using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonMapper : MonoBehaviour {

	void Update() {
		
	}

	public void Continue() {
        PlayerPrefs.SetInt("reload", 1);
        SceneManager.LoadScene("GameReloadScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameReloadScene"));
    }
}