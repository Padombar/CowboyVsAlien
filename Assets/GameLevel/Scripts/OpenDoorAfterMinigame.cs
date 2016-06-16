using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Timers;
using UnityEngine.UI;

public class OpenDoorAfterMinigame : MonoBehaviour
{

    private bool doorClosed = true;
    private Vector3 open;
    private Text gameText;
    Timer timer = new Timer();
    private bool clearText;

    // Use this for initialization
    void Start () {
	    open = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);

        GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
        timer.Interval = 5000;
        timer.Elapsed += delegate
        {
            timer.Stop();
            clearText = true;
        };
    }
	
	// Update is called once per frame
	void Update () {
	    if (doorClosed && PlayerPrefs.GetInt("gameWon", 0) == 1)
	    {
	        if (transform.position.Equals(open))
	        {
	            doorClosed = false;
	        }
	        else
	        {
	            transform.position = Vector3.MoveTowards(transform.position, open, Time.deltaTime);
	        }
	    }
	    if (clearText)
	    {
	        if (gameText.text == "Diese Tür scheine auf magische weise mit dem Minispiel verbunden zu sein")
	        {
                gameText.text = "";
            }
	        clearText = false;
	    }
	}

    void OnCollisionEnter(Collision collision)
    {
        gameText.text = "Diese Tür scheine auf magische weise mit dem Minispiel verbunden zu sein";

        timer.Stop();
        timer.Start();
    }
}
