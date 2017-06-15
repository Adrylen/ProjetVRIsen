using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusWet : Effect {
	public override void ApplyEffect(float x, float y, float z) {
		audioSource.GetComponent<AudioChorusFilter>().wetMix1 = x;
		audioSource.GetComponent<AudioChorusFilter>().wetMix2 = y;
		audioSource.GetComponent<AudioChorusFilter>().wetMix3 = z;
	}
}
