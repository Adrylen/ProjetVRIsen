using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : Effect {
	public Gain gain;

	private float initValue = 0.5f;
    public float actualValue { get; set; }
    public float faderValue { get; set; }

	void Start() {
        actualValue = initValue;
		audioSource.volume = initValue * gain.maximum * faderValue;
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + (initValue - 0.5f));
	}

	public override void ApplyEffect (float value)
	{
        if (value != -1) { actualValue = value; }
        audioSource.volume = actualValue * gain.maximum * faderValue;
	}
}
