using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPassFilter : Effect {
	private float maxValue = 500.0f;

	public LowPassFilter SetMaxValue(float maxValue) {
		this.maxValue = maxValue;
		return this;
	}

	public override void ApplyEffect (float value)
	{
		float cutOffFrequency = maxValue * (1.0f-value);
		if (cutOffFrequency < 20.0f) {
			cutOffFrequency = 20.0f;
		}
		audioSource.GetComponent<AudioLowPassFilter>().cutoffFrequency = cutOffFrequency;
	}
}
