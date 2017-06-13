using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
	void Update () {
		foreach (AudioSource audioSource in GetComponents<AudioSource>()) {
			if (Input.GetKeyDown (KeyCode.P)) {
				if (audioSource.isPlaying) {
					audioSource.Pause ();
				} else {
					audioSource.Play ();
				}
			}
		}
	}
}
