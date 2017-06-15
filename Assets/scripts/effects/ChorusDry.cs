using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusDry : Effect {
	public override void ApplyEffect (float value) {
		audioSource.GetComponent<AudioChorusFilter>().dryMix = value;
	}
}
