using UnityEngine;
using System.Collections;

public class AlienClicked : MonoBehaviour {
	private bool isHit = false;

	void OnMouseDown() {
		if (gameObject.transform.gameObject.GetComponent<ShowAndHide> ().IsAlienUp () && !isHit) {
			isHit = true;
			GameObject minigame = GameObject.FindGameObjectWithTag ("GameController");
			minigame.GetComponent<Minigame> ().AlienKilled ();
		} 
	}

	public void resetIsHitBool() {
		isHit = false;
	}
}