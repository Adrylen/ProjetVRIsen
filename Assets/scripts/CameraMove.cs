using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	public float movementSpeed;
	public float rotationSpeed;
	public float verticalSpeed;

	void LateUpdate () {
		// Vertical translations
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (new Vector3(0.0f, -verticalSpeed, 0.0f));
		}
		if (Input.GetKey (KeyCode.E)) {
			transform.Translate (new Vector3(0.0f, verticalSpeed, 0.0f));
		}

		// Rotations
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (0.0f, -rotationSpeed, 0.0f));
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (new Vector3 (0.0f, rotationSpeed, 0.0f));
		}

		// Movement
		if (Input.GetKey (KeyCode.Z)) {
			transform.Translate (0.0f, 0.0f, movementSpeed);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (0.0f, 0.0f, -movementSpeed);
		}
	}
}
