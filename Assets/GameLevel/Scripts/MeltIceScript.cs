using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class MeltIceScript : MonoBehaviour
{

    private string _text;
    private bool isInMeltRange;

    private Text gameText;

    private AudioSource batery;
    private AudioSource freezeMachine;
    private bool isMelding;
    private bool onlyOncePlay;

    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameText");
        gameText = obj.GetComponent<Text>();
        _text = "Benutze " + PlayerPrefs.GetString("control_use", "e").ToUpper() + " um Jolly aus dem Eis zu befreien";
        batery = GameObject.Find("Batterie_einsetzen").GetComponent<AudioSource>();
        freezeMachine = GameObject.Find("freeze_machine").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
	    if (isInMeltRange && Input.GetKeyDown(PlayerPrefs.GetString("control_use", "e")))
	    {
            batery.Play();
	        PlayerPrefs.SetInt("jollyFree", 1);
	    }

        if (PlayerPrefs.GetInt("jollyFree", 0) == 1 && !batery.isPlaying && !onlyOncePlay)
        {
            freezeMachine.Play();
            isMelding = true;
            onlyOncePlay = true;
        }

        if (isMelding)
        {
            GameObject.Find("IceCube").transform.Translate(Vector3.down*Time.deltaTime/3);
            if (!freezeMachine.isPlaying)
            {
                Destroy(GameObject.Find("IceCube"));
                isMelding = false;
                GameObject.Find("Jolly").GetComponent<JollyLeaveThrouPortalScript>().Move();
            }
        }
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && PlayerPrefs.GetInt("jollyFree", 0) == 0)
        {
            isInMeltRange = true;
            if (!gameText.text.Contains(_text))
                gameText.text += _text;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInMeltRange = false;
            gameText.text = gameText.text.Replace(_text, "");
        }
    }
}
