using UnityEngine;
using System.Collections;

public class ShowAndHide : MonoBehaviour {
	public bool isUp = false;

	public bool IsAlienUp() {
		return isUp;
	}

	public void AlienUp() {
		if (!isUp) {
			isUp = true;
			Vector3 up = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z); 
			transform.position = Vector3.MoveTowards (transform.position, up, 100f);
		}
	}

	public void AlienDown() {
		if (isUp) {
			Vector3 down = new Vector3 (transform.position.x, transform.position.y - 1.0f, transform.position.z); 
			transform.position = Vector3.MoveTowards (transform.position, down, 100f);
			gameObject.GetComponent<AlienClicked> ().resetIsHitBool ();
			isUp = false;
		}
	}
}
