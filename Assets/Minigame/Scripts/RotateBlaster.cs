using UnityEngine;
using System.Collections;

public class RotateBlaster : MonoBehaviour {
	public float lookFactor = 0.1f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		RaycastHit hit;
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		if (Physics.Raycast (ray, out hit)) {
//			Debug.Log(hit.point);
//
//			Vector3 pointUnity = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
//			transform.LookAt (pointUnity);

		}
	}

	

//	public void RotateBlasterToVector(Vector3 mousePos) {

//		float distanceZ = (transform.position.z - camera.transform.position.z) * lookFactor;
//		float distanceY = (transform.position.y - camera.transform.position.y) * lookFactor;
//		float distanceX = (transform.position.x - camera.transform.position.x) * lookFactor;
//		Vector3 position = new Vector3 (distanceX, transform.position.y, transform.position.z);
//		position = camera.ScreenToWorldPoint(position);
//		transform.LookAt(mousePos);

		//	transform.RotateAround (cameraPosition, new Vector3 (speed * Time.deltaTime, 0, 0), -0.1f);
//		transform.RotateAround(blasterPosition, direction, 200 * Time.deltaTime);
//	}



//}
