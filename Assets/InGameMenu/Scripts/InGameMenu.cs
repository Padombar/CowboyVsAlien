using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class InGameMenu : MonoBehaviour {

	private bool isPause = false;

	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;

	GameObject leftWindow;
	GameObject rightWindow;

	void Awake () {
		butRect = new Rect ((Screen.width - ctrlWidth) / 2, -Screen.height - (((4*ctrlHeight)+(4*20))/2), ctrlWidth, ctrlHeight);
	}
		
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (PlayerPrefs.GetString ("control_menu"))) {
			ToggleTimeScale();
		}
	}

	void ToggleTimeScale () {
		Debug.Log ("ToggleTimeScale");
        
        if (!isPause) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
		} else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
		}
		isPause = !isPause;
	}
		
	void OnGUI() {
		// Create the whole GUI	
		if (isPause) {
			butRect.y = (Screen.height - ctrlHeight) / 2;
			if (GUI.Button (butRect, "Continue")) {
				ToggleTimeScale ();
			}
			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Main Menu")) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
			}

			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Settings")) {
                GameObject masterObject = GameObject.Find("MasterObject");
                for (int i = 0; i < masterObject.transform.childCount; i++)
                {
                    masterObject.transform.GetChild(i).gameObject.SetActive(false);
                }
                DontDestroyOnLoad(masterObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene ("InGameSettings");
			}

			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Exit")) {
				ToggleTimeScale ();
				Application.Quit();
			}		
		}
	}
}
