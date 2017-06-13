using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
	public string keyCode;
	private AudioSource son;

	void Start() {
		son = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (keyCode)) {
			son.Play ();
		}
			
	}
}
