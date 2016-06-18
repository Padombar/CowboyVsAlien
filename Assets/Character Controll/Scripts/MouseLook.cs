/*
 * source:
 * http://answers.unity3d.com/questions/29741/mouse-look-script.html#answer-1135843
 * 
 * all credit for this script to "AndyP.123"
 */


using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	void Start ()
	{
        Cursor.lockState = CursorLockMode.Locked;
	    Cursor.visible = false;
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}

	void Update ()
	{
	    if (PlayerPrefs.GetInt("controllDeactive", 0) == 0)
	    {
	        
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
        }
    }
}
