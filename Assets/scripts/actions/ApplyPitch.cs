using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPitch : Actions {
	public GameObject pitchController;

	void Start() {
		pitchController.GetComponent<MoveSlider>().Locked(true);
	}

	public override void LaunchAction(bool isActive) {
		if(isActive) {
			pitchController.GetComponent<MoveSlider>().Locked(false);
		} else {
			pitchController.GetComponent<MoveSlider>().Locked(true);
			pitchController.GetComponent<Pitch>().Reset();
		}
	}
}
