using System;
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class ProfessorScript : MonoBehaviour
{

    private bool profInFrontOfPlayer = false;

    private GameObject player;

    private Vector3 posInFrontOfPlayer = Vector3.zero;

    private Timer timer = new Timer();
    private Text gameText;

    private bool speachStarted;

    private AudioSource handBattery;

    private string profspech1 = "\nDanke für deine Hilfe ich vermute mal das Pferd das entfürt wurde gehört dir.";
    private string profspech2 = "\nDie aliens haben es eingefrohren aber ich habe ihnen eine Energiezelle für den Entfroster gestohlen.";
    private string profspech3 = "\nHier du kannst sie haben.";
    private string profspech4 = "\nIch öffne dir noch die Tür in den nächsten Raum und verschwinde von hier. Viel Erfolg";
    private bool setSpech2;
    private bool setSpech3;
    private bool setSpech4;
    
    private bool fadeToBlack;
    private GuiFader fader;
    private bool fadeToClear;


    // Use this for initialization
    void Start () {
	    player = GameObject.FindGameObjectWithTag("Player");
        GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
        handBattery = GameObject.Find("Batterie_erhalten").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!fader)
	    {
	        GameObject o = GameObject.Find("ScreenFader");
	        if (o != null)
	        {
                fader = o.GetComponent<GuiFader>();
            }
        }

        if(!fader) return;

        //Start Pro Cut Scene
        if (GameObject.FindGameObjectsWithTag("ProfAlien").Length == 0)
	    {

	        PlayerPrefs.SetInt("controllDeactive",1);

	        if (posInFrontOfPlayer == Vector3.zero)
	        {
	            posInFrontOfPlayer = player.transform.TransformPoint(Vector3.forward * 2);
	        }

	        if (!profInFrontOfPlayer)
	        {
	            if (!fader.IsBlack())
	            {
                    fader.FadeToBlack();
	            }
	            else
	            {
	                transform.position = posInFrontOfPlayer;
                    Quaternion old = transform.rotation;
                    Vector3 playerPos = player.transform.position;
                    transform.LookAt(playerPos);
                    transform.rotation = new Quaternion(old.x, transform.rotation.y, old.z, old.w);
                }
	        }
        }

        if (transform.position == posInFrontOfPlayer)
        {
            profInFrontOfPlayer = true;
        }

        if (profInFrontOfPlayer && !fader.IsClear() && !speachStarted)
	    {
	        fader.FadeToClear();
	    }

	    


	    if (!speachStarted  && fader.IsClear() && profInFrontOfPlayer)
	    {
	        speachStarted = true;
	        gameText.text += profspech1;
	        timer.Interval = 5000;
            timer.Elapsed += delegate
            {
                if (setSpech2)
                {
                    setSpech2 = false;
                    setSpech3 = true;
                }
                else if (setSpech3)
                {
                    setSpech3 = false;
                    setSpech4 = true;
                }
                else if (setSpech4)
                {
                    setSpech4 = false;
                    timer.Stop();
                }
                else if (speachStarted)
                {
                    setSpech2 = true;
                }
            };
            timer.Start();

	    }
        

        if (setSpech2)
	    {
	        if (!gameText.text.Contains(profspech2))
	        {
                gameText.text = gameText.text.Replace(profspech1, "");
	            gameText.text += profspech2;

	        }
        }
        if (setSpech3) {
            if (!gameText.text.Contains(profspech3))
            {
                gameText.text = gameText.text.Replace(profspech2, "");
                gameText.text += profspech3;
                handBattery.Play();
            }
        }
        if (setSpech4) {
            if (!gameText.text.Contains(profspech4))
            {
                gameText.text = gameText.text.Replace(profspech3, "");
                gameText.text += profspech4;
            }
        }
	    if (!setSpech4)
	    {
	        if (gameText.text.Contains(profspech4))
	        {
	            fadeToBlack = true;
                gameText.text = gameText.text.Replace(profspech4, "");
            }
	    }

	    if (fadeToBlack)
	    {


            fader.FadeToBlack();
	        if (fader.IsBlack())
	        {
	            gameObject.GetComponent<Renderer>().enabled = false;
                
                PlayerPrefs.SetInt("profTürOffen", 1);
	            fadeToBlack = false;
	            fadeToClear = true;
	        }

        }

	    if (fadeToClear)
	    {

            fader.FadeToClear();
	        if (fader.IsClear())
	        {
                PlayerPrefs.SetInt("controllDeactive", 0);
                Destroy(gameObject);
	        }
	    }


	}


    

}
