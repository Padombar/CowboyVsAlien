using UnityEngine;
using System.Collections;

public class TestMoveScipts : MonoBehaviour
{

    public int speed = 5;

    void Start()
    {
        PlayerPrefs.SetInt("playerHealth", 100);
        PlayerPrefs.SetInt("gameWon", 0);
        PlayerPrefs.SetInt("controllDeactive", 0);
        PlayerPrefs.SetInt("profTürOffen", 0);
        PlayerPrefs.SetInt("jollyFree", 0);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update ()
	{
	    if (PlayerPrefs.GetInt("controllDeactive", 0) == 0)
	    {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * vertical * speed * -1);
            transform.Rotate(Vector3.up, horizontal * Time.deltaTime * speed * 10);

            if (Input.GetButtonDown("Fire1"))
            {
                foreach (GameObject o in GameObject.FindGameObjectsWithTag("ProfAlien"))
                {
                    Destroy(o);
                }
            }
        }

        PlayerPrefs.SetInt("playerHealth", 100);
    }
}
