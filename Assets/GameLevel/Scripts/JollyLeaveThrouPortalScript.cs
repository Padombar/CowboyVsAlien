using UnityEngine;
using System.Collections;

public class JollyLeaveThrouPortalScript : MonoBehaviour {
    private bool moveJolly;
    private bool moveToPortal;
    private bool destroy;


    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (moveJolly)
	    {
	        Animation ani = GetComponent<Animation>();
            
	        ani.Play("Armature|ArmatureAction");

            transform.Translate(Vector3.forward * Time.deltaTime);

	    }

	    if (destroy)
	    {
	        destroy = false;
            Destroy(gameObject,15);
	    }
	}

    public void Move()
    {
        moveJolly = true;
        destroy = true;
    }
}
