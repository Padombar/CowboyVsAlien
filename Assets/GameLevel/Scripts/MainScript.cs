using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{

    public AudioSource startSound;
    public AudioSource backGroundMusic;
    private bool stop;

    // Use this for initialization
	void Start () {
	    if (PlayerPrefs.GetInt("reload", 0) != 1)
	    {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
            startSound.Play();
            Timer timer = new Timer();
            timer.Interval = 2500;
            timer.Elapsed += delegate
            {
                timer.Stop();
                stop = true;
            };
            timer.Start();
        }


	}
	
	// Update is called once per frame
	void Update () {
	    if (stop)
	    {
	        startSound.Stop();
            backGroundMusic.Play();
	        stop = false;
	    }
	}
}
