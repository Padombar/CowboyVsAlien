using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameReload : MonoBehaviour
{
    private GameObject MasterObject;
    
	// Update is called once per frame
	void Update () {
	    if (PlayerPrefs.GetInt("reload", 0) == 1)
	    {
            GameObject masterObject = GameObject.Find("MasterObject");
            for (int i = 0; i < masterObject.transform.childCount; i++)
            {
                masterObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            PlayerPrefs.SetInt("reload",0);
            GameObject.Find("Hintergrundmusik").GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("HUD",LoadSceneMode.Additive);
        }
	}
}
