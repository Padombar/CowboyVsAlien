using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	bool leftMouseClick = false;
	void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			leftMouseClick = true;
		}
	}

	void OnMouseUp() {
		if (leftMouseClick) {
			Application.Quit ();
		}
	}
}
