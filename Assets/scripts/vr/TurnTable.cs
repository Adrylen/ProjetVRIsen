using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTable : MonoBehaviour {
	private float speed = 0.4f;

	void LateUpdate() {
		CD cd = GetComponentInChildren<CD> ();
		if (cd != null) {
			if (GetComponentInParent<AudioSource>().isPlaying) {
				transform.Rotate (0.0f, speed, 0.0f);
			}
		}	
	}
}
