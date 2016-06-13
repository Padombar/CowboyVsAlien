using UnityEngine;
using System.Collections;

public class InGameVideoSettings : MonoBehaviour {
	public string[] names;
	private float minimum = 1.2379f; // 4.5619f; 
	private float maximum = 2.13f; // 5.4540f; 	// -0.1399841  + 5.594 = 5.4540
	private float constantValue = 3.324f;
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
			newYCoordinate = 2.1286f + constantValue;
		} else if (QualitySettings.GetQualityLevel () == 4) {
			// Beautiful
			newYCoordinate = 1.95046f + constantValue;
		} else if (QualitySettings.GetQualityLevel () == 3) {
			// Good
			newYCoordinate = 1.77232f + constantValue;
		} else if (QualitySettings.GetQualityLevel () == 2) {
			// Simple
			newYCoordinate = 1.59418f + constantValue;
		}
		else if (QualitySettings.GetQualityLevel () == 1) {
			// Fast
			newYCoordinate = 1.41604f + constantValue;
		} else if (QualitySettings.GetQualityLevel () == 0) {
			// Fastest
			newYCoordinate = 1.2379f + constantValue;
		}
		transform.position = new Vector3(gameObject.transform.position.x, newYCoordinate, transform.position.z );
	}

	void OnMouseDrag()
	{
		if (gameObject.transform.position.y <= maximum && gameObject.transform.position.y >= minimum) {
			float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

			Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
			transform.position = new Vector3( gameObject.transform.position.x, pos_move.y, transform.position.z );
		}

//		if (gameObject.transform.position.y <= 1.236f) {
//			Debug.Log ("Video Slider Set higher");
//			transform.position = new Vector3(gameObject.transform.position.x, minimum, transform.position.z );
//		}
//
//		if (gameObject.transform.position.y >= 2.12f) {
//			Debug.Log ("Video Slider Set lower");
//			transform.position = new Vector3( gameObject.transform.position.x, maximum, transform.position.z );
//		}
	}

	void OnMouseUp() {
		float newYCoordinate = 0f;
		float rangeTopBottom = 0.08907f;

		if ( gameObject.transform.position.y > 2.1286f + constantValue - rangeTopBottom) {  // gameObject.transform.position.y <= maximum + rangeTopBottom &&
			Debug.Log("Fantastic");
			newYCoordinate = 2.1286f + constantValue;
			QualitySettings.SetQualityLevel(5, true);
		} else if (gameObject.transform.position.y <= 1.95045f + constantValue + rangeTopBottom && gameObject.transform.position.y > 1.95046f + constantValue - rangeTopBottom) {
			Debug.Log("Beautiful");
			newYCoordinate = 1.95046f + constantValue;
			QualitySettings.SetQualityLevel(4, true);
		}  else if (gameObject.transform.position.y <= 1.77231f + constantValue + rangeTopBottom && gameObject.transform.position.y > 1.77232f + constantValue - rangeTopBottom) {
			Debug.Log("Good");
			newYCoordinate = 1.77232f + constantValue;
			QualitySettings.SetQualityLevel(3, true);
		}  else if (gameObject.transform.position.y <= 1.59417f + constantValue + rangeTopBottom && gameObject.transform.position.y > 1.59418f + constantValue - rangeTopBottom) {
			Debug.Log("Simple");
			newYCoordinate = 1.59418f + constantValue;
			QualitySettings.SetQualityLevel(2, true);
		}  else if (gameObject.transform.position.y <= 1.41603f + constantValue + rangeTopBottom && gameObject.transform.position.y > 1.41604f + constantValue - rangeTopBottom) {
			Debug.Log("Fast");
			newYCoordinate = 1.41604f + constantValue;
			QualitySettings.SetQualityLevel(1, true);
		}  else if ( gameObject.transform.position.y <= 1.2379f + constantValue + rangeTopBottom) {	// gameObject.transform.position.y >= minimum - rangeTopBottom &&
			Debug.Log("Fastest");
			newYCoordinate = 1.2379f + constantValue;
//			newYCoordinate = 1.24f;
			QualitySettings.SetQualityLevel(0, true);
		} 

		transform.position = new Vector3(gameObject.transform.position.x, newYCoordinate, transform.position.z );
	}
}
