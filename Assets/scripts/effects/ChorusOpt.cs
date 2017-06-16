using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusOpt : Effect {
	void Start() {
		audioSource.GetComponent<AudioChorusFilter> ().delay = 50.0f;
		audioSource.GetComponent<AudioChorusFilter> ().rate = 0.8f;
	}

	public override void ApplyEffect(float x, float y, float z) {
		audioSource.GetComponent<AudioLowPassFilter> ().cutoffFrequency = x < 0.02f ? 10.0f : x * 500.0f;
		audioSource.GetComponent<AudioHighPassFilter> ().cutoffFrequency = (1-y) * 20000.0f + 2000.0f;
		audioSource.GetComponent<AudioChorusFilter> ().depth = z * 0.3f;
	}
}
