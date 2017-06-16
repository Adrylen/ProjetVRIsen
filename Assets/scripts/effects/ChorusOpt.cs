using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusOpt : Effect {
	void Start() {
		audioSource.GetComponent<AudioChorusFilter> ().delay = 50.0f;
		audioSource.GetComponent<AudioChorusFilter> ().rate = 0.8f;
	}

	public override void ApplyEffect(float x, float y, float z) {
        audioSource.GetComponent<AudioLowPassFilter>().cutoffFrequency = (1 - x) * 20000.0f + 2000.0f;      //x 
        audioSource.GetComponent<AudioHighPassFilter> ().cutoffFrequency = y < 0.02f ? 10.0f : y * 500.0f;  //y
		audioSource.GetComponent<AudioChorusFilter> ().depth = z * 0.3f;                                    //z
	}
}
