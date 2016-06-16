using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMiniGame : MonoBehaviour
{

    private bool isInMinigameRange;
    private Text gameText;
    private bool doorClosed = true;

	// Use this for initialization
	void Start ()
	{
	    GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (PlayerPrefs.GetInt("gameWon") == 1)
	    {
            isInMinigameRange = false;
            gameText.text = "";
        }

	    if (isInMinigameRange && Input.GetKey(KeyCode.E))
	    {
	        GameObject masterObject = GameObject.Find("MasterObject");
	        for (int i = 0; i < masterObject.transform.childCount; i++)
	        {
	            masterObject.transform.GetChild(i).gameObject.SetActive(false);
	        }
	        DontDestroyOnLoad(masterObject);
            SceneManager.LoadScene("Minigame");
	        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Minigame"));

        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && PlayerPrefs.GetInt("gameWon",0) == 0)
        {
            isInMinigameRange = true;
            gameText.text = "Benutze E um das Minigame zu starten";
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player") && PlayerPrefs.GetInt("gameWon",0) == 0)
        {
            isInMinigameRange = false;
            gameText.text = "";
        }
    }
}
