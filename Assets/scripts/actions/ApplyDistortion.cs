using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDistortion : Actions {
	public GameObject distortionController;

	void Start() { Reset(); }

	public void Reset() {
		distortionController.GetComponent<MoveRotator>().Reset();
		distortionController.GetComponent<MoveRotator>().Locked(true);
		audioSource.GetComponent<AudioDistortionFilter>().distortionLevel = 0.0f;
	}

	public override void LaunchAction(bool isActive) {
		if(isActive) {
			distortionController.GetComponent<MoveRotator>().Locked(false);
		} else {
			Reset();
		}
	}
}
