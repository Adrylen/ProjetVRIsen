using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFixedCube : Movable {
	private float border = 0.3999f;

	public bool invertXAxis;

	void Start() { Reset (); }

	public void ResetButton () {
		transform.localPosition = new Vector3 (
			invertXAxis ? border : -border,
		-border, -border);
		transform.rotation = transform.parent.rotation;
	}
	
	public override void Movement(GameObject controller) {
		if (!locked) {
			transform.position = controller.transform.position;

			transform.localPosition = new Vector3 (
				CheckPosition(transform.localPosition.x),
				CheckPosition(transform.localPosition.y),
				CheckPosition(transform.localPosition.z)
			);

			GetComponent<Effect> ().ApplyEffect (
				(transform.localPosition.x + 0.4f) * 1.25f,
				(transform.localPosition.y + 0.4f) * 1.25f,
				(transform.localPosition.z + 0.4f) * 1.25f
			);
		}
	}

	private float CheckPosition(float p) {
		if (p > border) {
			return border;
		} else if (p < -border) {
			return -border;
		} else {
			return p;
		}
	}
}
