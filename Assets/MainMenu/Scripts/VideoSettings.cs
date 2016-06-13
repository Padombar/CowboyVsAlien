using UnityEngine;
using System.Collections;

public class VideoSettings : MonoBehaviour {
	public string[] names;
	private float minimum = 3.039805f;
	private float maximum = 3.9616f;
	private float range, levelRange;
	int qualityLevel;

	void Start() {
		float newYCoordinate = 3.9616f;
		names = QualitySettings.names;
		range = maximum - minimum;
		levelRange = range / 5;
		Debug.Log ("LevelRange" + levelRange);

		if (QualitySettings.GetQualityLevel () == 5) {
			// Fantastic
			newYCoordinate = 3.9616f;
		} else if (QualitySettings.GetQualityLevel () == 4) {
			// Beautiful
			newYCoordinate = 3.731121f;
		} else if (QualitySettings.GetQualityLevel () == 3) {
			// Good
			newYCoordinate = 3.577481f;
		} else if (QualitySettings.GetQualityLevel () == 2) {
			// Simple
			newYCoordinate = 3.42382f;
		}
		else if (QualitySettings.GetQualityLevel () == 1) {
			// Fast
			newYCoordinate = 3.26968f;
		} else if (QualitySettings.GetQualityLevel () == 0) {
			// Fastest
			newYCoordinate = 3.039805f;
		}
		transform.position = new Vector3(gameObject.transform.position.x, newYCoordinate, transform.position.z );
	}

	void OnMouseDrag()
	{
		if (gameObject.transform.position.y < 3.9617f && gameObject.transform.position.y > 3.039804f) {
			float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

			Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
			transform.position = new Vector3( gameObject.transform.position.x, pos_move.y, transform.position.z );
		}

		if (gameObject.transform.position.y <= 3.039804f) {
			Debug.Log ("Video Slider Set higher");
			transform.position = new Vector3(gameObject.transform.position.x, 3.039805f, transform.position.z );
		}

		if (gameObject.transform.position.y >= 3.9617f) {
			Debug.Log ("Video Slider Set lower");
			transform.position = new Vector3( gameObject.transform.position.x, 3.9616f, transform.position.z );
		}
	}

	void OnMouseUp() {
		float newYCoordinate = 0f;

		if (gameObject.transform.position.y <= 3.9616f && gameObject.transform.position.y > 3.80795f) {
			Debug.Log("Fantastic");
			newYCoordinate = 3.9616f;
			QualitySettings.SetQualityLevel(5, true);

		} else if (gameObject.transform.position.y <= 3.80794f && gameObject.transform.position.y > 3.654302f) {
			Debug.Log("Beautiful");
			newYCoordinate = 3.731121f;
			QualitySettings.SetQualityLevel(4, true);
		}  else if (gameObject.transform.position.y <= 3.654301f && gameObject.transform.position.y > 3.50065f) {
			Debug.Log("Good");
			newYCoordinate = 3.577481f;
			QualitySettings.SetQualityLevel(3, true);
		}  else if (gameObject.transform.position.y <= 3.50064f && gameObject.transform.position.y > 3.347f) {
			Debug.Log("Simple");
			newYCoordinate = 3.42382f;
			QualitySettings.SetQualityLevel(2, true);
		}  else if (gameObject.transform.position.y <= 3.346f && gameObject.transform.position.y > 3.19335f) {
			Debug.Log("Fast");
			newYCoordinate = 3.26968f;
			QualitySettings.SetQualityLevel(1, true);
		}  else if (gameObject.transform.position.y >= 3.0 && gameObject.transform.position.y <= 3.19334f) {
			Debug.Log("Fastest");
			newYCoordinate = 3.039805f;
			QualitySettings.SetQualityLevel(0, true);
		} 

		transform.position = new Vector3(gameObject.transform.position.x, newYCoordinate, transform.position.z );
	}
}
