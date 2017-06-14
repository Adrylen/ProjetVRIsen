using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : Effect {
	public Gain gain;

	private float initValue = 0.5f;
	private float actualGain;

    public float actualValue { get; set; }
    public float faderValue { get; set; }

	void Start() {
        actualValue = initValue;
        actualGain = gain.maximum;
		audioSource.volume = initValue * actualGain * faderValue;
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + (initValue - 0.5f));
	}

	void Update() {
		if(actualGain != gain.maximum) {
			actualGain = gain.maximum;
			audioSource.volume = actualValue * actualGain * faderValue;
		}
	}

	public override void ApplyEffect (float value)
	{
        if (value != -1) { actualValue = value; }
        audioSource.volume = actualValue * actualGain * faderValue;
	}
}
