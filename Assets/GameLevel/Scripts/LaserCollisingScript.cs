using System;
using UnityEngine;
using System.Collections;

public class LaserCollisingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject[] sounds = GameObject.FindGameObjectsWithTag("CowboyHitSound");

            int index = Util.Random.Next(0, 2);

            sounds[index].GetComponent<AudioSource>().Play();

            PlayerPrefs.SetInt("playerHealth",PlayerPrefs.GetInt("playerHealth",100)-10);
        }
        Destroy(gameObject);
    }
}
