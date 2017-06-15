using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distortion : Effect {
	public override void ApplyEffect (float value)
	{
        audioSource.GetComponent<AudioDistortionFilter>().distortionLevel = value;
	}
}
