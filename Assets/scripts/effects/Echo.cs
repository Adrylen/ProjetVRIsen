using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : Effect {
	public bool decay = true;
	public bool delay = false;

	void Update() {
		if (decay == delay) {
			delay = !delay;
		}
	}

	public override void ApplyEffect (float value)
	{
		if (decay) {
			audioSource.GetComponent<AudioEchoFilter> ().decayRatio = value;
		} else if (delay) {
			value *= 5000.0f;
			audioSource.GetComponent<AudioEchoFilter> ().delay = value < 10.0f ? 10.0f : value;
		}
	}
}
