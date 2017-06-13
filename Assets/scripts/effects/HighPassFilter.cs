using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPassFilter : Effect {
	private float minValue = 2000.0f;

	public HighPassFilter SetMinValue(float minValue) {
		this.minValue = minValue;
		return this;
	}

	public override void ApplyEffect (float value)
	{
		float cutOffFrequency = minValue * (10 * Mathf.Pow (value, 3.3f) + 1);
		//audioSource.GetComponent<AudioHighPassFilter>().cutoffFrequency = cutOffFrequency;
	}
}
