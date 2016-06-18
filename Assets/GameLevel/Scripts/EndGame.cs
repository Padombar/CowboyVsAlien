using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
    private bool isInEndgameRange;
    private Text gameText;
    private string _text;
    private string _text2;
    private Timer timer;
    private bool removeText2;

    // Use this for initialization
	void Start () {
        GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
        _text = "\nBenutze " + PlayerPrefs.GetString("control_use", "e").ToUpper() + " um Vom Raumschiff zu entkommen";
        _text2 = "\nDu Solltest auf dein Pferd warten!";
        timer = new Timer(3000);
        timer.Elapsed += delegate
        {
            removeText2 = true;
        };
}
	
	// Update is called once per frame
	void Update () {
	    if (isInEndgameRange && GameObject.Find("Jolly") != null &&
	        Input.GetKeyDown(PlayerPrefs.GetString("control_use", "e")))
	    {
            if(!gameText.text.Contains(_text2))
	        gameText.text += _text2;


            timer.Start();
	    }
	    else if (isInEndgameRange && GameObject.Find("Jolly") == null &&
            Input.GetKeyDown(PlayerPrefs.GetString("control_use", "e")))
        {
	        GameObject.Find("HealthSlider").GetComponent<Health>().GameWon();
	    }


	    if (removeText2)
	    {
            gameText.text = gameText.text.Replace(_text2, "");
	        removeText2 = false;
	    }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInEndgameRange = true;
            if (!gameText.text.Contains(_text))
                gameText.text += _text;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInEndgameRange = false;
            gameText.text = gameText.text.Replace(_text, "");
        }
    }
}
