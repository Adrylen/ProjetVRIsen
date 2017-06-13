using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : Actions {
	public override void LaunchAction (bool isActive)
	{
		if (isActive) {
            audioSource.Play();
		} else {
			audioSource.Pause ();
		}
	}
}
