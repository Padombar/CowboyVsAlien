using System;
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
    private Timer timer = new Timer();
    private Timer timerHelp = new Timer();
    private bool clearText;
    private bool sendHelp;
    private bool clearTextHelp;


    private string doorText = "\nDiese Tür scheine auf magische weise mit dem Minispiel verbunden zu sein";
    private string helpText = "\nHilf mir diese Aliens haben mich entführt";


    // Use this for initialization
    void Start()
    {
        open = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);

        GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
        timer.Interval = 5000;
        timer.Elapsed += delegate
        {
            timer.Stop();
            clearText = true;
        };
        timerHelp.Interval = 5000;
        timerHelp.Elapsed += delegate
        {
            timerHelp.Stop();
            clearTextHelp = true;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (doorClosed && PlayerPrefs.GetInt("gameWon", 0) == 1)
        {
            if (Math.Abs(transform.position.y - open.y) < 0.01)
            {
                doorClosed = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, open, Time.deltaTime);
            }
        }

        if (PlayerPrefs.GetInt("gameWon", 0) == 1 && !sendHelp)
        {
            sendHelp = true;
            gameText.text += helpText;
            timerHelp.Start();
        }

        if (clearTextHelp)
        {
            gameText.text = gameText.text.Replace(helpText, "");
            clearTextHelp = false;
        }

        if (clearText)
        {
            gameText.text = gameText.text.Replace(doorText, "");
            clearText = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (!gameText.text.Contains(doorText))
            {
                if (!gameText.text.Contains(doorText))
                    gameText.text += doorText;
            }

            timer.Stop();
            timer.Start();
        }
    }
}