using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gain : Effect {
	public float maximum = 1.0f;

	public override void ApplyEffect(float value){
		float gain = value * 24.0f - 12.0f;
		maximum = Mathf.Pow (10.0f, gain) / 10.0f;
		audioSource.volume *= maximum;
	}
}
