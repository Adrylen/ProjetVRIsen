using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAction : Actions {
	public override void LaunchAction(bool isActive) {
		audioSource.loop = isActive;
	}
}
