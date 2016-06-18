using UnityEngine;
using System.Collections;

public class ProfTürScript : MonoBehaviour
{
    private Vector3 openPos;

    // Use this for initialization
	void Start () {

        openPos = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	    if (PlayerPrefs.GetInt("profTürOffen", 0) == 1)
	    {
            transform.position = Vector3.MoveTowards(transform.position, openPos, Time.deltaTime);
        }
	}
    
}
