using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFader : Effect {
	public Volume leftVolume;
	public Volume rightVolume;

	private float initValue = 0.5f;

	void Start() {
		transform.localPosition = new Vector3(0.0f, 0.0f, initValue-0.5f);

		leftVolume.faderValue = 1-initValue;
		rightVolume.faderValue = initValue;
	}

	public override void ApplyEffect (float value)
	{
		leftVolume.faderValue = 1.0f - value;
		leftVolume.ApplyEffect (-1);

		rightVolume.faderValue = value;
		rightVolume.ApplyEffect (-1);
	}
}
