using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distortion : Effect {
	public override void ApplyEffect (float value)
	{
        value = value == 1 ? 0.999F : value;
        audioSource.GetComponent<AudioDistortionFilter>().distortionLevel = value;
	}
}
