using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : Effect {
	public bool decay = true;
	public bool delay = false;

	void Start() {
		audioSource.GetComponent<AudioEchoFilter> ().wetMix = 0.6f;
	}

	void Update() {
		if (decay == delay) {
			delay = !delay;
		}
	}

	public override void ApplyEffect (float value)
	{
		if (decay) {
			audioSource.GetComponent<AudioEchoFilter> ().decayRatio = value * 0.6f;
		} else if (delay) {
			audioSource.GetComponent<AudioEchoFilter> ().delay = value * 90.0f + 10.0f;
		}
	}
}
