﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlider : Movable {
	private Vector3 origin;
	private float max = 0.5f;
	private float min = -0.5f;
	private bool locked = false;

	public bool xAxis = false;

	void Start() {
		origin = transform.localPosition;
	}

	public void Locked(bool locked) {
		this.locked = locked;
	}

	public override void Movement(GameObject controller) {
		if(!locked) {
	        transform.position = controller.transform.position;
			if (transform.localPosition != origin) {
				float newPosition = NewPosition ();
				transform.localPosition = new Vector3 (origin.x, origin.y, newPosition);
				gameObject.GetComponentInParent<Effect>().ApplyEffect(newPosition+0.5f);
	        }
		}
	}

	private float NewPosition() {
		float localPosition = transform.localPosition.z;
		return localPosition > max ? max : localPosition < min ? min : localPosition;
	}
}
