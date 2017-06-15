using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFixedCube : Movable {
	private float border = 0.3499f;

	public bool invertXAxis;

	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (
			invertXAxis ? border : -border,
		-border, -border);
		transform.rotation = transform.parent.rotation;
	}
	
	public override void Movement(GameObject controller) {
		transform.position = controller.transform.position;

		transform.localPosition = new Vector3 (
			CheckPosition(transform.localPosition.x * (invertXAxis ? -1 : 1)),
			CheckPosition(transform.localPosition.y),
			CheckPosition(transform.localPosition.z),
		);
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
