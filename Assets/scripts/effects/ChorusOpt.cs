using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusOpt : Effect {
	public override void ApplyEffect(float x, float y, float z) {
		float sens = GetComponent<MoveFixedCube> ().invertXAxis ? -1 : 1;
		audioSource.GetComponent<AudioChorusFilter> ().delay = x * 100.0f * sens;
		audioSource.GetComponent<AudioChorusFilter> ().rate = y * 20.0f;
		audioSource.GetComponent<AudioChorusFilter> ().depth = z;
	}
}
