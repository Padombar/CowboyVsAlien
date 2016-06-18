using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMiniGame : MonoBehaviour
{

    private bool isInMinigameRange;
    private Text gameText;

    private string text;

    // Use this for initialization
    void Start ()
	{
	    GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
        text = "\nBenutze " + PlayerPrefs.GetString("control_use", "e").ToUpper() +
                          " um das Minigame zu starten";
    }
	
	// Update is called once per frame
	void Update () {
	    if (PlayerPrefs.GetInt("gameWon") == 1)
	    {
            isInMinigameRange = false;
            gameText.text = gameText.text.Replace(text, "");

        }

	    if (isInMinigameRange && Input.GetKeyDown(PlayerPrefs.GetString("control_use", "e")))
	    {
	        GameObject masterObject = GameObject.Find("MasterObject");
	        for (int i = 0; i < masterObject.transform.childCount; i++)
	        {
	            GameObject o = masterObject.transform.GetChild(i).gameObject;
                if (!o.name.Equals("Sounds"))
	            masterObject.transform.GetChild(i).gameObject.SetActive(false);
	        }
	        DontDestroyOnLoad(masterObject);
            SceneManager.LoadScene("Minigame");
	        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Minigame"));
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && PlayerPrefs.GetInt("gameWon",0) == 0)
        {
            isInMinigameRange = true;
            if(!gameText.text.Contains(text))
            gameText.text += text;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player") && PlayerPrefs.GetInt("gameWon",0) == 0)
        {
            isInMinigameRange = false;
            gameText.text = gameText.text.Replace(text, "");
        }
    }
}
