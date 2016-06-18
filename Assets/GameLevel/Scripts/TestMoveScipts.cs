using UnityEngine;
using System.Collections;

public class TestMoveScipts : MonoBehaviour
{

    public int speed = 5;

	// Use this for initialization
	void Start () {
	    PlayerPrefs.SetInt("playerHealth", 100);
	    PlayerPrefs.SetInt("gameWon",0);
        PlayerPrefs.SetInt("controllDeactive", 0);
        PlayerPrefs.SetInt("profTürOffen", 0);
        PlayerPrefs.SetInt("jollyFree", 0);
	    Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
    }
}
