using UnityEngine;
using System.Collections;

public class InGameSoundSettings : MonoBehaviour {

	private float minimum = 4.536f; // 1.238f;		4.536
	private float maximum = 5.434f; // 2.13f;  4.985 + 0.449 5,434
	private float range;
	private float volume;
	bool soundHigh = false;
	bool soundLow = true;

	void Start() {
		range = maximum - minimum;
		volume = PlayerPrefs.GetFloat ("volume");
		float newYCoordinate = (range * volume) + minimum;
		Debug.Log ("newYCoordinate " + newYCoordinate);

		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, newYCoordinate, transform.position.z);

	}


	void OnMouseDrag()
	{
//		Debug.Log ("Sound Slider");
		soundHigh = false;
		soundLow = false;

		if (gameObject.transform.position.y <= maximum && gameObject.transform.position.y >= minimum) {
			float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

			Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
			transform.position = new Vector3( gameObject.transform.position.x, pos_move.y, transform.position.z );
		}

		if (gameObject.transform.position.y <= minimum) {
//			Debug.Log ("Set higher");
			soundHigh = false;
			soundLow = true;
			transform.position = new Vector3( gameObject.transform.position.x, minimum, transform.position.z );
		}

		if (gameObject.transform.position.y >= maximum) {
//			Debug.Log ("Set lower");
			soundHigh = true;
			soundLow = false;
			transform.position = new Vector3( gameObject.transform.position.x, maximum, transform.position.z );
		}

		//		Debug.Log ("Position: " + transform.position.y);

	}

	void OnMouseUp() {
//		Debug.Log("Drag ended!");

		volume = (gameObject.transform.position.y - minimum) / range;

		if (soundHigh) {
			volume = 1.0f;
		} else if (soundLow) {
			volume = 0.0f;
		}

		PlayerPrefs.SetFloat ("volume", volume);
		AudioListener.volume = volume;
		Debug.Log ("Volume zwischen 0 und 1: " + volume);
	}
}
