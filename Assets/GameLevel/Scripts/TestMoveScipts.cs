using UnityEngine;
using System.Collections;

public class TestMoveScipts : MonoBehaviour
{

    public int speed = 5;

	// Use this for initialization
	void Start () {
	    PlayerPrefs.SetInt("playerHealth", 100);
	    PlayerPrefs.SetInt("gameWon",0);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float horizontal = Input.GetAxis("Horizontal");
	    float vertical = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * Time.deltaTime * vertical * speed);
        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * speed*10);
	}
}
