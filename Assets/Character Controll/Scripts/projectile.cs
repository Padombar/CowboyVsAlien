using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	public float speed = 10;
	Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction *Time.deltaTime*speed);
	}

	void setDirection(Vector3 direction){
		this.direction = direction;
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
