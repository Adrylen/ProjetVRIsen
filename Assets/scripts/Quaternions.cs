using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternions : MonoBehaviour {
	public float x = 0.0f, y = 0.0f, z = 0.0f, w = 0.0f;

	void Update () {
		transform.rotation = new Quaternion (x, y, z, w);
	}
}
